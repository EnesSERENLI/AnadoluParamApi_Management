using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Dto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluParamApi.Service.Abstract
{
    public interface IProductService
    {
        //Add
        Task<string> InsertProduct(ProductDto model); //Add new Product
        //Delete
        Task<string> RemoveProduct(int id); //Delete product
        //Update
        Task<string> UpdateProduct(UpdateProductDto model); //update product
        //List
        Task<List<ProductDto>> GetAllProductsAsync(); //Get all product even deleted.. 
        Task<List<ProductDto>> GetDefaultProducts(); //Get only all active product
        Task<List<ProductDto>> GetProductsByCategory(int subCategoryId); //Get product according to category
        //Find
        Task<UpdateProductDto> GetProductByIdAsync(int id); 
    }
}
