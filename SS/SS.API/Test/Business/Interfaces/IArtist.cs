using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SS.Business.Models.Artist;
using SS.Business.Pagination;

namespace Test.Business.Interfaces
{
    interface IArtistTest
    {
        Task CreateArtist(ArtistToCreateDto artistToCreate);
        Task GetArtistById(int artistId);
        Task GetArtists(ArtistPageParams p);
        Task UpdateArtist(int artistId, ArtistForUpdateDto artistForUpdateDto);
    }
}
