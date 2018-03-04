using DistanceCalculationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveJourney
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InsertMockData md = new InsertMockData();
            //var date = DateTime.Now.Date + new TimeSpan(14, 0, 0);
            //var res = CalculationManager.CalculateRoute("Stanmore", "Finsbury Park", date);
            //res = CalculationManager.CalculateRoute("King’s Cross St. Pancras", "Finsbury Park", date);
            //res = CalculationManager.CalculateRoute("Bank", "Bond Street", date);
            var mainForm = new Form1();
            mainForm.Show();
            Application.Run();
        }
    }
}
