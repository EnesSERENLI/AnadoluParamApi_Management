using AnadoluParamApi.Data.Context;
using AnadoluParamApi.Data.Repository.Abstract.EntityTypeRepository;
using AnadoluParamApi.Data.Repository.Concrete.EntityTypeRepository;
using AnadoluParamApi.Data.UnitOfWork.Abstract;

namespace AnadoluParamApi.Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public bool disposed;

        public UnitOfWork(AppDbContext cotnext)
        {
            this.dbContext = cotnext;
            AccountRepository = new AccountRepository(dbContext);
            ProductRepository = new ProductRepository(dbContext);
            SubCategoryRepository = new SubCategoryRepository(dbContext);
            OrderDetailRepository = new OrderDetailRepositry(dbContext);
            OrderRepository = new OrderRepository(dbContext);
            CategoryRepository = new CategoryRepository(dbContext);
        }
        public IAccountRepository AccountRepository { get; private set;}

        public IProductRepository ProductRepository { get; private set;}

        public ISubCategoryRepository SubCategoryRepository { get; private set;}

        public ICategoryRepository CategoryRepository { get; private set;}

        public IOrderRepository OrderRepository { get; private set;}

        public IOrderDetailRepository OrderDetailRepository { get; private set;}

        public async Task CompleteAsync() //For SaveChanges... 
        {
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    // logging                    
                    dbContextTransaction.Rollback();
                }
            }
        }

        protected virtual void Clean(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }

    }
}
