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

        public static void CalculateRoute(string startStation, string finishStations)
        {

        }
    }
}
