using System.Threading.Tasks;
using SS.Business.Enums;
using SS.Business.Models.Artist;
using SS.Business.Pagination;
using SS.Data;

namespace SS.Business.Interfaces
{
    public interface IArtist
    {
        Task<ArtistDetailDto> CreateArtistAsync(ArtistToCreateDto artistToCreate);
        Task<ArtistDetailDto> GetArtistAsync(int artistId);
        Task<PagedListDto<ArtistForListDto>> GetArtistsAsync(ArtistPageParams p);
        Task<Result> UpdateArtistAsync(int artistId, ArtistForUpdateDto artistForUpdateDto);
    }
}