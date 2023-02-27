using AnadoluParamApi.Dto.Dtos;

namespace AnadoluParamApi.Service.Abstract
{
    public interface ISubCategoryService
    {
        //Add
        Task<string> InsertSubCategoryAsync(SubCategoryDto model);
        //Delete
        Task<string> RemoveSubCategoryAsync(int id);
        //Update
        Task<string> UpdateSubCategoryAsync(UpdateSubCategoryDto model);
        //List
        Task<List<SubCategoryDto>> GetSubCategoriesAsync();

        Task<List<SubCategoryDto>> GetDefaultSubCategoriesAsync();
        //Find
        Task<UpdateSubCategoryDto> GetSubCategoryByIdAsync(int id);
    }
}
