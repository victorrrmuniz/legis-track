

using LegisTrack.Enums;
using LegisTrack.Models;
using LegisTrack.Repositories;

namespace LegisTrack.Services
{
    public class BillService : IBillService
    {
        private readonly ICsvRepository _csvRepository;

        public BillService(ICsvRepository csvRepository)
        {
            _csvRepository = csvRepository;
        }

        public IEnumerable<LegislatorStat> GetLegislatorBillStats()
        {
            var votesResult = _csvRepository.GetVoteResults();
            var legislators = _csvRepository.GetLegislators();

            var legislatorVotes = votesResult.GroupBy(v => v.LegislatorId)
                .Select(v => new LegislatorStat
                {
                    Id = v.Key,
                    LegislatorName = legislators.FirstOrDefault(l => l.Id == v.Key)?.Name,
                    Support = v.Count(c => c.VoteType == VoteTypeEnum.Yes),
                    Oppose = v.Count(c => c.VoteType == VoteTypeEnum.No)
                });

            return legislatorVotes;
        }

        public IEnumerable<BillStat> GetBillSupportStats()
        {
            var voteResult = _csvRepository.GetVoteResults();
            var votes = _csvRepository.GetVotes();
            var bills = _csvRepository.GetBills();
            var legislators = _csvRepository.GetLegislators();

            var billVotes = voteResult.Join(votes,
                vr => vr.VoteId,
                v => v.Id,
                (vr, v) => new { v.BillId, vr.VoteType })
            .GroupBy(v => v.BillId)
            .Select(b => new BillStat
            {
                Id = b.Key,
                BillName = bills.FirstOrDefault(bill => bill.Id == b.Key)?.Title,
                SponsorName = legislators.FirstOrDefault(l => l.Id == bills.FirstOrDefault(bill => bill.Id == b.Key)?.SponsorId)?.Name,
                Supporters = b.Count(v => v.VoteType == VoteTypeEnum.Yes),
                Opposers = b.Count(v => v.VoteType == VoteTypeEnum.No)
            });

            return billVotes;
        }
    }
}
