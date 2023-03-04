using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Dto.Dtos;
using AnadoluParamApi.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AnadoluParamApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;       

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts() //For admin
        {
            var products = await productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetDefaultProducts() //For members
        {
            var products = await productService.GetDefaultProducts();
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById([FromQuery] int id) //For members (Member can see onlu active products)
        {
            var result = await productService.GetProductByIdAsync(id);
            if (result == null)
                return NotFound("Product not found!");
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsBySubCategoryId([FromQuery] int subCategoryId) //For members
        {
            var result = await productService.GetProductsByCategory(subCategoryId);
            if (result.Count == 0)
                return BadRequest("Products not found!");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] ProductDto model) //For admin
        {
            if (!ModelState.IsValid)
                BadRequest(model);
            var result = await productService.InsertProduct(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto model) //For admin
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            var result = await productService.UpdateProduct(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id) //For admin
        {
            var result = await productService.RemoveProduct(id);
            return Ok(result);
        }

    }
}
