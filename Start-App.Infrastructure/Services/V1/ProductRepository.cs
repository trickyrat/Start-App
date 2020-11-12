using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Start_App.Domain.Entities;
using Start_App.Infrastructure.Persistence;
using System.Threading.Tasks;
using Start_App.Domain.Requests;
using Start_App.Domain.Common;
using AutoMapper;
using Start_App.Application.V1.Interface;

namespace Start_App.Application.Services.V1.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly AdventureWorks2017Context _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(AdventureWorks2017Context context,
            ILogger<ProductRepository> logger,
            IMapper _mapper)
        {
            _context = context;
            _logger = logger;
        }

        public Product Add(Product entityToAdd)
        {
            var entity = _context.Products.Add(entityToAdd);
            SaveChanges("");
            return entity.Entity;
        }

        public Task<Product> AddAsync(Product entityToAdd)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Product Details(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> DetailsAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public PagedList<Product> GetPagedAll(IPagedRequestBase request)
        {
            var query = _context.Products.AsNoTracking();
            int total = query.Count();
            var data = query.Skip(request.PageIndex * request.PageSize).Take(request.PageSize).ToList();
            var list = new PagedList<Product>(data, total, request.PageIndex, request.PageSize);
            return list;
        }

        public Task<PagedList<Product>> GetPagedAllAsync(IPagedRequestBase request)
        {
            throw new System.NotImplementedException();
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

        public bool Update(int id, Product entityToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Product entityToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public async Task SaveChangesAsync(string message)
        {
            var count = await _context.SaveChangesAsync();
            _logger.LogInformation($"{count} {message}");
        }

        public void SaveChanges(string message)
        {
            var count = _context.SaveChanges();
            _logger.LogInformation($"{count} {message}");
        }
    }
}
