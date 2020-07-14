using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SS.Business.Pagination;

namespace SS.Data
{
    public class PagedListData<T> : PagedList<T>
    {
        public PagedListData(List<T> items, int count, int pageIndex, int pageSize)
        {
            TotalItems = count;
            ItemsPerPage = pageSize;
            CurrentPage = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public static async Task<PagedListData<T>> CreateAsync(IQueryable<T> source,
            int pageIndex, int pageSize)
        {
            try
            {
                var count = await source.CountAsync();
                var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                return new PagedListData<T>(items, count, pageIndex, pageSize);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                List<T> items = new List<T>();
                var count = 0;
                return new PagedListData<T>(items, count, pageIndex, pageSize);
            }
        }
    }
}