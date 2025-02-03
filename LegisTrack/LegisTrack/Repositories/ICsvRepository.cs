using LegisTrack.Models;

namespace LegisTrack.Repositories
{
    public interface ICsvRepository
    {
        List<VoteResult> GetVoteResults();
        List<Legislator> GetLegislators();
        List<Bill> GetBills();
        List<Vote> GetVotes();
    }
}
