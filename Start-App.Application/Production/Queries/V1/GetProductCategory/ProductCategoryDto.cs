using AutoMapper;
using Start_App.Application.Common.Mappings;
using Start_App.Domain.Entities;

namespace Start_App.Application.Production.Queries.V1.GetProductCategory
{
    public class ProductCategoryDto: IMapFrom<ProductCategory>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductCategory, ProductCategoryDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.ProductCategoryId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
