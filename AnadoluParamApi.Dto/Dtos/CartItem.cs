using System.ComponentModel.DataAnnotations;

namespace AnadoluParamApi.Dto.Dtos
{
    public class CartItem
    {
        [Required(ErrorMessage = "ProductID cannot be empty!")]
        [Range(1,int.MaxValue,ErrorMessage = "ProductId must be greather than 0.")]
        public int ProductId { get; set; }
        [Required]
        public int AccountId { get; set; }
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please enter the quantity you want to buy.")]
        [Range(0,32000,ErrorMessage = "Order quantity should be between 1 and 100 pieces.")]
        public short Quantity { get; set; }
        public string UnitType { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? TotalPrice { get => UnitPrice * Quantity; }
    }
}
