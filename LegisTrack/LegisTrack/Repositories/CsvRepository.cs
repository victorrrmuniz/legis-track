using CsvHelper;
using LegisTrack.Models;
using System.Globalization;

namespace LegisTrack.Repositories
{
    public class CsvRepository : ICsvRepository
    {
        public List<VoteResult> GetVoteResults()
        {
            string path = "Data/vote_results.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<VoteResult>().ToList();
            }
        }

        public List<Legislator> GetLegislators()
        {
            string path = "Data/legislators.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Legislator>().ToList();
            }
        }

        public List<Bill> GetBills()
        {
            string path = "Data/bills.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Bill>().ToList();
            }
        }

        public List<Vote> GetVotes()
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
