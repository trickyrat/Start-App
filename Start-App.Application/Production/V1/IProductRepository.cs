using System.Collections.Generic;
using Start_App.Domain.Entities;
using Start_App.Domain.Requests;
using Start_App.Domain.Common;
using Start_App.Application.Interface;

namespace Start_App.Application.V1.Interface
{
    public interface IProductRepository : IService<Product>
    {

        List<ProductCategory> GetProductCategory();

        List<ProductSubcategory> GetProductSubcategory();

        List<ProductSubcategory> GetProductSubcategory(int productCategoryId);

        public PagedList<Product> GetProducts(ProductRequest request);

    }
}
