using System.Threading.Tasks;
using SS.Business.Enums;
using SS.Business.Models.Artist;
using SS.Business.Pagination;
using SS.Data;

namespace SS.Business.Interfaces
{
    public interface IArtistRepository
    {
        Task<ArtistDetailDto> CreateArtist(ArtistToCreateDto artistToCreate);
        Task<ArtistDto> GetArtistById(int artistId);
        Task<PagedListDto<ArtistForListDto>> GetArtists(ArtistParams p);
        Task<Result> UpdateArtist(int artistId, ArtistForUpdateDto artistForUpdateDto);
    }
}