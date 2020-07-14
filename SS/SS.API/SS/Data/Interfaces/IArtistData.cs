using System.Threading.Tasks;
using SS.Data.Models;

namespace SS.Data.Interfaces
{
    public interface IArtistData : IDataRepo<Artist>
    {
        Task<PagedListData<Artist>> GetArtistsAsync(int pageIndex, int pageSize = 10, string search = "", string orderBy = "");
    }
}