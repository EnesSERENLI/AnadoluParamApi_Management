using AnadoluParamApi.Base.Attribute;
using System.ComponentModel.DataAnnotations;

namespace AnadoluParamApi.Dto.Dtos
{
    public class OrderDetailDto
    {
        [Required(ErrorMessage = "ProductId cannot be empty.")]
        [Range(1, int.MaxValue, ErrorMessage = "PruducyId must be greater than 0")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "OrderId cannot be empty.")]
        [Range(1, int.MaxValue, ErrorMessage = "OrderId must be greater than 0")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Quantity cannot be empty.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public short Quantity { get; set; }

        [Required(ErrorMessage = "UnitType cannot be empty.")]
        [UnitTypeAttribute]
        public string UnitType { get; set; }

        [Required(ErrorMessage = "UnitPrice cannot be empty.")]
        [Range(typeof(decimal), "1", "100000", ErrorMessage = "UnitPrice must be greater than 0")]
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get =>  UnitPrice * Quantity; }
    }
}
