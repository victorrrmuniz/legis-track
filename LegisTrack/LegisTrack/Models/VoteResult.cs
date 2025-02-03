using CsvHelper.Configuration.Attributes;
using LegisTrack.Enums;

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
        public VoteTypeEnum VoteType { get; set; }
    }
}
