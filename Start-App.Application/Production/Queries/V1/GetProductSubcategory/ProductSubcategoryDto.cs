/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using AutoMapper;
using Start_App.Application.Common.Mappings;
using Start_App.Domain.Entities;

namespace Start_App.Application.Production.Queries.V1.GetProductCategory
{
    public class ProductSubcategoryDto : IMapFrom<ProductSubcategory>
    {
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }

        public string SubcategoryName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductSubcategory, ProductSubcategoryDto>()
                .ForMember(dest => dest.SubcategoryName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.ProductCategoryId))
                .ForMember(dest => dest.SubcategoryId, opt => opt.MapFrom(src => src.ProductSubcategoryId));
        }
    }
}
