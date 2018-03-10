namespace DistanceCalculationLibrary
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
        private readonly Dictionary<long, Dictionary<long, DateTime>> StopTimesOriginalDirection = new Dictionary<long, Dictionary<long, DateTime>>();
        private readonly Dictionary<long, Dictionary<long, DateTime>> StopTimesRevers = new Dictionary<long, Dictionary<long, DateTime>>();

        public DistanceCalculator()
        {
            this.Delays.AddRange(this.MainRepo.ReadDelay());
            this.TrainLines.AddRange(this.MainRepo.ReadTrainLines());
            this.Stations.AddRange(this.MainRepo.ReadStations());

            foreach (var item in TrainLines)
            {
                item.Stations = Stations.Where(x => x.TrainLineId == item.Id).OrderBy(x => x.PreviousStationId).ToList();
            }

            this.StopTimesOriginalDirection = CalculateTime();
            this.StopTimesRevers = CalculateTimeRevers();
        }

        public GetDirectionsResult CalculateRoute(string startStationName, string finishStationName, DateTime requestedArriveTime)
        {
            var startStation = this.Stations.Where(x => x.StationName == startStationName).FirstOrDefault();
            var finishStation = this.Stations.Where(x => x.StationName == finishStationName).FirstOrDefault();

            Dictionary<long, long> visitedStations = new Dictionary<long, long>();
            if (startStation != null && finishStation != null)
            {
                Queue<Station> stationsRoute = new Queue<Station>();
                stationsRoute.Enqueue(startStation);
                var calculationResult = this.CalculateRoute(startStation, finishStation, visitedStations, stationsRoute);
                Dictionary<Station, DateTime> stationTimeCollection = null;
                var totalJourneyTime = this.CalculateTravelTime(calculationResult, ref stationTimeCollection);
                var timeArriveResult = SetTimeToArriveTime(requestedArriveTime, stationTimeCollection);

                var resultingObject = new GetDirectionsResult()
                {
                    Stations = timeArriveResult.Select(x => new StationTimePair() { Station = x.Key, Time = x.Value }).ToList(),
                    TotalJourneyTime = totalJourneyTime
                };

                return resultingObject;
            }

            return null;
        }

        private Dictionary<Station, DateTime> SetTimeToArriveTime(DateTime arriveTime, Dictionary<Station, DateTime> stationTimeCollection)
        {
            Dictionary<Station, DateTime> stationTimeCollectionModified = null;
            KeyValuePair<Station, DateTime> LastItem;
            double totalMinutes;
            do
            {
                stationTimeCollectionModified = new Dictionary<Station, DateTime>();
                foreach (var item in stationTimeCollection)
                {
                    var trainLine = this.TrainLines.Where(x => x.Id == item.Key.TrainLineId).FirstOrDefault();
                    stationTimeCollectionModified.Add(item.Key, item.Value.AddMinutes(trainLine.TrainDepartureDelay));
                }
                LastItem = stationTimeCollectionModified.LastOrDefault();
                stationTimeCollection = stationTimeCollectionModified;
                totalMinutes = arriveTime.Subtract(LastItem.Value).TotalMinutes;
            } while (totalMinutes > 10);

            return stationTimeCollectionModified;
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
            Dictionary<Station, DateTime> stationTimeCollection = new Dictionary<Station, DateTime>();
            if (element != null)
            {
                for (int i = 0; i < routeList.Count; i++)
                {
                    // Does not matter what is inside the collection at this point so we just pass it in
                    var elementResult = this.CalculateTravelTime(element, ref stationTimeCollection);
                    var routeResult = this.CalculateTravelTime(routeList[i], ref stationTimeCollection);
                    if (elementResult > routeResult)
                    {
                        element = routeList[i];
                    }
                    else if (elementResult == routeResult && element.Count > routeList[i].Count)
                    {
                        element = routeList[i];
                    }
                }
            }
            return element;
        }

        // we spend 2 mins on each station
        // each train line change adds 15mins
        // train has a travel speed and distance to the next station
        private double CalculateTravelTime(Queue<Station> stations, ref Dictionary<Station, DateTime> stationTimeCollection)
        {
            var delays = CheckForDelays(stations);

            stationTimeCollection = CalculateTimeToLeave(stations);

            var firstStation = stationTimeCollection.FirstOrDefault();
            var lastStation = stationTimeCollection.LastOrDefault();

            TimeSpan span = lastStation.Value.Subtract(firstStation.Value);

            double totalTime = span.TotalMinutes + delays;

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
                        //Check is needed if the start delay station is actually the station the passanger comes off
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

                List<Station> trainLineStations = trainLine.Stations;

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

        private Dictionary<long, Dictionary<long, DateTime>> CalculateTimeRevers()
        {
            var stopTimes = new Dictionary<long, Dictionary<long, DateTime>>();

            foreach (var trainLine in this.TrainLines)
            {
                //start datetime
                DateTime now = DateTime.Now;
                DateTime startDate = now.Date + new TimeSpan(5, 0, 0);
                // t = d/s;
                var trainLineSpeed = trainLine.TrainTravelSpeed;

                List<Station> trainLineStations = trainLine.Stations;
                trainLineStations.Reverse();

                var stationStopTimeMap = new Dictionary<long, DateTime>();
                stationStopTimeMap.Add(trainLineStations[0].Id, startDate);
                stopTimes.Add(trainLine.Id, stationStopTimeMap);

                for (int i = 1; i < trainLineStations.Count; i++)
                {
                    var timeTakenToReach = trainLineStations[i - 1].DistanceToPreviousStation / trainLineSpeed;
                    //2 min spend on every station
                    startDate = startDate + new TimeSpan(0, (int)timeTakenToReach + 2, 0);
                    stationStopTimeMap.Add(trainLineStations[i].Id, startDate);
                }
            }

            return stopTimes;
        }

        private Dictionary<Station, DateTime> CalculateTimeToLeave(Queue<Station> stations)
        {
            // each station is assigned a value that the first train would reach the station
            var trainStationsIds = stations.Select(x => x.TrainLineId).Distinct();
            var stationTime = new Dictionary<Station, DateTime>();
            foreach (var trainStationId in trainStationsIds)
            {
                var stationOnTheTrainLine = stations.Where(x => x.TrainLineId == trainStationId).Distinct().ToList();

                bool areStationsReverted = false;
                if (stationOnTheTrainLine.Count > 1) areStationsReverted = CheckIfStationsReverted(stationOnTheTrainLine[0], stationOnTheTrainLine[1]);

                var stopTimesOfTrainLines = this.StopTimesOriginalDirection.Where(x => x.Key == trainStationId).ToDictionary(x => x.Key, y => y.Value);
                var stopTimesOfTrainLinesRevers = this.StopTimesRevers.Where(x => x.Key == trainStationId).ToDictionary(x => x.Key, y => y.Value);
                foreach (var trainLineTimes in !areStationsReverted ? stopTimesOfTrainLines : stopTimesOfTrainLinesRevers)
                {
                    foreach (var station in stationOnTheTrainLine)
                    {
                        DateTime stationArriveTime = trainLineTimes.Value[station.Id];
                        stationTime.Add(station, stationArriveTime);
                    }

                }
            }

            var timeFixResult = SetChangeTrainLineTime(stationTime);
            return timeFixResult;
        }

        private bool CheckIfStationsReverted(Station one, Station two)
        {
            return one.PreviousStationId == two.Id;
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
                        firstStation = stationTimeMapModified.LastOrDefault();
                    }
                    else if (compareResult < 0 && minuteDifference < 10)// chaning a train adds 10 minutes
                    {
                        var stationsToModify = stationTimeMap.Where(x => x.Key.TrainLineId == stations.Key.TrainLineId);
                        skipCounter = stationsToModify.Count();
                        IncreaseTime(firstStation, stationsToModify, stationTimeMapModified);
                        firstStation = stationTimeMapModified.LastOrDefault();
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
                    var minuteDifference = Math.Abs(stationBeforeNewTrainLine.Value.Subtract(firstStation.Value).TotalMinutes);
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
    }
}


