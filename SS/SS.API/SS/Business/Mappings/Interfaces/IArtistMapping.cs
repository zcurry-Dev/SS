using System.Collections.Generic;
using SS.Business.Models.Artist;
using SS.Business.Models.PagedList;
using SS.Data.Models;
using SS.Helpers.Pagination;

namespace SS.Business.Mappings.Interfaces
{
    public interface IArtistMapping
    {
        void Update(ArtistForUpdateDto a, Artist artist);
        Artist MapToArtist(ArtistToCreateDto a);
        ArtistDetailDto MapToArtistDetailDto(Artist a);

        //
        IEnumerable<ArtistForListDto> MapToArtistForListDtoAsQueryable(IEnumerable<Artist> artists);
        PagedListDto<ArtistForListDto> MapToPagedListDto(PagedList<ArtistForListDto> artistList);

        //
        //
        PagedListDto<ArtistForListDto> MapToListForReturnDto(PagedList<Artist> plArtists);
    }
}