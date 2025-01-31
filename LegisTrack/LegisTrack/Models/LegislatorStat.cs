namespace LegisTrack.Models
{
    public class LegislatorStat
    {
        public long Id { get; set; }
        public string LegislatorName { get; set; }
        public long Support { get; set; }
        public long Oppose { get; set; }
    }
}
