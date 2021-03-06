﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Start_App.Application.Common.Models
{
    public class PagedList<T>
    {
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// 当前页码  Angular Material 以0开始
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
        public bool HasPreviousPage => TotalPages > 0 && PageIndex > 0 && PageIndex < TotalPages;

        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage => TotalPages > 0 && PageIndex < TotalPages - 1;


        public PagedList(List<T> data, int total, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Data = data;
            TotalCount = total;
            TotalPages = (int)Math.Ceiling(total / (double)PageSize);
        }
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
