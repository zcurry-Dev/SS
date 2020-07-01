using System.Threading.Tasks;
using SS.Business.Models.Artist;
using SS.Business.Models.PagedList;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Business.Interfaces
{
    public interface IArtistRepository
    {
        Task<ArtistDto> CreateArtist(ArtistToCreateDto artistToCreate);
        Task<ArtistDto> GetArtistById(int artistId);
        Task<PagedListDto<ArtistForListDto>> GetArtists(ArtistParams artistParams);
        Task<bool> UpdateArtist(int artistId, ArtistForUpdateDto artistForUpdateDto);
    }
}