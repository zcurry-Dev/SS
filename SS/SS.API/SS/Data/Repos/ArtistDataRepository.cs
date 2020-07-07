using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SS.Data.Interfaces;
using SS.Data.Models;

namespace SS.Data.Repos
{
    public class ArtistDataRepository : DataRepository<Artist>, IArtistDataRepository
    {
        public ArtistDataRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Artist>> GetArtistsForList(int pageIndex, int pageSize = 10, string search = "", string orderBy = "")
        {
            var artists = _context.Artist.Where(a => a.ArtistName.Contains(search));

            if (orderBy == "")
            {
                artists.OrderByDescending(a => a.ArtistId);
            }
            else
            {
                artists.OrderByDescending(a => a.ArtistName);
            }

            var a = await artists
                    // .Skip((pageIndex - 1) * pageSize)
                    // .Take(pageSize)
                    .ToListAsync();

            return a;
        }
    }
}