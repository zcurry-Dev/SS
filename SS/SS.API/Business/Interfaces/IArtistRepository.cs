using System.Threading.Tasks;
using SS.API.Dtos.Artist;

namespace SS.API.Business.Interfaces
{
    public interface IArtistRepository
    {
        Task<ArtistForDetailedDto> GetArtist(int artistId);
    }
}