using AnadoluParamApi.Base.Extensions;
using AnadoluParamApi.Dto.Dtos;
using AnadoluParamApi.Service.Abstract;
using AnadoluParamApi.Service.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Claims;

namespace AnadoluParamApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;

        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        [HttpGet]
        public IActionResult MyBasket()
        {
            var cart = SessionHelper.GetProductJson<List<CartItem>>(HttpContext.Session, $"scart");
            if (cart != null)
                return Ok(cart);
            return Ok("You do not have any products in your cart.");
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(int productId,short quantity)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized("In order to create a basket, you need to log in to the system.");

            string accountId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            if (string.IsNullOrEmpty(accountId))
                return Unauthorized("In order to create a basket, you need to log in to the system.");

            int userId = int.Parse(accountId);
            var result = await basketService.AddToBasketAsync(HttpContext.Session, productId, userId, quantity);
            return Ok(result);
        }

        /// <summary>
        /// Confirm your basket. 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ConfirmCart()
        {
            var cartItemList = SessionHelper.GetProductJson<List<CartItem>>(HttpContext.Session, $"scart");
            if (cartItemList == null)
                return Ok("You do not have any products in your cart.");

            var result = basketService.ComplateBasketAsync(cartItemList);
            if (result.Result.ToString() == "Your cart has been confirmed")
            {
                HttpContext.Session.Remove($"scart");
                return Ok(result.Result);
            }
            
            return Ok(result); //An error message will appear here.
        }

        /// <summary>
        /// Updates the number of the specified item in your cart.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="newQuantity"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> MyOrderItemQuantity(int productId,short newQuantity)
        {
            var cartItemList = HttpContext.Session.GetProductJson<List<CartItem>>($"scart");
            if (cartItemList == null)
                return Ok("There are no items in your cart");

            CartItem cartItem = cartItemList.Where(x => x.ProductId == productId).FirstOrDefault();
            if (cartItem == null)
                return BadRequest("You do not have this product in your cart.");

            var result = await basketService.UpdateOrderItemQuantityAsync(cartItem,newQuantity);
            if (!result)
                return BadRequest("Your order quantity cannot exceed the stock quantity.");

            cartItem.Quantity = newQuantity;
            SessionHelper.SetProductJson(HttpContext.Session, $"scart", cartItemList);
            return Ok("Your cart has been updated.");
        }

        /// <summary>
        /// Deletes the specified product from the cart.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderItem(int productId)
        {
            var cartItemList = HttpContext.Session.GetProductJson<List<CartItem>>($"scart");
            if (cartItemList == null)
                return Ok("There are no items in your cart");

            CartItem cartItem = cartItemList.Where(x => x.ProductId == productId).FirstOrDefault();
            if (cartItem == null)
                return BadRequest("You do not have this product in your cart.");

            cartItemList.Remove(cartItem);
            SessionHelper.SetProductJson(HttpContext.Session, $"scart", cartItemList);
            return Ok("The order item has been deleted from your cart.");
        }

        /// <summary>
        /// Deletes the whole basket.
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> ClearBasket()
        {
            var cartItemList = HttpContext.Session.GetProductJson<List<CartItem>>($"scart");
            if (cartItemList == null)
                return Ok("There are no items in your cart");

            HttpContext.Session.Remove($"scart");
            return Ok("Your cart has been emptied.");
        }
    }
}
