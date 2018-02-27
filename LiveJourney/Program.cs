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
            CalculationManager.CalculateRoute("Stanmore", "Finsbury Park");
            //var mainForm = new Form1();
            //mainForm.Show();
            //Application.Run();
        }
    }
}
