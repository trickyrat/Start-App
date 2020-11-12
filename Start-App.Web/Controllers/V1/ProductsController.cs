using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Start_App.Domain.Entities;
using Start_App.Domain.Dtos;
using Start_App.Domain.Requests;
using Start_App.Domain.Common;
using Start_App.Application.V1.Interface;

namespace Start_App.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiVersion("1.2", Deprecated = true)]
    [OpenApiTag("Products", Description = "Production enviroment")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public IActionResult Products([FromQuery] ProductRequest request)
        {
            var data = _repository.GetProducts(request);
            var res = _mapper.Map<PagedList<Product>, PagedList<ProductDto>>(data);
            return Ok(res);
        }


        [HttpGet("ProductCategory")]
        [MapToApiVersion("1")]
        public IActionResult ProductCategory()
        {
            var data = _repository.GetProductCategory();
            var res = _mapper.Map<List<ProductCategory>, List<ProductCategoryDto>>(data);
            return Ok(res);
        }

        [HttpGet("ProductSubcategory")]
        [MapToApiVersion("1")]
        public IActionResult ProductSubCategory([FromQuery] int subCategoryId)
        {
            var data = _repository.GetProductSubcategory(subCategoryId);
            var res = _mapper.Map<List<ProductSubcategory>, List<ProductSubcategoryDto>>(data);
            return Ok(res);
        }


    }
}
