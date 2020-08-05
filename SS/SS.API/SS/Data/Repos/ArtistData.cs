using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Data.Repos
{
    public class ArtistData : DataRepo<Artist>, IArtistData
    {
        public ArtistData(DataContext context) : base(context) { }

        public async Task<PagedListData<Artist>> GetArtistsAsync(int pageIndex, int pageSize = 10, string search = "", string orderBy = "")
        {
            var query = Enumerable.Empty<Artist>().AsQueryable();
            if (!search.IsNullOrEmpty())
            {
                query = _context.Artist.Where(a => a.ArtistName.Contains(search));
            }
            else
            {
                query = _context.Artist;
            }

            if (orderBy.IsNullOrEmpty())
            {
                query.OrderByDescending(a => a.ArtistName);
            }
            else
            {
                query.OrderByDescending(a => a.ArtistId);
            }

            // var a = _context.Artist.ToList();

            var pagedList = await PagedListData<Artist>.CreateAsync(query, pageIndex, pageSize);

            return pagedList;
        }
    }
}