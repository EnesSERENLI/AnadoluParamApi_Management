using AnadoluParamApi.Dto.Dtos;
using AnadoluParamApi.Dto.VMs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;

namespace AnadoluParamApi.Service.Abstract
{
    public interface IBasketService
    {
        Task<string> AddToBasketAsync(ISession session, int productId, int accountId, short quantity);

        Task<string> ComplateBasketAsync(List<CartItem> cartItems);

        Task<bool> UpdateOrderItemQuantityAsync(CartItem cartItem,short quantity);

        Task<List<OrderVM>> GetMyOrders(int accountId);
    }
}
