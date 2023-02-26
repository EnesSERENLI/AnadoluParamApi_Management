using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Dto.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluParamApi.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Procut Mapper
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            #endregion

            #region Category Mapper
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            #endregion

            #region SubCategory Mapper
            CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
            #endregion

            #region Account Mapper
            CreateMap<AccountDto, Account>().ReverseMap();
            #endregion

            #region Order Mapper
            CreateMap<OrderDto, Order>().ReverseMap();
            #endregion

            #region OrderDetail Mapper
            CreateMap<OrderDetailDto, OrderDetail>().ReverseMap(); 
            #endregion
        }
    }
}
