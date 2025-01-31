using LegisTrack.Models;

namespace LegisTrack.Services
{
    public interface IBillService
    {
        IEnumerable<LegislatorVote> GetLegislatorBillStatis();
        IEnumerable<BillVote> GetBillSupportStats();
    }
}
