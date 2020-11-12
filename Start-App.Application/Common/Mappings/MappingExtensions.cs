/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Start_App.Application.Common.Models;

namespace Start_App.Application.Common.Mappings
{
    public static class MappingExtensions
    {
        public static Task<PagedList<TDestination>> PagedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageIndex, int PageSize)
            => PagedList<TDestination>.CreateAsync(queryable, pageIndex, PageSize);

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable<TDestination> queryable, IConfigurationProvider configuration)
            => queryable.ProjectTo<TDestination>(configuration).ToListAsync();
    }
}
