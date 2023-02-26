using AnadoluParamApi.Data.Context;
using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Data.Repository.Abstract.EntityTypeRepository;
using AnadoluParamApi.Data.Repository.Concrete.BaseRepository;

namespace AnadoluParamApi.Data.Repository.Concrete.EntityTypeRepository
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
