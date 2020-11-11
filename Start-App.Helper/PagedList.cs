using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// 数据列表
        /// </summary>
        public List<T> Data { get; set; }

        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPrevious => PageIndex > 1;

        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNext => PageIndex < TotalPages;


        public PagedList(List<T> data, int total, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Data = data;
            TotalCount = total;
            TotalPages = (int)Math.Ceiling(total / (double)PageSize);
        }

        //public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source,
        //    int pageIndex,
        //    int pageSize,
        //    string sortColumn = null,
        //    string sortOrder = null,
        //    string filterColumn = null,
        //    string filterQuery = null)
        //{
        //    if (!string.IsNullOrEmpty(filterColumn)
        //        && !string.IsNullOrEmpty(filterQuery)
        //        && IsValidProperty(filterColumn))
        //    {
        //        // 根据T的属性进行过滤
        //        source = source.Where(string.Format("{0}.Contains(@0)", filterColumn), filterQuery);

        //    }
        //    var count = await source.CountAsync();
        //    if (!string.IsNullOrEmpty(sortColumn)
        //        && IsValidProperty(sortColumn))
        //    {
        //        sortOrder = !string.IsNullOrEmpty(sortOrder)
        //            && sortOrder.ToUpper() == "ASC"
        //            ? "ASC"
        //            : "DESC";
        //        // 根据T的属性进行排序
        //        source = source.OrderBy(string.Format("{0} {1}", sortColumn, sortOrder));
        //    }
        //    source = source.Skip(pageIndex * pageSize).Take(pageSize);
        //    var data = await source.ToListAsync();

        //    return new PagedList<T>(pageSize, pageIndex, count, data, sortColumn, sortOrder, filterColumn, filterQuery);
        //}


        //public static PagedList<T> Create(IQueryable<T> source,
        //    int pageIndex,
        //    int pageSize,
        //    string sortColumn = null,
        //    string sortOrder = null,
        //    string filterColumn = null,
        //    string filterQuery = null)
        //{

        //    List<string> columns = filterColumn.Split("&").ToList();
        //    List<string> queries = filterQuery.Split("&").ToList();
            
        //    //for (int i = 0; i < columns.Count; i++)
        //    //{
        //    //    if (!string.IsNullOrEmpty(columns[i])
        //    //        && !string.IsNullOrEmpty(queries[i])
        //    //        && IsValidProperty(columns[i]))
        //    //    {
        //    //        // 根据T的属性进行过滤
        //    //        source = source.Where($"{columns[i]}.Contains(@0)", queries[i]);
        //    //    }
        //    //}
        //    //foreach (var column in columns)
        //    //{
        //    //    if (!string.IsNullOrEmpty(column)
        //    //        && !string.IsNullOrEmpty(filterQuery)
        //    //        && IsValidProperty(column))
        //    //    {
        //    //        // 根据T的属性进行过滤
        //    //        source = source.Where($"{filterColumn}.Contains(@0)", filterQuery);

        //    //    }
        //    //}
      
        //    //var count = source.Count();

        //    //if (!string.IsNullOrEmpty(sortColumn)
        //    //    && IsValidProperty(sortColumn))
        //    //{
        //    //    sortOrder = !string.IsNullOrEmpty(sortOrder)
        //    //        && sortOrder.ToUpper() == "ASC"
        //    //        ? "ASC"
        //    //        : "DESC";
        //    //    // 根据T的属性进行排序
        //    //    source = source.OrderBy($"{sortColumn} {sortOrder}");
        //    //}
        //    //source = source.Skip(pageIndex * pageSize).Take(pageSize);
        //    //var data = source.ToList();

        //    return new PagedList<T>(pageSize, pageIndex, count, data, sortColumn, sortOrder, filterColumn, filterQuery);
        //}



        //public static bool IsValidProperty(string propertyName, bool throwExceptionIfNotFound = true)
        //{
        //    var prop = typeof(T).GetProperty(
        //        propertyName,
        //        BindingFlags.IgnoreCase |
        //        BindingFlags.Public |
        //        BindingFlags.Static |
        //        BindingFlags.Instance);
        //    if(prop == null && throwExceptionIfNotFound)
        //    {
        //        throw new NotSupportedException($"Error: Propery {propertyName} does not exist.");
        //    }
        //    return prop != null;
        //}
    }
}
