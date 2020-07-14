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
            if (!search.IsNullOrEmpty())
            {
                _context.Artist.Where(a => a.ArtistName.Contains(search));
            }

            if (orderBy.IsNullOrEmpty())
            {
                _context.Artist.OrderByDescending(a => a.ArtistName);
            }
            else
            {
                _context.Artist.OrderByDescending(a => a.ArtistName);
            }

            var pagedList = await PagedListData<Artist>.CreateAsync(_context.Artist, pageIndex, pageSize);

            return pagedList;
        }
    }
}