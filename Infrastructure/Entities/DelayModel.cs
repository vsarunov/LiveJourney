namespace Infrastructure.Entities
{
    public class DelayModel
    {
        public long Id { get; set; }
        public long DelayTime { get; set; }
        public long TrainLineId { get; set; }
        public long StartDelayStationId { get; set; }
        public long EndDelayStationId { get; set; }
        public long TimeStamp { get; set; }
    }
}
