namespace Infrastructure.Entities
{
    public class Station
    {
        public long Id { get; set; } = -1;
        public long TrainLineId { get; set; }
        public string StationName { get; set; }
        public long NextStationId { get; set; }
        public long PreviousStationId { get; set; }
        public long DistanceToPreviousStation { get; set; }
    }
}
