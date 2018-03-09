namespace Infrastructure.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;


    public class GetDirectionsResult
    {
        public List<StationTimePair> Stations { get; set; }
        public double TotalJourneyTime { get; set; }
    }
}
