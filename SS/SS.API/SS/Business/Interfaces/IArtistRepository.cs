using System.Threading.Tasks;
using SS.Business.Dtos.Accept;
using SS.Business.Dtos.Return;
using SS.Helpers.Pagination.PagedParams;

namespace SS.Business.Interfaces
{
    public interface IArtistRepository
    {
        Task<ArtistForDetailedDto> CreateArtist(ArtistToCreate artistToCreate);
        Task<ArtistForDetailedDto> GetArtistById(int artistId);
        Task<ArtistListForReturnDto> GetArtists(ArtistParams artistParams);
        Task<bool> UpdateArtist(int artistId, ArtistForUpdateDto artistForUpdateDto);
    }
}