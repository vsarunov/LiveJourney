namespace Client.Controllers
{
    using Client.Models;
    using Client.Services;
    using DataAccess.Repository;
    using Infrastructure.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private readonly IMainRepository MainRepo = new MainRepository();
        private readonly IEnumerable<Station> Stations;
        private readonly List<TrainLine> TrainLines;
        private readonly IEnumerable<SelectListItem> StationsForView;

        public HomeController()
        {
            Stations = MainRepo.ReadStations();
            TrainLines = MainRepo.ReadTrainLines().ToList();
            StationsForView = this.GetViewStations();
            foreach (var item in TrainLines)
            {
                item.Stations = Stations.Where(x => x.TrainLineId == item.Id).ToList();
            }
        }

        public ActionResult Index()
        {
            var stations = GetViewStations();

            var model = new SearchViewModel()
            {
                Stations = stations,
                TrainLines = this.TrainLines
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel postModel)
        {
            var result = SoapService.ExecuteGetPath(postModel.StartStation, postModel.DestinationStation, postModel.Time.ToString());
            var stringResult = this.PrepareOutput(result.Stations.ToDictionary(x => x.Station, y => y.Time), result.TotalJourneyTime);
            var viewModel = new SearchViewModel()
            {
                Stations = this.StationsForView,
                Result = stringResult,
                TrainLines = this.TrainLines
            };
            return View(viewModel);
        }

        private IEnumerable<SelectListItem> GetViewStations()
        {
            List<SelectListItem> ddl = new List<SelectListItem>();

            var Stations = this.Stations.Select(x => x.StationName).Distinct();

            foreach (var stationName in Stations)
            {
                ddl.Add(new SelectListItem { Text = stationName });
            }

            IEnumerable<SelectListItem> stationNames = ddl;

            return stationNames;
        }

        private string PrepareOutput(Dictionary<Station, DateTime> stations, double journeyTime)
        {
            KeyValuePair<Station, DateTime> firstStation = stations.FirstOrDefault();
            var totalTimeInInteger = (int)journeyTime;
            double distance = 0;
            StringBuilder result = new StringBuilder();
            result.AppendLine("Take: " + this.TrainLines.Where(x => x.Id == firstStation.Key.TrainLineId).Select(x => x.TrainLineName).FirstOrDefault() + " line at station: ");
            result.AppendLine(firstStation.Key.StationName + " at time: " + firstStation.Value.Hour + ":" + firstStation.Value.Minute);

            foreach (var station in stations)
            {
                distance += station.Key.DistanceToPreviousStation;
                if (station.Equals(firstStation)) continue;
                if (station.Key.TrainLineId != firstStation.Key.TrainLineId)
                {
                    result.AppendLine("At station: " + station.Key.StationName + " change for: " + this.TrainLines.Where(x => x.Id == station.Key.TrainLineId).Select(x => x.TrainLineName).FirstOrDefault() + " line");
                }

                result.AppendLine(station.Key.StationName + " at time: " + station.Value.Hour + ":" + (station.Value.Minute < 10 ? "0" + station.Value.Minute : "" + station.Value.Minute));

                firstStation = station;

            }
            result.AppendLine("Estimated journey time: " + totalTimeInInteger + "(min)");
            result.AppendLine("Total distance covered: " + distance);
            return result.ToString();
        }
    }
}