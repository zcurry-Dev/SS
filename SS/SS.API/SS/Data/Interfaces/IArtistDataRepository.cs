using System.Threading.Tasks;
using SS.Data.Models;

namespace SS.Data.Interfaces
{
    public interface IArtistDataRepository : IDataRepository<Artist>
    {
        Task<PagedList<Artist>> GetArtistsForList(int pageIndex, int pageSize = 10, string search = "", string orderBy = "");
    }
}