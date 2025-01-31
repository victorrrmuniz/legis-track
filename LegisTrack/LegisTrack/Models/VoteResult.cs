using CsvHelper.Configuration.Attributes;

namespace LegisTrack.Models
{
    public class VoteResult
    {
        [Name("id")]
        public long Id { get; set; }
        [Name("legislator_id")]
        public long LegislatorId { get; set; }
        [Name("vote_id")]
        public long VoteId { get; set; }
        [Name("vote_type")]
        public long VoteType { get; set; }
    }
}
