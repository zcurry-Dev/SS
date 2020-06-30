using System.Collections.Generic;
using SS.Business.Models;
using SS.Business.Models.Artist;
using SS.Data.Models;
using SS.Helpers.Pagination;

namespace SS.Business.Mappings.Interfaces
{
    public interface IArtistMapping
    {
        IEnumerable<ArtistForListDto> MapToArtistForListDto(PagedList<Artist> artistList);
        ArtistListForReturnDto MapToArtistListForReturnDto(IEnumerable<ArtistForListDto> artistsToReturn,
                                                            PagedList<Artist> plArtists);
        ArtistDto MapToArtistDto(Artist a);
        void MapArtist(ArtistForUpdateDto a, Artist artist);
        Artist MapToArtist(ArtistToCreateDto a);
    }
}