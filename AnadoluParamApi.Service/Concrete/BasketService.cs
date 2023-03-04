using AnadoluParamApi.Base.Extensions;
using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Data.UnitOfWork.Abstract;
using AnadoluParamApi.Data.UnitOfWork.Concrete;
using AnadoluParamApi.Dto.Dtos;
using AnadoluParamApi.Service.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;

namespace AnadoluParamApi.Service.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public BasketService(IUnitOfWork unitOfWork,IProductService productService,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.productService = productService;
            this.mapper = mapper;
        }

        public async Task<string> AddToBasketAsync(ISession session,int productId, int accountId, short quantity)
        {
            var product  = await productService.GetProductByIdAsync(productId);
            if (product == null)
                return "Product not found!";

            if (product.UnitsInStock < quantity)
                return "There is not enough stock for your order quantity.";

            

            var p = mapper.Map<Product>(product);
            var result = CreateCartItem(session, p, accountId, quantity);

            if (result)
            {
                await unitOfWork.CompleteAsync();
                return "The product has been added to your cart.";
            }

            return "An error occurred, please try again later!";
        }

        public async Task<string> ComplateBasketAsync(List<CartItem> cartItems)
        {
            var isStockEnough = await CheckStockIsEnough(cartItems); //If someone else bought the same product while there are products in the basket, the stock amount may have decreased.

            if (!isStockEnough)
                return "There are items in your cart that are more than stock.";

            #region Create an Order
            var orderdto = mapper.Map<OrderDto>(cartItems[0]);
            Order order = mapper.Map<Order>(orderdto);
            order.Status = Base.Types.Status.Active;
            order.CreatedDate = DateTime.Now;
            await unitOfWork.OrderRepository.InsertAsync(order);
            await unitOfWork.CompleteAsync();
            #endregion

            #region Create an OrderItem
            foreach (var cartItem in cartItems)
            {
                var orderDetailDto = mapper.Map<OrderDetailDto>(cartItem);
                orderDetailDto.Status = Base.Types.Status.Active;
                var product = await productService.GetProductByIdAsync(orderDetailDto.ProductId);

                product.UnitsInStock = (short)(product.UnitsInStock - orderDetailDto.Quantity);
                var p = mapper.Map<Product>(product);
                unitOfWork.ProductRepository.Update(p);
                orderDetailDto.OrderId = order.ID;

                var orderDetail = mapper.Map<OrderDetail>(orderDetailDto);
                await unitOfWork.OrderDetailRepository.InsertAsync(orderDetail);
            } 
            #endregion
            await unitOfWork.CompleteAsync();
            return "Your cart has been confirmed";
        }

        public async Task<bool> UpdateOrderItemQuantityAsync(CartItem cartItem,short quantity)
        {
            var product = await productService.GetProductByIdAsync(cartItem.ProductId);

            if (quantity > product.UnitsInStock)
                return false;

            return true;
        }

        private async Task<bool> CheckStockIsEnough(List<CartItem> cartItems)
        {
            foreach (var item in cartItems)
            {
                var product = await productService.GetProductByIdAsync(item.ProductId);
                if (product.UnitsInStock < item.Quantity)
                    return false;
            }
            return true;
        }

        private bool CreateCartItem(ISession session,Product product, int accountId, short quantity)
        {
            try
            {
                List<CartItem> cartItems = session.GetProductJson<List<CartItem>>($"scart");

                Cart c = new Cart();
                if (cartItems != null)
                {
                    foreach (CartItem cartItem in cartItems)
                    {
                        c.AddItem(cartItem);
                    }
                }

                CartItem ci = new CartItem();
                ci.AccountId = accountId;
                ci.ProductId = product.ID;
                ci.ProductName = product.ProductName;
                ci.Quantity = quantity;
                ci.UnitType = product.UnitType;
                ci.UnitPrice = product.UnitPrice;

                c.AddItem(ci);
                SessionHelper.SetProductJson(session, $"scart", c.myCart);

                return true;
            }
            catch (Exception ex)
            {
                //todo:log
                return false;
            }
        }
    }
}
