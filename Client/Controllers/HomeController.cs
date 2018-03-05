namespace Client.Controllers
{
    using Client.Models;
    using Client.Services;
    using DataAccess.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebService;

    public class HomeController : Controller
    {
        private readonly IMainRepository MainRepo = new MainRepository();
        private readonly IEnumerable<SelectListItem> Stations;

        public HomeController()
        {
            Stations = GetStations();
        }

        public ActionResult Index()
        {
            var stations = GetStations();

            var model = new SearchViewModel()
            {
                Stations = stations
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel postModel)
        {
            var result = SoapService.Execute(postModel.StartStation, postModel.DestinationStation, postModel.Time.ToString());

            var viewModel = new SearchViewModel()
            {
                Stations = this.Stations,
                Result = result
            };
            return View(viewModel);
        }

        private IEnumerable<SelectListItem> GetStations()
        {
            List<SelectListItem> ddl = new List<SelectListItem>();

            var Stations = MainRepo.ReadStations().Select(x => x.StationName).Distinct();

            foreach (var stationName in Stations)
            {
                ddl.Add(new SelectListItem { Text = stationName });
            }

            IEnumerable<SelectListItem> stationNames = ddl;

            return stationNames;
        }
    }
}