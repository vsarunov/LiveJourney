namespace Client.Controllers
{
    using Client.Models;
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
            WebService1 myService = new WebService1();
            var date = DateTime.Now.Date + new TimeSpan(14, 0, 0);
            myService.GetDirections("Stanmore", "Finsbury Park", date);
            return View();
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