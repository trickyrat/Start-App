using AutoMapper;
using Start_App.Domain.Entities;
using Start_App.Domain.Dtos;

namespace Start_App.AutoMapperProfiles.Products
{
    public class ProductCategoryMapperProfile : Profile
    {
        public ProductCategoryMapperProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.ProductCategoryId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name));


            CreateMap<ProductSubcategory, ProductSubcategoryDto>()
                .ForMember(dest => dest.SubcategoryId, opt => opt.MapFrom(src => src.ProductSubcategoryId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name));

        }
    }
}
