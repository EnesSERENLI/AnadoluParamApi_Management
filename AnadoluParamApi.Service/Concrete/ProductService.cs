using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Data.UnitOfWork.Abstract;
using AnadoluParamApi.Dto.Dtos;
using AnadoluParamApi.Service.Abstract;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AnadoluParamApi.Service.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetDefaultProducts()
        {
            var productList = await _unitOfWork.ProductRepository.GetFilteredFirstOrDefaults(x => new ProductDto
            {
                ProductName = x.ProductName,
                Description = x.Description,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                Status = x.Status,
                SubCategoryId = x.SubCategoryId,
                SubCategoryName = x.SubCategory.SubCategoryName,
                UnitType = x.UnitType
            },
            expression: x => x.Status != Base.Types.Status.Deleted);

            return productList;
        }

        public async Task<UpdateProductDto> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetFilteredFirstOrDefault(selector: x => new UpdateProductDto
            {
                ID = x.ID,
                ProductName = x.ProductName,
                Description = x.Description,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitType = x.UnitType,
                SubCategoryId = x.SubCategoryId,
                SubCategoryName = x.SubCategory.SubCategoryName
            },
            expression: x => x.ID == id);

            //var model = _mapper.Map<UpdateProductDto>(product);

            return product;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var productList = await _unitOfWork.ProductRepository.GetFilteredFirstOrDefaults(x => new ProductDto
            {
                ProductName = x.ProductName,
                Description = x.Description,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitType = x.UnitType,
                SubCategoryId = x.SubCategoryId,
                SubCategoryName = x.SubCategory.SubCategoryName,
                Status = x.Status
            },
            expression: x => x.Status == Base.Types.Status.Active || x.Status == Base.Types.Status.Updated || x.Status == Base.Types.Status.Deleted);

            return productList;
        }

        public async Task<List<ProductDto>> GetProductsByCategory(int subCategoryId)
        {
            var productList = await _unitOfWork.ProductRepository.GetFilteredFirstOrDefaults(x => new ProductDto
            {
                ProductName = x.ProductName,
                Description = x.Description,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitType = x.UnitType,
                SubCategoryId = x.SubCategoryId,
                SubCategoryName = x.SubCategory.SubCategoryName,
                Status = x.Status
            },
            expression: x => x.SubCategoryId == subCategoryId && x.Status != Base.Types.Status.Deleted,
            orderBy: x => x.OrderBy(z => z.UnitPrice)
            );

            return productList;
        }

        public async Task<string> InsertProduct(ProductDto model)
        {
            var product = _mapper.Map<Product>(model);

            var result = await _unitOfWork.ProductRepository.Any(x => x.ProductName == product.ProductName); //Check db control product exist ??
            if (result)
                return "This Product already exists";

            var subCategpryExist = await _unitOfWork.SubCategoryRepository.Any(x => x.ID == product.SubCategoryId); //Category control
            if (!subCategpryExist)
                return "The Subcategory you want to add was not found!";

            await _unitOfWork.ProductRepository.InsertAsync(product);
            await _unitOfWork.CompleteAsync();
            return "Product added!";
        }

        public async Task<string> RemoveProduct(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
                return "Product not found!";

            await _unitOfWork.ProductRepository.DeleteAsync(product);
            await _unitOfWork.CompleteAsync();

            return "Product deleted!";
        }

        public async Task<string> UpdateProduct(UpdateProductDto model)
        {
            var updated = _mapper.Map<Product>(model);
            var updatedExist = await _unitOfWork.ProductRepository.Any(x => x.ID == updated.ID);

            if (!updatedExist)
                return "Product not found!";

            var subCategpryExist = await _unitOfWork.SubCategoryRepository.Any(x => x.ID == updated.SubCategoryId); //Category control
            if (!subCategpryExist)
                return "The Subcategory you want to add was not found!";

            updated.Status = Base.Types.Status.Updated;
            updated.UpdatedDate = DateTime.Now;

            _unitOfWork.ProductRepository.Update(updated);
            await _unitOfWork.CompleteAsync();

            return "Product updated!";
        }
    }
}
