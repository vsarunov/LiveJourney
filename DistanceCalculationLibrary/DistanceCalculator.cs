﻿namespace DistanceCalculationLibrary
{
    using DataAccess.Repository;
    using Infrastructure.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DistanceCalculator
    {
        private readonly IMainRepository MainRepo = new MainRepository();
        private readonly List<DelayModel> Delays = new List<DelayModel>();
        private readonly List<TrainLine> TrainLines = new List<TrainLine>();
        private readonly List<Station> Stations = new List<Station>();
        private readonly Dictionary<long, Dictionary<long, DateTime>> StopTimes = new Dictionary<long, Dictionary<long, DateTime>>();

        public DistanceCalculator()
        {
            this.Delays.AddRange(this.MainRepo.ReadDelay());
            this.TrainLines.AddRange(this.MainRepo.ReadTrainLines());
            this.Stations.AddRange(this.MainRepo.ReadStations());

            foreach (var item in TrainLines)
            {
                item.Stations = Stations.Where(x => x.TrainLineId == item.Id).OrderBy(x => x.PreviousStationId).ToList();
            }

            this.StopTimes = CalculateTime();
        }


        // We know that train spends 2 minutes on each stop
        // we know how often the train leaves in one or the other direction
        // We know the speed of the train
        // We know the distance between the stations
        // We know how to calculate how long will it take the train to travel from one station to the other
        // We know that changing the train will add 15min to the journey
        // We assume that trains run between 5am to midnight
        public string CalculateRoute(string startStationName, string finishStationName)
        {
            var startStation = this.Stations.Where(x => x.StationName == startStationName).FirstOrDefault();
            var finishStation = this.Stations.Where(x => x.StationName == finishStationName).FirstOrDefault();

            Dictionary<long, long> visitedStations = new Dictionary<long, long>();
            if (startStation != null && finishStation != null)
            {
                Queue<Station> stationsRoute = new Queue<Station>();
                stationsRoute.Enqueue(startStation);
                var result = this.CalculateRoute(startStation, finishStation, visitedStations, stationsRoute);
                var totalJourneyTime = this.CalculateTravelTime(result);
                CalculateTimeToLeave(result);
                var res = this.PrepareOutput(result, totalJourneyTime);
                return res;
            }

            return string.Empty;
        }

        public Queue<Station> CalculateRoute(Station startStation, Station finishStation, Dictionary<long, long> visitedStations, Queue<Station> stationsRoute = null)
        {
            var startStations = this.Stations.Where(x => x.StationName == startStation.StationName);
            List<Queue<Station>> queList = new List<Queue<Station>>();

            foreach (var item in startStations)
            {

                if (startStations.Count() > 1)
                {
                    var reverseQueue = new Queue<Station>(stationsRoute.Reverse());
                    var dequeueItem = reverseQueue.Peek();
                    if (dequeueItem.StationName == item.StationName && dequeueItem.Id != item.Id)
                    {
                        reverseQueue.Dequeue();
                        var tempQueue = new Queue<Station>(reverseQueue.Reverse());
                        tempQueue.Enqueue(item);
                        stationsRoute = tempQueue;
                    }
                }

                long keyExists;
                if (!visitedStations.TryGetValue(startStation.Id, out keyExists))
                {
                    visitedStations.Add(startStation.Id, startStation.Id);
                }

                Queue<Station> leftRoute = new Queue<Station>(stationsRoute);
                Queue<Station> rightRoute = new Queue<Station>(stationsRoute);

                var nextStationLeft = Stations.Where(x => x.Id == item.NextStationId).FirstOrDefault();
                var nextStationRight = Stations.Where(x => x.Id == item.PreviousStationId).FirstOrDefault();

                if (nextStationLeft != null && nextStationLeft.StationName == finishStation.StationName)
                {
                    stationsRoute.Enqueue(nextStationLeft);
                    queList.Add(stationsRoute);
                    continue;
                }

                if (nextStationRight != null && nextStationRight.StationName == finishStation.StationName)
                {
                    stationsRoute.Enqueue(nextStationRight);
                    queList.Add(stationsRoute);
                    continue;
                }

                long nextStationLeftIsVisited;
                long nextStationRightIsVisited;

                if (nextStationLeft != null && !visitedStations.TryGetValue(nextStationLeft.Id, out nextStationLeftIsVisited))
                {
                    leftRoute.Enqueue(nextStationLeft);
                    leftRoute = CalculateRoute(nextStationLeft, finishStation, visitedStations, leftRoute);
                    if (leftRoute != null)
                    {
                        visitedStations.Remove(nextStationLeft.Id);
                    }
                }
                else
                {
                    leftRoute = null;
                }

                if (nextStationRight != null && !visitedStations.TryGetValue(nextStationRight.Id, out nextStationRightIsVisited))
                {
                    rightRoute.Enqueue(nextStationRight);
                    rightRoute = CalculateRoute(nextStationRight, finishStation, visitedStations, rightRoute);
                    if (rightRoute != null)
                    {
                        visitedStations.Remove(nextStationRight.Id);
                    }
                }
                else
                {
                    rightRoute = null;
                }

                //nextStationLeft!=null && nextStationLeft.StationName.Contains("St. Paul")
                this.AddTheShortest(queList, leftRoute, rightRoute);
            }

            return this.SelectTheMostOptimal(queList);
        }

        private void AddTheShortest(List<Queue<Station>> queList, Queue<Station> leftRoute, Queue<Station> rightRoute)
        {
            if (leftRoute != null && rightRoute != null)
            {
                var leftSum = leftRoute.Select(x => x.DistanceToPreviousStation).Sum();
                var rightSum = rightRoute.Select(x => x.DistanceToPreviousStation).Sum();
                queList.Add(leftSum > rightSum ? rightRoute : leftRoute);
            }
            else if (leftRoute == null && rightRoute != null)
            {
                queList.Add(rightRoute);
            }
            else if (leftRoute != null && rightRoute == null)
            {
                queList.Add(leftRoute);
            }
        }

        private Queue<Station> SelectTheMostOptimal(List<Queue<Station>> routeList)
        {
            var element = routeList.Count == 0 ? null : routeList[0];
            if (element != null)
            {
                for (int i = 0; i < routeList.Count; i++)
                {
                    if (this.CalculateTravelTime(element) > this.CalculateTravelTime(routeList[i]))
                    {
                        element = routeList[i];
                    }
                }
            }
            return element;
        }

        private string PrepareOutput(Queue<Station> stations, double journeyTime)
        {
            Station station = stations.Dequeue();
            var totalTimeInInteger = (int)journeyTime;

            StringBuilder result = new StringBuilder();
            result.AppendLine("Take: " + this.TrainLines.Where(x => x.Id == station.TrainLineId).Select(x => x.TrainLineName).FirstOrDefault() + " line at station: ");
            result.AppendLine(station.StationName);
            while (stations.Count > 0)
            {
                Station nextStation = stations.Dequeue();
                if (nextStation.TrainLineId != station.TrainLineId)
                {
                    result.AppendLine("At station: " + nextStation.StationName + " change for: " + this.TrainLines.Where(x => x.Id == nextStation.TrainLineId).Select(x => x.TrainLineName).FirstOrDefault() + " line");
                }

                result.AppendLine(nextStation.StationName);

                station = nextStation;
            }
            result.AppendLine("Total journey time: " + totalTimeInInteger + "(min)");

            return result.ToString();
        }

        // we spend 2 mins on each station
        // each train line change adds 15mins
        // train has a travel speed and distance to the next station
        private double CalculateTravelTime(Queue<Station> stations)
        {
            // t = d/s;
            // we multiply all the stations we have to travel by 2 minutes spend on each station and minus 4 for the stations we entered and came out
            var minutesSpendOnStations = stations.Count * 2 - 4;

            long firstId = -1;
            var minutesWhileChangingLines = stations.Select(x => x.TrainLineId).Distinct().Select(x =>
            {
                if (firstId != x && firstId != -1)
                {
                    firstId = x;
                    return 15;
                }
                firstId = x;
                return 0;
            }).Sum();

            var trainLineStationsMap = stations.GroupBy(x => x.TrainLineId).ToDictionary(x => x.Key, y => y.Where(t => t.TrainLineId == y.Key));

            double trainLineTotalTime = 0;
            foreach (var item in trainLineStationsMap)
            {
                var totalDistance = item.Value.Select(x => x.DistanceToPreviousStation).Sum();
                var trainLineTravelSpeed = this.TrainLines.Where(x => x.Id == item.Key).Select(x => x.TrainTravelSpeed).FirstOrDefault();
                trainLineTotalTime += totalDistance / trainLineTravelSpeed;
            }

            var delays = CheckForDelays(stations);

            var totalTime = minutesSpendOnStations + minutesWhileChangingLines + trainLineTotalTime + delays;

            return totalTime;
        }

        // if the last station where the change happens is the stations that the delay starts - do not add delay
        // if the start stations is the station where the delay end - do not add delay
        // if the station is in between or is the starting stations - add the delay
        private long CheckForDelays(Queue<Station> stations)
        {
            // we have to measure how many stations does the traveller cross in the delay subline
            long totalDelay = 0;
            var trainStationsWithDelays = this.TrainLines.Where(x => this.Delays.Any(d => d.TrainLineId == x.Id) && stations.Any(s => s.TrainLineId == x.Id));

            foreach (var delayedLines in trainStationsWithDelays)
            {
                var delaysOnTheLine = this.Delays.Where(x => x.TrainLineId == delayedLines.Id);
                var currentStationOnDelayedLine = stations.Where(x => x.TrainLineId == delayedLines.Id).ToList();
                var currentStationOnDelayedLineCount = currentStationOnDelayedLine.Count;
                var currentStationOnDelayedLineLast = currentStationOnDelayedLine.Last();
                var currentStationOnDelayedLineFirst = currentStationOnDelayedLine.First();

                foreach (var delay in delaysOnTheLine)
                {
                    var delayedSubLine = delayedLines.Stations.SkipWhile(x => x.Id != delay.StartDelayStationId).TakeWhile(x => x.Id != delay.EndDelayStationId || x.Id == delay.EndDelayStationId).ToList();
                    var indexOfLastStation = delayedSubLine.FindIndex(x => x.Id == currentStationOnDelayedLineLast.Id);
                    var indexOfFirstStation = delayedSubLine.FindIndex(x => x.Id == currentStationOnDelayedLineFirst.Id);
                    bool delayHasBeenAdded = false;
                    if (indexOfLastStation != -1)
                    {
                        var stationsTraveledThroughDelay = Math.Abs(indexOfLastStation - currentStationOnDelayedLineCount);
                        //Check is needed ifthe start delay station is actually the station the passanger comes off
                        if (stationsTraveledThroughDelay != currentStationOnDelayedLineCount)
                        {
                            totalDelay += delay.DelayTime;
                            delayHasBeenAdded = true;
                        }
                    }

                    if (indexOfFirstStation != -1 && indexOfFirstStation != delayedSubLine.Count - 1 && !delayHasBeenAdded)
                    {
                        totalDelay += delay.DelayTime;
                    }
                }
            }
            return totalDelay;
        }

        private Dictionary<long, Dictionary<long, DateTime>> CalculateTime()
        {
            var stopTimes = new Dictionary<long, Dictionary<long, DateTime>>();

            foreach (var trainLine in this.TrainLines)
            {
                //start datetime
                DateTime now = DateTime.Now;
                DateTime startDate = now.Date + new TimeSpan(5, 0, 0);
                // t = d/s;
                var trainLineSpeed = trainLine.TrainTravelSpeed;
                var trainLineStations = trainLine.Stations;

                var stationStopTimeMap = new Dictionary<long, DateTime>();
                stationStopTimeMap.Add(trainLineStations[0].Id, startDate);
                stopTimes.Add(trainLine.Id, stationStopTimeMap);

                for (int i = 1; i < trainLineStations.Count; i++)
                {
                    var timeTakenToReach = trainLineStations[i].DistanceToPreviousStation / trainLineSpeed;
                    //2 min spend on every station
                    startDate = startDate + new TimeSpan(0, (int)timeTakenToReach + 2, 0);
                    stationStopTimeMap.Add(trainLineStations[i].Id, startDate);
                }
            }

            return stopTimes;
        }

        private Dictionary<Station, DateTime> CalculateTimeToLeave(Queue<Station> stations)
        {
            var trainStationsIds = stations.Select(x => x.TrainLineId).Distinct();
            var stationTime = new Dictionary<Station, DateTime>();
            foreach (var trainStationId in trainStationsIds)
            {
                var stationOnTheTrainLine = stations.Where(x => x.TrainLineId == trainStationId);
                var stopTimesOfTrainLines = this.StopTimes.Where(x => x.Key == trainStationId).ToDictionary(x => x.Key, y => y.Value);
                foreach (var trainLineTimes in stopTimesOfTrainLines)
                {
                    foreach (var station in stationOnTheTrainLine)
                    {
                        DateTime stationArriveTime = trainLineTimes.Value[station.Id];
                        stationTime.Add(station, stationArriveTime);
                    }

                }
            }
            var revertResult = RevertTime(stationTime);
            var timeFixResult = SetChangeTrainLineTime(revertResult);
            return timeFixResult;
        }

        private Dictionary<Station, DateTime> SetChangeTrainLineTime(Dictionary<Station, DateTime> stationTimeMap)
        {
            Dictionary<Station, DateTime> stationTimeMapModified = new Dictionary<Station, DateTime>();
            var firstStation = stationTimeMap.FirstOrDefault();
            int skipCounter = 0;
            foreach (var stations in stationTimeMap)
            {
                if (skipCounter != 0)
                {
                    skipCounter--;
                    continue;
                }

                if (stations.Equals(firstStation))
                {
                    stationTimeMapModified.Add(stations.Key, stations.Value);
                    firstStation = stations;
                    continue;
                }

                if (firstStation.Key.TrainLineId != stations.Key.TrainLineId)
                {
                    var firstTime = firstStation.Value;
                    var secondTime = stations.Value;
                    int minuteDifference = Math.Abs(firstStation.Value.Minute - stations.Value.Minute);
                    int compareResult = DateTime.Compare(firstTime, secondTime);
                    if (compareResult == 0 || compareResult > 0)
                    {
                        var stationsToModify = stationTimeMap.Where(x => x.Key.TrainLineId == stations.Key.TrainLineId);
                        skipCounter = stationsToModify.Count();
                        IncreaseTime(firstStation, stationsToModify, stationTimeMapModified);
                    }
                    else if (compareResult < 0 && minuteDifference < 10)// chaning a train add 10 minutes
                    {
                        var stationsToModify = stationTimeMap.Where(x => x.Key.TrainLineId == stations.Key.TrainLineId);
                        skipCounter = stationsToModify.Count();
                        IncreaseTime(firstStation, stationsToModify, stationTimeMapModified);
                    }
                    else
                    {
                        stationTimeMapModified.Add(stations.Key, stations.Value);
                        firstStation = stations;
                    }
                }
                else
                {
                    stationTimeMapModified.Add(stations.Key, stations.Value);
                    firstStation = stations;
                }

            }
            return stationTimeMapModified;
        }

        private void IncreaseTime(KeyValuePair<Station, DateTime> stationBeforeNewTrainLine,
            IEnumerable<KeyValuePair<Station, DateTime>> StationsToIncrease,
            Dictionary<Station, DateTime> stationTimeMapModified)
        {
            List<KeyValuePair<Station, DateTime>> StationsToIncreaseModified;
            var trainLine = this.TrainLines.Where(x => x.Id == StationsToIncrease.Select(y => y.Key.TrainLineId).FirstOrDefault()).FirstOrDefault();
            if (trainLine != null)
            {
                bool isBigger = false;
                var trainLineDepartureDelay = trainLine.TrainDepartureDelay;
                KeyValuePair<Station, DateTime> firstStation;
                do
                {
                    StationsToIncreaseModified = new List<KeyValuePair<Station, DateTime>>();
                    foreach (var station in StationsToIncrease)
                    {
                        var newKeyValuePair = new KeyValuePair<Station, DateTime>(station.Key, station.Value.AddMinutes(trainLineDepartureDelay));
                        StationsToIncreaseModified.Add(newKeyValuePair);
                    }
                    StationsToIncrease = StationsToIncreaseModified;
                    firstStation = StationsToIncrease.FirstOrDefault();

                    int compareResult = DateTime.Compare(firstStation.Value, stationBeforeNewTrainLine.Value);
                    int minuteDifference = Math.Abs(stationBeforeNewTrainLine.Value.Minute - firstStation.Value.Minute);
                    if (compareResult > 0 && minuteDifference >= 10)// changing a train adds 10mins
                    {
                        isBigger = true;
                    }

                } while (!isBigger);

                foreach (var station in StationsToIncrease)
                {
                    stationTimeMapModified.Add(station.Key, station.Value);
                }
            }
        }

        private Dictionary<Station, DateTime> RevertTime(Dictionary<Station, DateTime> stationTimeMap)
        {
            Dictionary<Station, DateTime> stationTimeMapModified = new Dictionary<Station, DateTime>();
            var firstItem = stationTimeMap.FirstOrDefault();
            foreach (var stationTimePair in stationTimeMap)
            {
                if (firstItem.Equals(stationTimePair) || firstItem.Key.TrainLineId != stationTimePair.Key.TrainLineId)
                {
                    stationTimeMapModified.Add(stationTimePair.Key, stationTimePair.Value);
                    firstItem = stationTimePair;
                    continue;
                }

                var firstTime = firstItem.Value;
                var secondTime = stationTimePair.Value;
                int compareTimeResult = DateTime.Compare(secondTime, firstTime);
                if (compareTimeResult < 0)
                {
                    int minutesDifferent = Math.Abs(secondTime.Minute - firstTime.Minute);
                    var value = firstTime.Date + new TimeSpan(firstTime.Hour, stationTimeMapModified.Last().Value.Minute + minutesDifferent, 0);
                    stationTimeMapModified.Add(stationTimePair.Key, value);
                    firstItem = stationTimePair;
                }
                else
                {
                    stationTimeMapModified.Add(stationTimePair.Key, stationTimePair.Value);
                    firstItem = stationTimePair;
                }

            }
            return stationTimeMapModified;
        }
    }
}


