using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Data.Repository.Abstract.EntityTypeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluParamApi.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        IProductRepository ProductRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }


        Task CompleteAsync();
    }
}
