using DataAccess.Repository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveJourney
{
    public class InsertMockData
    {
        private readonly IMainRepository MainRepo = new MainRepository();
        private readonly Dictionary<string, string[]> mockedData = new Dictionary<string, string[]>();
        private readonly List<string> ColourList = new List<string>();
        public InsertMockData()
        {
            var isPopulated = this.MainRepo.ReadConfig();

            if (isPopulated == 0 || isPopulated == -1)
            {
                MessageBox.Show("Mocked data is being inserted this may take up to 5 minutes before application starts, press OK to continue");
                this.PopulateMockedData();
                this.PopualteColourList();
                this.StartInserting();
                this.MainRepo.InsertConfig();
            }
        }

        private void PopulateMockedData()
        {
            StaticTrainLinesAndStations.PopulateTrainLines();
            foreach (var item in StaticTrainLinesAndStations.TrainLinesAndStations)
            {
                string[] lines = item.Value.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                mockedData.Add(item.Key, lines);
            }
        }

        private void PopualteColourList()
        {
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.ColourList.Add(c.Name);
            }
        }

        private void StartInserting()
        {
            foreach (var item in mockedData)
            {
                var trainLine = new TrainLine() { TrainLineName = item.Key, TrainTravelSpeed = new Random().Next(20, 50), TrainDepartureDelay = new Random().Next(3, 10), TrainLineColour = this.ColourList[new Random().Next(0, this.ColourList.Count - 1)] };
                var trainLineId = this.MainRepo.InsertTrainline(trainLine);

                var distanceToPreviousStation = 0;
                var nextStationId = -1L;
                var previousStationId = -1L;
                var stationId = -1L;
                foreach (var station in item.Value)
                {
                    var newStation = new Station() { TrainLineId = trainLineId, StationName = station, DistanceToPreviousStation = distanceToPreviousStation, PreviousStationId = previousStationId, NextStationId = nextStationId };
                    stationId = this.MainRepo.InsertStation(newStation);
                    if (previousStationId != -1)
                    {
                        var prevStation = this.MainRepo.ReadStationsById(previousStationId);
                        if (prevStation != null)
                        {
                            prevStation.NextStationId = stationId;
                            this.MainRepo.UpdateStation(prevStation);
                        }
                    }

                    previousStationId = stationId;
                    distanceToPreviousStation = new Random().Next(80, 150);

                }
            }
        }
    }
}
