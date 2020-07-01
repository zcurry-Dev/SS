using SS.Business.Models.Artist;
using SS.Business.Models.PagedList;
using SS.Data.Models;
using SS.Helpers.Pagination;

namespace SS.Business.Mappings.Interfaces
{
    public interface IArtistMapping
    {
        PagedListDto<ArtistForListDto> MapToListForReturnDto(PagedList<Artist> plArtists);
        ArtistDto MapToArtistDto(Artist a);
        void MapArtist(ArtistForUpdateDto a, Artist artist);
        Artist MapToArtist(ArtistToCreateDto a);
    }
}