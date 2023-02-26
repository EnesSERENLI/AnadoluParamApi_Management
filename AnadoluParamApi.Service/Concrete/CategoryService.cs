using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Data.UnitOfWork.Abstract;
using AnadoluParamApi.Dto.Dtos;
using AnadoluParamApi.Service.Abstract;
using AutoMapper;

namespace AnadoluParamApi.Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryDto> GetByIdCategoryAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetFilteredFirstOrDefault(selector: x => new Category
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description
            },
            expression: x => x.ID == id);

            var model = _mapper.Map<UpdateCategoryDto>(category);

            return model; //model'i dön.
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            var categoryList = await _unitOfWork.CategoryRepository.GetFilteredFirstOrDefaults(selector: x => new CategoryDto
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Status = x.Status
            },
            expression: x => x.Status == Base.Types.Status.Active || x.Status == Base.Types.Status.Updated || x.Status == Base.Types.Status.Deleted
            );

            return categoryList;
        }

        public async Task<List<CategoryDto>> GetDefaultCategoriesAsync()
        {
            var categoryList = await _unitOfWork.CategoryRepository.GetFilteredFirstOrDefaults(selector: x => new CategoryDto
            {
                CategoryName = x.CategoryName,
                Status = x.Status,
                Description = x.Description
            },
            expression: x => x.Status == Base.Types.Status.Active || x.Status == Base.Types.Status.Updated
            );

            return categoryList;
        }

        public async Task<string> InsertCategoryAsync(CategoryDto model)
        {
            try
            {
                var category = _mapper.Map<Category>(model);

                var result = await _unitOfWork.CategoryRepository.Any(x => x.CategoryName == model.CategoryName);

                if (result)
                    return "This category already exists!";

                await _unitOfWork.CategoryRepository.InsertAsync(category);
                await _unitOfWork.CompleteAsync();

                return "Category added!";
            }
            catch (Exception ex)
            {
                //todo:Log ll be added..
                return ex.Message;
            }
        }

        public async Task<string> RemoveCategoryAsync(int id)
        {
            try
            {
                var deleted = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
                if (deleted == null)
                    return "Category not found!";

                await _unitOfWork.CategoryRepository.DeleteAsync(deleted);
                await _unitOfWork.CompleteAsync();
                
                return "Category deleted!";
            }
            catch (Exception ex)
            {
                //todo:Log ll be added..
                return ex.Message;
            }
        }

        public async Task<string> UpdateCategoryAsync(UpdateCategoryDto model)
        {
            try
            {
                var updated = _mapper.Map<Category>(model);
                updated.Status = Base.Types.Status.Updated;
                updated.UpdatedDate = DateTime.Now;

                _unitOfWork.CategoryRepository.Update(updated);
                _unitOfWork.CompleteAsync();

                return "Category updated!";
            }
            catch (Exception ex)
            {
                //todo:Log ll be added..
                return ex.Message;
            }
        }
    }
}
