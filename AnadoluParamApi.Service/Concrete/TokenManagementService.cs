using AnadoluParamApi.Base.Jwt;
using AnadoluParamApi.Base.Response;
using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Data.UnitOfWork.Abstract;
using AnadoluParamApi.Dto.Models;
using AnadoluParamApi.Service.Abstract;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AnadoluParamApi.Service.Concrete
{
    public class TokenManagementService : ITokenManagementService
    {
        private readonly IAccountService accountService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtConfig _jwtConfig;
        private readonly byte[] _secret;

        public TokenManagementService(IAccountService accountService, IMapper mapper, IUnitOfWork unitOfWork, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            this.accountService = accountService;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._jwtConfig = jwtConfig.CurrentValue;
            this._secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        }

        public async Task<BaseResponse<TokenResponse>> GenerateTokensAsync(TokenRequest tokenRequest, DateTime now, string userAgent)
        {
            try
            {
                var accountDto = await accountService.GetAccountByUserNameAsync(tokenRequest.UserName);
                if (accountDto is null)
                {
                    //todo: log at
                    return new BaseResponse<TokenResponse>("Invalid username or password.");
                }

                if (accountDto.Password != tokenRequest.Password)
                {
                    //todo: log at
                    return new BaseResponse<TokenResponse>("Invalid username or password.");
                }
                var account = _mapper.Map<Account>(accountDto);

                var token = GenerateAccessToken(account, now);

                account.LastActivity = DateTime.Now;
                _unitOfWork.AccountRepository.Update(account);
                await _unitOfWork.CompleteAsync();

                TokenResponse response = new TokenResponse
                {
                    AccessToken = token,
                    ExpireTime = now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                    Role = account.Role,
                    UserName = account.UserName
                };

                return new BaseResponse<TokenResponse>(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Token_Error");
                return new BaseResponse<TokenResponse>("Token_Error");
            }
        }

        private string GenerateAccessToken(Account account, DateTime now)
        {
            // Get claim value
            Claim[] claims = GetClaim(account);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                _jwtConfig.Issuer,
                shouldAddAudienceClaim ? _jwtConfig.Audience : string.Empty,
                claims,
                expires: now.AddMinutes(_jwtConfig.AccessTokenExpiration),//Token expiretime
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));//Encryption algorithm

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken); //CreateToken

            return accessToken;
        }

        private static Claim[] GetClaim(Account account)
        {
            var claims = new[] //User information to be embedded in the token
            {
                new Claim(ClaimTypes.NameIdentifier, account.ID.ToString()),
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.Role, account.Role),
                new Claim("AccountId", account.ID.ToString()),
                new Claim("LastActivity", account.LastActivity.Value.ToLongTimeString())
            };

            return claims;
        }
    }
}
