namespace WebService
{
    using DistanceCalculationLibrary;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;


    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetDirections(string startStationName, string finishStationName, DateTime arriveDate)
        {
            return CalculationManager.CalculateRoute(startStationName, finishStationName, arriveDate);
        }
    }
}
