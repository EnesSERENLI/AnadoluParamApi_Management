using AnadoluParamApi.Data.UnitOfWork.Abstract;
using AnadoluParamApi.Dto.Dtos;
using AnadoluParamApi.Service.Abstract;
using AutoMapper;

namespace AnadoluParamApi.Service.Concrete
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AccountDto> GetAccountByUserNameAsync(string userName)
        {
            var account = await _unitOfWork.AccountRepository.GetByDefault(x => x.UserName == userName);
            if (account == null)
                return null;

            var accountDto = _mapper.Map<AccountDto>(account);
            return accountDto;
        }

        public async Task<List<AccountDto>> GetAllAccountsAsync()
        {
            var accountList = await _unitOfWork.AccountRepository.GetFilteredFirstOrDefaults(x => new AccountDto
            {
                UserName = x.UserName,
                Email = x.Email,
                Name = x.Name,
                Surname = x.Surname,
                Role = x.Role,
                Gender = x.Gender,
                Status = x.Status
            },
            expression: x => x.Status == Base.Types.Status.Active || x.Status == Base.Types.Status.Updated || x.Status == Base.Types.Status.Deleted);

            return accountList;
        }

        public async Task<UpdateAccountDto> GetByIdAccountAsync(int id)
        {
            var account = await _unitOfWork.AccountRepository.GetByDefault(x => x.ID == id);
            if (account == null)
                return null;

            var updateAccountDto = _mapper.Map<UpdateAccountDto>(account);
            return updateAccountDto;
        }

        public Task LogOut() //todo:Token işlemleri yapılırken yazılacak
        {
            throw new NotImplementedException();
        }

        public Task<string> Register(AccountDto model) //Token işlemleri yapılırken yazılacak
        {
            throw new NotImplementedException();
        }
    }
}
