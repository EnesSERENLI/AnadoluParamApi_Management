using AnadoluParamApi.Dto.Models;
using AnadoluParamApi.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AnadoluParamApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenManagementService tokenManagementService;

        public TokenController(ITokenManagementService tokenManagementService)
        {
            this.tokenManagementService = tokenManagementService;
        }

        [HttpPost()]
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
