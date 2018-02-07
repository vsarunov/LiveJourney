namespace Infrastructure.Entities
{
    public class Station
    {
        public long Id { get; set; } = -1;
        public long TrainLineId { get; set; }
        public string StationName { get; set; }
        public long NextStationId { get; set; } = -1;
        public long PreviousStationId { get; set; } = -1;
        public double DistanceToPreviousStation { get; set; }
        public long Delay { get; set; } = 0;
    }
}
