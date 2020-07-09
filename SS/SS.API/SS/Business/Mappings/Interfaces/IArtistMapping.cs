using System.Collections.Generic;
using SS.Business.Models.Artist;
using SS.Business.Pagination;
using SS.Data;
using SS.Data.Models;

namespace SS.Business.Mappings.Interfaces
{
    public interface IArtistMapping
    {
        void Update(ArtistForUpdateDto a, Artist artist);
        Artist MapToArtist(ArtistToCreateDto a);
        ArtistDetailDto MapToArtistDetailDto(Artist a);
        PagedListDto<ArtistForListDto> MapToArtistForListDto(PagedList<Artist> pl);
    }
}