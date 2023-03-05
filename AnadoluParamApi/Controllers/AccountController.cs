using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Data.UnitOfWork.Concrete;
using AnadoluParamApi.Dto.Dtos;
using AnadoluParamApi.Dto.Models;
using AnadoluParamApi.Service.Abstract;
using AnadoluParamApi.Service.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AnadoluParamApi.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly ITokenManagementService tokenManagementService;
        public AccountController(IAccountService accountService, ITokenManagementService tokenManagementService)
        {
            this.accountService = accountService;
            this.tokenManagementService = tokenManagementService;
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

        [AllowAnonymous] //Everyone can request this endpoint..
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AccountDto account)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await accountService.Register(account);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] TokenRequest request)
        {
            var userAgent = Request.Headers["User-Agent"].ToString();
            var result = await tokenManagementService.GenerateTokensAsync(request, DateTime.UtcNow, userAgent);

            if (result.Success)
            {
                Log.Information($"User: {result.Response.UserName}, Role: {result.Response.Role} is logged in.");
                return Ok(result);
            }

            return Unauthorized();
        }

    }
}
