using System.Collections.Generic;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Business.Models;
using SS.Data.Models;
using SS.Helpers.Pagination;

namespace SS.Business.Mappings.Interfaces
{
    public interface IArtistMapping
    {
        IEnumerable<ArtistForListDto> MapToArtistForListDto(PagedList<Artist> artistList);
        ArtistListForReturnDto MapToArtistListForReturnDto(
            IEnumerable<ArtistForListDto> artistsToReturn, PagedList<Artist> plArtists);
        ArtistBModel MapToArtistBModel(Artist a);
        void MapArtist(ArtistForUpdateDto a, Artist artist);
        Artist MapToArtist(ArtistToCreateDto a);
    }
}