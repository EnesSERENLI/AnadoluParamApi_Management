using AnadoluParamApi.Base.Response;
using AnadoluParamApi.Dto.Models;

namespace AnadoluParamApi.Service.Abstract
{
    public interface ITokenManagementService
    {
        Task<BaseResponse<TokenResponse>> GenerateTokensAsync(TokenRequest loginResource, DateTime now, string userAgent);
    }
}
