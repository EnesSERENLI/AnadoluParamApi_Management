using AnadoluParamApi.Dto.Dtos;
using AnadoluParamApi.Service.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnadoluParamApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories() //For admin
        {
            var caregories = await categoryService.GetCategoriesAsync();
            return Ok(caregories);
        }

        [HttpGet]
        public async Task<IActionResult> GetDefaultCategories() //For members
        {
            var categories = await categoryService.GetDefaultCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryById([FromQuery] int id) //For members
        {
            var result = await categoryService.GetCategoryByIdAsync(id);
            if (result == null)
                return NotFound("Category not found!");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory([FromBody] CategoryDto model) //For admin
        {
            if (!ModelState.IsValid)
                BadRequest(model);
            var result = await categoryService.InsertCategoryAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto model) //For admin
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            var result = await categoryService.UpdateCategoryAsync(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id) //For admin
        {
            var result = await categoryService.RemoveCategoryAsync(id);
            return Ok(result);
        }
    }
}
