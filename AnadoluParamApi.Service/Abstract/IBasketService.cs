using AnadoluParamApi.Dto.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;

namespace AnadoluParamApi.Service.Abstract
{
    public interface IBasketService
    {
        Task<string> AddToBasketAsync(ISession session, int productId, int accountId, short quantity);

        Task<string> ComplateBasketAsync(List<CartItem> cartItems);

        Task<bool> UpdateOrderItemQuantityAsync(CartItem cartItem,short quantity);
    }
}
