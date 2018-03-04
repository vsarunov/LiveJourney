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

        public static string CalculateRoute(string startStation, string finishStations, DateTime timeToBeThere)
        {
            DistanceCalculator calculator = new DistanceCalculator();
            return calculator.CalculateRoute(startStation, finishStations, timeToBeThere);
        }
    }
}
