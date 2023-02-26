using AnadoluParamApi.Data.Context;
using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Data.Repository.Abstract.EntityTypeRepository;
using AnadoluParamApi.Data.Repository.Concrete.BaseRepository;

namespace AnadoluParamApi.Data.Repository.Concrete.EntityTypeRepository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
