namespace AnadoluParamApi.Dto.Dtos
{
    public class Cart
    {
        Dictionary<int, CartItem> _myCart = new Dictionary<int, CartItem>();//int accountid and cartitem..

        public List<CartItem> myCart { get => _myCart.Values.ToList(); }

        public void AddItem(CartItem cartItem)
        {
            if (_myCart.ContainsKey(cartItem.ProductId))
            {
                _myCart[cartItem.ProductId].Quantity += cartItem.Quantity;
                return;
            }
            _myCart.Add(cartItem.ProductId, cartItem);
        }
    }
}
