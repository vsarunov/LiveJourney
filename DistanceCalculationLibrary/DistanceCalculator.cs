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

        public DistanceCalculator()
        {
            this.Delays.AddRange(this.MainRepo.ReadDelay());
            this.TrainLines.AddRange(this.MainRepo.ReadTrainLines());
            this.Stations.AddRange(this.MainRepo.ReadStations());
        }


        // We know that train spends 2 minutes on each stop
        // we know how often the train leaves in one or the other direction
        // We know the speed of the train
        // We know the distance between the stations
        // We know how to calculate how long will it take the train to travel from one station to the other
        // We know that changing the train will add 15min to the journey
        // We assume that trains run between 5am to midnight
        public void CalculateRoute(string startStationName, string finishStationName)
        {
            var startStation = this.Stations.Where(x => x.StationName == startStationName).FirstOrDefault();
            var finishStation = this.Stations.Where(x => x.StationName == finishStationName).FirstOrDefault();

            Dictionary<long, long> visitedStations = new Dictionary<long, long>();
            if (startStation != null && finishStation != null)
            {
                Queue<Station> stationRoute = new Queue<Station>();
                stationRoute.Enqueue(startStation);
                var result = this.CalculateRoute(startStation, finishStation, visitedStations, stationRoute);
            }
        }

        public Queue<Station> CalculateRoute(Station startStation, Station finishStation, Dictionary<long, long> visitedStations, Queue<Station> stationsRoute = null)
        {
            var startStations = this.Stations.Where(x => x.StationName == startStation.StationName).OrderBy(x => startStation.Id);
            List<Queue<Station>> queList = new List<Queue<Station>>();

            foreach (var item in startStations)
            {
                long keyExists;
                if (!visitedStations.TryGetValue(item.Id, out keyExists))
                {
                    visitedStations.Add(item.Id, item.Id);
                }
            }

            foreach (var item in startStations)
            {
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
                else if (nextStationRight != null && nextStationRight.StationName == finishStation.StationName)
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
                }
                else
                {
                    leftRoute = null;
                }

                if (nextStationRight != null && !visitedStations.TryGetValue(nextStationRight.Id, out nextStationRightIsVisited))
                {
                    rightRoute.Enqueue(nextStationRight);
                    rightRoute = CalculateRoute(nextStationRight, finishStation, visitedStations, rightRoute);
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
            if (element != null)
            {
                for (int i = 0; i < routeList.Count; i++)
                {
                    if (element.Select(x => x.DistanceToPreviousStation).Sum() > routeList[i].Select(x => x.DistanceToPreviousStation).Sum())
                    {
                        element = routeList[i];
                    }
                }
            }
            return element;
        }
    }
}


