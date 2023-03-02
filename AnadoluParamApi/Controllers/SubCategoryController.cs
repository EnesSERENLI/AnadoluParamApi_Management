using AnadoluParamApi.Dto.Dtos;
using AnadoluParamApi.Service.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnadoluParamApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService, IMapper mapper)
        {
            this.subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubCategories() //For admin
        {
            var subCategories = await subCategoryService.GetSubCategoriesAsync();
            return Ok(subCategories);
        }

        [HttpGet]
        public async Task<IActionResult> GetDefaultSubCategories() //For members
        {
            var subCategories = await subCategoryService.GetDefaultSubCategoriesAsync();
            return Ok(subCategories);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubCategoryById([FromQuery] int id) //For members
        {
            var result = await subCategoryService.GetSubCategoryByIdAsync(id);
            if (result == null)
                return NotFound("SubCategory not found!");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertSubCategory([FromBody] SubCategoryDto model) //For admin
        {
            if (!ModelState.IsValid)
                BadRequest(model);
            var result = await subCategoryService.InsertSubCategoryAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubCategory([FromBody] UpdateSubCategoryDto model) //For admin
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            var result = await subCategoryService.UpdateSubCategoryAsync(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubProduct(int id) //For admin
        {
            var result = await subCategoryService.RemoveSubCategoryAsync(id);
            return Ok(result);
        }
    }
}
