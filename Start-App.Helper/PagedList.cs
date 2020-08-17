using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Start_App.Helper
{
    public class PagedList<T>
    {
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; private set; }
        /// <summary>
        /// 数据总数
        /// </summary>
        public int TotalCount { get; private set; }
        /// <summary>
        /// 页的总数
        /// </summary>
        public int TotalPages { get; private set; }
        public List<T> Data { get; set; }

        public bool HasPrevious => PageIndex > 1;
        public bool HasNext => PageIndex < TotalPages;

        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string FilterColumn { get; set; }
        public string FilterQuery { get; set; }

        public PagedList(int pageSize,
            int pageIndex,
            int count,
            List<T> data,
            string sortColumn,
            string sortOrder,
            string filterColumn,
            string filterQuery)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Data = data;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            SortColumn = sortColumn;
            SortOrder = sortOrder;
            FilterColumn = filterColumn;
            FilterQuery = filterQuery;
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source,
            int pageIndex,
            int pageSize,
            string sortColumn = null,
            string sortOrder = null,
            string filterColumn = null,
            string filterQuery = null)
        {
            if (!string.IsNullOrEmpty(filterColumn)
                && !string.IsNullOrEmpty(filterQuery)
                && IsValidProperty(filterColumn))
            {
                // 根据T的属性进行过滤
                source = source.Where(string.Format("{0}.Contains(@0)", filterColumn), filterQuery);

            }
            var count = await source.CountAsync();
            if (!string.IsNullOrEmpty(sortColumn)
                && IsValidProperty(sortColumn))
            {
                sortOrder = !string.IsNullOrEmpty(sortOrder)
                    && sortOrder.ToUpper() == "ASC"
                    ? "ASC"
                    : "DESC";
                // 根据T的属性进行排序
                source = source.OrderBy(string.Format("{0} {1}", sortColumn, sortOrder));
            }
            source = source.Skip(pageIndex * pageSize).Take(pageSize);
            var data = await source.ToListAsync();

            return new PagedList<T>(pageSize, pageIndex, count, data, sortColumn, sortOrder, filterColumn, filterQuery);
        }

        public static bool IsValidProperty(string propertyName, bool throwExceptionIfNotFound = true)
        {
            var prop = typeof(T).GetProperty(
                propertyName,
                BindingFlags.IgnoreCase |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance);
            if(prop == null && throwExceptionIfNotFound)
            {
                throw new NotSupportedException($"Error: Propery {propertyName} does not exist.");
            }
            return prop != null;
        }
    }
}
