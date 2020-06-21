using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Start_App.Helper
{
    public class PagedList<T> : List<T>
    {
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; private set; }

        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public List<T> Items { get; set; }

        public bool HasPrevious => PageIndex > 1;
        public bool HasNext => PageIndex < TotalPages;

        public PagedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            Items = items;
            TotalCount = count;
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            AddRange(Items);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
