using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Dto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluParamApi.Service.Abstract
{
    public interface ICategoryService
    {
        //Add
        Task<string> InsertCategoryAsync(CategoryDto model);
        //Delete
        Task<string> RemoveCategoryAsync(int id);
        //Update
        Task<string> UpdateCategoryAsync(UpdateCategoryDto model);
        //List
        Task<List<CategoryDto>> GetCategoriesAsync();

        Task<List<CategoryDto>> GetDefaultCategoriesAsync();
        //Find
        Task<UpdateCategoryDto> GetCategoryByIdAsync(int id);
    }
}
