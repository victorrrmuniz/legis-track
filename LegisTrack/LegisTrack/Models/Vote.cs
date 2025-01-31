using CsvHelper.Configuration.Attributes;

namespace LegisTrack.Models
{
    public class Vote
    {
        [Name("id")]
        public long Id { get; set; }
        [Name("bill_id")]
        public long BillId { get; set; }
    }
}
