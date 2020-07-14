using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using SS.Business.Enums;
using SS.Business.Interfaces;
using SS.Business.Mappings;
using SS.Business.Models.Artist;
using SS.Business.Pagination;
using SS.Business.Repos;
using SS.Data;
using SS.Data.Interfaces;
using SS.Data.Models;
using Test.Business.ClassData;
using Test.Business.Interfaces;
using Xunit;

namespace Test.Business.Repos
{
    public class ArtistTest : IArtistTest
    {
        [Theory]
        [ClassData(typeof(ArtistToCreateParamsData))]
        public async Task CreateArtist(ArtistToCreateDto artistToCreate)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var artist = new Artist { ArtistName = artistToCreate.Name };
                var returnDto = new ArtistDetailDto { Name = artistToCreate.Name };

                mock.Mock<IMap>().Setup(x => x.MapToArtist(artistToCreate)).Returns(artist);
                mock.Mock<IArtistData>().Setup(x => x.Add(artist));
                mock.Mock<IArtistData>().Setup(x => x.SaveAllAsync()).Returns(Task.FromResult(true));
                mock.Mock<IMap>().Setup(x => x.MapToArtistDetailDto(artist)).Returns(returnDto);

                var cls = mock.Create<ArtistRepo>();
                var expected = new ArtistDetailDto { Name = artistToCreate.Name };
                var actual = await cls.CreateArtistAsync(artistToCreate);

                Assert.True(actual != null);
                Assert.Equal(actual.Name, expected.Name);
                // More Tests needed
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task GetArtistById(int artistId)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var artist = new Artist { ArtistId = artistId };
                var returnDto = new ArtistDetailDto { Id = artistId };

                mock.Mock<IArtistData>().Setup(x => x.GetByIdAsync(artistId)).Returns(Task.FromResult(artist));
                mock.Mock<IMap>().Setup(x => x.MapToArtistDetailDto(artist)).Returns(returnDto);

                var cls = mock.Create<ArtistRepo>();
                var expected = new ArtistDetailDto { Id = artistId };
                var actual = await cls.GetArtistAsync(artistId);

                Assert.True(actual != null);
                Assert.Equal(actual.Id, expected.Id);
                // More Tests needed
            }
        }

        [Theory]
        [ClassData(typeof(ArtistPageParamsData))]
        public async Task GetArtists(ArtistPageParams p)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var plArtists = new PagedListData<Artist>(new List<Artist>(), 1, 1, 1) { };
                var returnDto = new PagedListDto<ArtistForListDto>(new List<ArtistForListDto>());

                mock.Mock<IArtistData>().Setup(x => x.GetArtistsAsync(p.PN, p.IPP, p.Search, p.OrderBy)).Returns(Task.FromResult(plArtists));
                mock.Mock<IMap>().Setup(x => x.MapToArtistForListDto(plArtists)).Returns(returnDto);

                var cls = mock.Create<ArtistRepo>();
                var expected = new PagedListDto<ArtistForListDto>(new List<ArtistForListDto>());
                var actual = await cls.GetArtistsAsync(p);

                Assert.True(actual != null);
                Assert.Equal(actual, expected);
                // More Tests needed
            }
        }

        [Theory]
        [ClassData(typeof(ArtistUpdateAndIdParamsData))]
        public async Task UpdateArtist(int artistId, ArtistForUpdateDto a)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var artist = new Artist { ArtistId = artistId };

                mock.Mock<IUtility>().Setup(x => x.CreateCityAsync(a.HomeUsCity, a.HomeUsStateId.Value)).Returns(Task.FromResult(1));
                mock.Mock<IUtility>().Setup(x => x.CreateZipCodeAsync(a.HomeUsZipcode, a.HomeUsCityId.Value)).Returns(Task.FromResult(1));
                mock.Mock<IArtistData>().Setup(x => x.GetByIdAsync(artistId)).Returns(Task.FromResult(artist));
                mock.Mock<IArtistData>().Setup(x => x.ContextUpdated()).Returns(true);
                mock.Mock<IArtistData>().Setup(x => x.SaveAllAsync()).Returns(Task.FromResult(true));

                var cls = mock.Create<ArtistRepo>();
                var expected = Result.Pass;
                var actual = await cls.UpdateArtistAsync(artistId, a);

                Assert.True(actual != null);
                Assert.Equal(actual, expected);
                // More Tests needed
            }
        }
    }
}