using AnadoluParamApi.Data.Context;
using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Data.Repository.Abstract.EntityTypeRepository;
using AnadoluParamApi.Data.Repository.Concrete.BaseRepository;

namespace AnadoluParamApi.Data.Repository.Concrete.EntityTypeRepository
{
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
