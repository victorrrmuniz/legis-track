

using System.Globalization;
using System.IO;
using CsvHelper;
using LegisTrack.Models;

namespace LegisTrack.Services
{
    public class BillService : IBillService
    {
        public IEnumerable<LegislatorVote> GetLegislatorBillStatis()
        {
            var votesResult = GetVoteResults();
            var legislators = GetLegislators();

            var legislatorVotes = votesResult.GroupBy(v => v.LegislatorId)
                .Select(v => new LegislatorVote
                {
                    LegislatorId = v.Key,
                    LegislatorName = legislators.FirstOrDefault(l => l.Id == v.Key)?.Name,
                    Support = v.Count(c => c.VoteType == 1),
                    Oppose = v.Count(c => c.VoteType == 2)
                });

            return legislatorVotes;
        }

        public IEnumerable<BillVote> GetBillSupportStats()
        {
            var voteResult = GetVoteResults();
            var votes = GetVotes();
            var bills = GetBills();
            var legislators = GetLegislators();

            var billVotes = voteResult.Join(votes,
                vr => vr.VoteId,
                v => v.Id,
                (vr, v) => new { v.BillId, vr.VoteType })
            .GroupBy(v => v.BillId)
            .Select(b => new BillVote
            {
                Id = b.Key,
                BillName = bills.FirstOrDefault(bill => bill.Id == b.Key)?.Title,
                SponsorName = legislators.FirstOrDefault(l => l.Id == bills.FirstOrDefault(bill => bill.Id == b.Key)?.SponsorId)?.Name,
                Supporters = b.Count(v => v.VoteType == 1),
                Opposers = b.Count(v => v.VoteType == 2)
            });

            return billVotes;
        }

        private List<VoteResult> GetVoteResults()
        {
            string path = "Data/vote_results.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<VoteResult>().ToList();
            }
        }

        private List<Legislator> GetLegislators()
        {
            string path = "Data/legislators.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Legislator>().ToList();
            }
        }

        private List<Bill> GetBills()
        {
            string path = "Data/bills.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Bill>().ToList();
            }
        }

        private List<Vote> GetVotes()
        {
            string path = "Data/votes.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Vote>().ToList();
            }
        }
    }
}
