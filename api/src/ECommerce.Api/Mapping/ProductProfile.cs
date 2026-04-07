using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Api.DTOs.Products;
using ECommerce.Business.Models;

namespace ECommerce.Api.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequestDto, ProductModel>();

            CreateMap<ProductModel, ProductResponseDto>();
        }
    }
}