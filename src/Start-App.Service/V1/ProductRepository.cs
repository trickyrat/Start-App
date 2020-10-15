using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
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
        public PagedList<Product> GetProducts(RequestBase request)
        {
            var query = _context.Product.AsQueryable();
            var list = PagedList<Product>.Create(query,
                request.PageIndex,
                request.PageSize,
                request.SortColumn,
                request.SortOrder,
                request.FilterColumn,
                request.FilterQuery);
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
