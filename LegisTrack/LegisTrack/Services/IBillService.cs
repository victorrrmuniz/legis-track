using LegisTrack.Models;

namespace LegisTrack.Services
{
    public interface IBillService
    {
        IEnumerable<LegislatorStat> GetLegislatorBillStats();
        IEnumerable<BillStat> GetBillSupportStats();
    }
}
