using System.Collections.Generic;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;

namespace Start_App.Service.V1
{
    public interface IProductRepository
    {

        List<ProductCategory> GetProductCategory();

        List<ProductSubcategory> GetProductSubcategory();

        List<ProductSubcategory> GetProductSubcategory(int productCategoryId);


        PagedList<Product> GetProducts(ProductRequest request);
    }
}
