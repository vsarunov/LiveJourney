namespace Infrastructure.Entities
{
    using System.Collections.Generic;

    public class TrainLine
    {
        public long Id { get; set; } = -1;
        public string TrainLineName { get; set; }
        public string TrainLineColour { get; set; }
        public List<Station> Stations { get; set; } = new List<Station>();
    }
}
