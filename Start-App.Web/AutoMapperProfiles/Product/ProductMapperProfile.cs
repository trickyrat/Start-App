using AutoMapper;
using Start_App.Domain.Dtos;
using Start_App.Domain.Entities;
using Start_App.Helper;

namespace Start_App.AutoMapperProfiles.Products
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductClass, opt => opt.MapFrom(src => src.Class));

            CreateMap<PagedList<Product>, PagedList<ProductDto>>()
                .ForCtorParam("data", opt => opt.MapFrom(src => src.Data))
                .ForCtorParam("total", opt => opt.MapFrom(src => src.TotalCount))
                .ForCtorParam("pageIndex", opt => opt.MapFrom(src => src.PageIndex))
                .ForCtorParam("pageSize", opt => opt.MapFrom(src => src.PageSize));
        }
    }
}
