namespace LegisTrack.Services
{
    public interface IBillService
    {
        long GetLegislatorBillStatis(long legislatorId);
        long GetBillSupportStats(long billId);
    }
}
