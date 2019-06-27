using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademySystem
{

    public class Paginacion<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public List<T> items { get; set; }

        public Paginacion(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }
        public bool HasPreviousPage
        {
            get
            {
                if (PageIndex == 1)
                    return (PageIndex == (PageIndex+1));
                else
                    return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public static async Task<Paginacion<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageIndex).ToListAsync();
            return new Paginacion<T>(items, count, pageIndex, pageSize);
        }
    }
}
