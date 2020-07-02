using SS.Business.Models.Artist;
using SS.Business.Models.PagedList;
using SS.Data.Models;
using SS.Helpers.Pagination;

namespace SS.Business.Mappings.Interfaces
{
    public interface IArtistMapping
    {
        void UpdateArtist(ArtistForUpdateDto a, Artist artist);
        PagedListDto<ArtistForListDto> MapToListForReturnDto(PagedList<Artist> plArtists);
        ArtistDto MapToArtistDetailDto(Artist a);
        Artist MapToArtist(ArtistToCreateDto a);
    }
}