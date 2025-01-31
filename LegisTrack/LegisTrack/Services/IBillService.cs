using LegisTrack.Models;

namespace LegisTrack.Services
{
    public interface IBillService
    {
        IEnumerable<LegislatorStat> GetLegislatorBillStatis();
        IEnumerable<BillStat> GetBillSupportStats();
    }
}
