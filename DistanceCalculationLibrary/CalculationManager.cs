namespace DistanceCalculationLibrary
{
    using Infrastructure.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class CalculationManager
    {

        public static void CalculateRoute(string startStation, string finishStations)
        {
            DistanceCalculator calculator = new DistanceCalculator();
            calculator.CalculateRoute(startStation, finishStations);
        }

        public static void CalculateRoute(Station startStation, Station finishStations)
        {

        }
    }
}
