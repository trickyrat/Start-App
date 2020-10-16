using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Start_App.Data.Models;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;

namespace Start_App.Service.V1
{
    public class ProductRepository : IProductRepository
    {

        private readonly AdventureWorks2017Context _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(AdventureWorks2017Context context,
            ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// 获取所有产品分类列表
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetProductCategory()
        {
            return _context.ProductCategory.ToList();
        }

        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        public PagedList<Product> GetProducts(ProductRequest request)
        {
            //var query = _context.ProductCategory
            //   .Include(p => p.ProductSubcategory)
            //       .ThenInclude(sc => sc.Product)
            //   .Where(c => c.ProductCategoryId == request.ProductCategoryId).AsQueryable();

            //var query = _context.Product
            //    .Include(p => p.ProductSubcategory)
            //        .ThenInclude(sc => sc.ProductCategory)
            //            .ThenInclude(c => c.ProductCategoryId == request.ProductCategoryId).AsQueryable();
            _logger.LogInformation($"Request time: {DateTime.Now}, Request parameters: {JsonConvert.SerializeObject(request)}");
            var query = _context.Product.Where(x => x.ProductSubcategoryId == request.ProductSubcatgoryId).AsQueryable();
            int total = query.Count();
            query = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
            var data = query.ToList();
            var list = new PagedList<Product>(data, total, request.PageIndex, request.PageSize);

            return list;
        }

        /// <summary>
        /// 获取所有产品子分类列表
        /// </summary>
        /// <returns></returns>
        public List<ProductSubcategory> GetProductSubcategory()
        {
            return _context.ProductSubcategory.ToList();
        }

        /// <summary>
        /// 获取给定产品分类ID的子分类列表
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        public List<ProductSubcategory> GetProductSubcategory(int productCategoryId)
        {
            return _context.ProductSubcategory.Where(x => x.ProductCategoryId == productCategoryId).ToList();
        }
    }
}
