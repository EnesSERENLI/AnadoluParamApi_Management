using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Dto.Dtos;

namespace AnadoluParamApi.Service.Abstract
{
    public interface IAccountService
    {
        Task<string> Register(AccountDto model);
        Task<UpdateAccountDto> GetByIdAccountAsync(int id);
        Task<Account> GetAccountByUserNameAsync(string userName);
        Task<List<AccountDto>> GetAllAccountsAsync();
    }
}
