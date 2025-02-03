using LegisTrack.Models;
using LegisTrack.Repositories;
using LegisTrack.Services;
using Moq;
using Xunit;
using LegisTrack.Enums;

namespace LegisTrackTests.Services
{
    public class BillServiceTests
    {
        private readonly Mock<ICsvRepository> _csvRepositoryMock;
        private readonly BillService _billService;
        private readonly List<VoteResult> _voteResults;
        private readonly List<Legislator> _legislators;
        private readonly List<Vote> _votes;
        private readonly List<Bill> _bills;

        public BillServiceTests()
        {
            _csvRepositoryMock = new Mock<ICsvRepository>();
            _billService = new BillService(_csvRepositoryMock.Object);

            _voteResults = new List<VoteResult>
            {
                new VoteResult
                {
                    Id = 92516784,
                    LegislatorId = 400440,
                    VoteId = 3321166,
                    VoteType = VoteTypeEnum.No
                },
                new VoteResult
                {
                    Id = 92516770,
                    LegislatorId = 17941,
                    VoteId = 3321166,
                    VoteType = VoteTypeEnum.No
                },
                new VoteResult
                {
                    Id = 92279758,
                    LegislatorId = 904789,
                    VoteId = 3314452,
                    VoteType = VoteTypeEnum.Yes
                },
            };

            _legislators = new List<Legislator>
            {
                new Legislator
                {
                    Id = 400440,
                    Name = "Rep. Don Young (R-AK-1)"
                },
                new Legislator
                {
                    Id = 17941,
                    Name = "Rep. Jeff Van Drew (R-NJ-2)"
                },
                new Legislator
                {
                    Id = 904789,
                    Name = "Rep. Don Bacon (R-NE-2)"
                },
                new Legislator
                {
                    Id = 412211,
                    Name = "Rep.John Yarmuth(D-KY - 3)"
                }
            };

            _votes = new List<Vote>
            {
                new Vote { Id = 3314452, BillId = 2900994 },
                new Vote { Id = 3321166, BillId = 2952375 }
            };

            _bills = new List<Bill>
            {
                new Bill { Id = 2952375, Title = "H.R. 5376: Build Back Better Act", SponsorId = 412211 },
                new Bill { Id = 2900994, Title = "H.R. 3684: Infrastructure Investment and Jobs Act", SponsorId = 400100 }
            };
        }

        [Fact]
        public void GetLegislatorBillStats_WhenDataIsCorrect_ShouldReturnCorrectStats()
        {
            // Arrange
            _csvRepositoryMock.Setup(repo => repo.GetVoteResults()).Returns(_voteResults);
            _csvRepositoryMock.Setup(repo => repo.GetLegislators()).Returns(_legislators);

            // Act
            var result = _billService.GetLegislatorBillStats().ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result[0].Support);
            Assert.Equal(1, result[0].Oppose);

            Assert.Equal(0, result[1].Support);
            Assert.Equal(1, result[1].Oppose);

            Assert.Equal(1, result[2].Support);
            Assert.Equal(0, result[2].Oppose);
        }

        [Fact]
        public void GetLegislatorBillStats_WhenVoteResultsIsNull_ShouldReturnEmptyList()
        {
            // Arrange
            var voteResults = new List<VoteResult>();
            _csvRepositoryMock.Setup(repo => repo.GetVoteResults()).Returns(voteResults);
            _csvRepositoryMock.Setup(repo => repo.GetLegislators()).Returns(_legislators);

            // Act
            var result = _billService.GetLegislatorBillStats().ToList();

            // Assert
            Assert.Empty(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetLegislatorBillStats_WhenLegislatorsIsNull_ShouldReturnCorrectDataExceptLegislators()
        {
            // Arrange
            var legislators = new List<Legislator>();
            _csvRepositoryMock.Setup(repo => repo.GetVoteResults()).Returns(_voteResults);
            _csvRepositoryMock.Setup(repo => repo.GetLegislators()).Returns(legislators);

            // Act
            var result = _billService.GetLegislatorBillStats().ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.NotNull(result);

            result.ForEach(item =>
            {
                Assert.Null(item.LegislatorName);
            });
        }

        [Fact]
        public void GetBillSupportStats_WhenDataIsCorrect_ReturnBillSupportStats()
        {
            // Arrange
            _csvRepositoryMock.Setup(repo => repo.GetVoteResults()).Returns(_voteResults);
            _csvRepositoryMock.Setup(repo => repo.GetVotes()).Returns(_votes);
            _csvRepositoryMock.Setup(repo => repo.GetBills()).Returns(_bills);
            _csvRepositoryMock.Setup(repo => repo.GetLegislators()).Returns(_legislators);

            // Act
            var result = _billService.GetBillSupportStats().ToList();

            // Assert
            Assert.NotNull(result);
        }


        [Fact]
        public void GetBillSupportStats_WhenVoteReultsIsNull_ReturnEmpty()
        {
            // Arrange
            var voteResults = new List<VoteResult>();
            _csvRepositoryMock.Setup(repo => repo.GetVoteResults()).Returns(voteResults);
            _csvRepositoryMock.Setup(repo => repo.GetVotes()).Returns(_votes);
            _csvRepositoryMock.Setup(repo => repo.GetBills()).Returns(_bills);
            _csvRepositoryMock.Setup(repo => repo.GetLegislators()).Returns(_legislators);

            // Act
            var result = _billService.GetBillSupportStats().ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetBillSupportStats_WhenVotesIsNull_ShouldReturnEmpty()
        {

            // Arrange
            var votes = new List<Vote>();
            _csvRepositoryMock.Setup(repo => repo.GetVoteResults()).Returns(_voteResults);
            _csvRepositoryMock.Setup(repo => repo.GetVotes()).Returns(votes);
            _csvRepositoryMock.Setup(repo => repo.GetBills()).Returns(_bills);
            _csvRepositoryMock.Setup(repo => repo.GetLegislators()).Returns(_legislators);

            // Act
            var result = _billService.GetBillSupportStats().ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetBillSupportStats_WhenBillsIsNull_ShouldReturnCorrectStatsExceptBills()
        {
            // Arrange
            var bills = new List<Bill>();
            _csvRepositoryMock.Setup(repo => repo.GetVoteResults()).Returns(_voteResults);
            _csvRepositoryMock.Setup(repo => repo.GetVotes()).Returns(_votes);
            _csvRepositoryMock.Setup(repo => repo.GetBills()).Returns(bills);
            _csvRepositoryMock.Setup(repo => repo.GetLegislators()).Returns(_legislators);

            // Act
            var result = _billService.GetBillSupportStats().ToList();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetBillSupportStats_WhenLegislatorsIsNull_ShouldReturnCorrectStatsExceptSponsorName()
        {
            // Arrange
            var legislators = new List<Legislator>();
            _csvRepositoryMock.Setup(repo => repo.GetVoteResults()).Returns(_voteResults);
            _csvRepositoryMock.Setup(repo => repo.GetVotes()).Returns(_votes);
            _csvRepositoryMock.Setup(repo => repo.GetBills()).Returns(_bills);
            _csvRepositoryMock.Setup(repo => repo.GetLegislators()).Returns(legislators);

            // Act
            var result = _billService.GetBillSupportStats().ToList();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
