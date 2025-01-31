namespace LegisTrack.Models
{
    public class LegislatorVote
    {
        public long LegislatorId { get; set; }
        public string LegislatorName { get; set; }
        public long Support { get; set; }
        public long Oppose { get; set; }
    }
}
