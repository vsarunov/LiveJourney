using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveJourney
{
    public class InsertMockData
    {
        private readonly IMainRepository MainRepo = new MainRepository();
        private readonly Dictionary<string, string> mockedData = new Dictionary<string, string>();

        public InsertMockData()
        {
            StaticTrainLinesAndStations.PopulateTrainLines();
            foreach (var item in StaticTrainLinesAndStations.TrainLinesAndStations)
            {
                string[] lines = item.Value.Split(
                    new[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None);
            }
        }
    }
}
