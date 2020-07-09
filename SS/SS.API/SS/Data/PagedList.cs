using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SS.Data
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        // public IEnumerable<T> Items { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalItems = count;
            ItemsPerPage = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source,
            int pageIndex, int pageSize)
        {
            try
            {
                var count = await source.CountAsync();
                var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
                return new PagedList<T>(items, count, pageIndex, pageSize);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                List<T> items = new List<T>();
                int count = 0;
                return new PagedList<T>(items, count, pageIndex, pageSize);
            }
        }
    }
}