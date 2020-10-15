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
                .ForCtorParam("count", opt => opt.MapFrom(src => src.TotalCount))
                .ForCtorParam("pageIndex", opt => opt.MapFrom(src => src.PageIndex))
                .ForCtorParam("pageSize", opt => opt.MapFrom(src => src.PageSize))
                .ForCtorParam("sortColumn", opt => opt.MapFrom(src => src.SortColumn))
                .ForCtorParam("sortOrder", opt => opt.MapFrom(src => src.SortOrder))
                .ForCtorParam("filterColumn", opt => opt.MapFrom(src => src.FilterColumn))
                .ForCtorParam("filterQuery", opt => opt.MapFrom(src => src.FilterQuery));
        }
    }
}
