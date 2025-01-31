using CsvHelper.Configuration.Attributes;

namespace LegisTrack.Models
{
    public class Bill
    {
        [Name("id")]
        public long Id { get; set; }
        [Name("title")]
        public string Title { get; set; }
        [Name("sponsor_id")]
        public long SponsorId { get; set; }
    }
}
