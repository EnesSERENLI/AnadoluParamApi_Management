using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Dto.Dtos;
using AnadoluParamApi.Dto.VMs;
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
            CreateMap<UpdateSubCategoryDto, SubCategory>().ReverseMap();
            #endregion

            #region Account Mapper
            CreateMap<AccountDto, Account>().ReverseMap();
            CreateMap<UpdateAccountDto, Account>().ReverseMap();
            #endregion

            #region Order Mapper
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<CartItem, OrderDto>(); //I get accountId when creating order. Order details are in a separate table.
            CreateMap<OrderDetailDto, OrderVM>(); //I get accountId when creating order. Order details are in a separate table.
            #endregion

            #region OrderDetail Mapper
            CreateMap<OrderDetailDto, OrderDetail>().ReverseMap(); 
            CreateMap<CartItem, OrderDetailDto>().ReverseMap(); 
            #endregion
        }
    }
}
