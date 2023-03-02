using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Data.UnitOfWork.Concrete;
using AnadoluParamApi.Dto.Dtos;
using AnadoluParamApi.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AnadoluParamApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var account = await accountService.GetByIdAccountAsync(id);
            if (account is null)
                return NotFound("Account not found!");

            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AccountDto account)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await accountService.Register(account);
            return Ok(result);
        }

    }
}
