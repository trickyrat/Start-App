using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Start_App.Domain.Entities;
using Start_App.Domain.Context;
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
            return _context.ProductCategories.ToList();
        }

        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        public PagedList<Product> GetProducts(ProductRequest request)
        {
            var query = _context.Products.Where(x => x.ProductSubcategoryId == request.ProductSubcatgoryId).AsNoTracking();
            int total = query.Count();
            var data = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize).ToList();
            var list = new PagedList<Product>(data, total, request.PageIndex, request.PageSize);
            return list;
        }

        /// <summary>
        /// 获取所有产品子分类列表
        /// </summary>
        /// <returns></returns>
        public List<ProductSubcategory> GetProductSubcategory()
        {
            return _context.ProductSubcategories.ToList();
        }

        /// <summary>
        /// 获取给定产品分类ID的子分类列表
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        public List<ProductSubcategory> GetProductSubcategory(int productCategoryId)
        {
            return _context.ProductSubcategories.Where(x => x.ProductCategoryId == productCategoryId).ToList();
        }
    }
}
