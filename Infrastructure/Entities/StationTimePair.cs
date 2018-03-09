using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class StationTimePair
    {
        public Station Station { get; set; }
        public DateTime Time { get; set; }
    }
}
