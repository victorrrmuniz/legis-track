using CsvHelper.Configuration.Attributes;

namespace LegisTrack.Models
{
    public class Legislator
    {
        [Name("id")]
        public long Id { get; set; }
        [Name("name")]
        public string Name { get; set; }
    }
}
