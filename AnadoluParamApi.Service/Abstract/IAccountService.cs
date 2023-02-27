using AnadoluParamApi.Dto.Dtos;

namespace AnadoluParamApi.Service.Abstract
{
    public interface IAccountService
    {
        Task<string> Register(AccountDto model);
        Task LogOut();
        Task<UpdateAccountDto> GetByIdAccountAsync(int id);
        Task<AccountDto> GetAccountByUserNameAsync(string userName);
        Task<List<AccountDto>> GetAllAccountsAsync();
    }
}
