namespace LegisTrack.Models
{
    public class BillVote
    {
        public long Id { get; set; }
        public string BillName { get; set; }
        public long Supporters { get; set; }
        public long Opposers { get; set; }
        public string SponsorName { get; set; }
    }
}
