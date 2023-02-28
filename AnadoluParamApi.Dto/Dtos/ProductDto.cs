using AnadoluParamApi.Base.Attribute;
using AnadoluParamApi.Base.Types;
using System.ComponentModel.DataAnnotations;

namespace AnadoluParamApi.Dto.Dtos
{
    public class ProductDto
    {
        [Required(ErrorMessage = "ProductName cannot be empty.")]
        [MaxLength(255,ErrorMessage = "ProductName cannot be more than 255 characters.")]
        public string ProductName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(1000, ErrorMessage = "ProductName cannot be more than 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price cannot be empty.")]
        [Range(typeof(decimal), "1", "100000", ErrorMessage = "UnitPrice must be greater than 0")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Stock quantity cannot be empty.")]
        [Range(typeof(short), "1", "32000", ErrorMessage = "Stock quantity must be greater than 0")]
        public short UnitsInStock { get; set; }

        [Required(AllowEmptyStrings = true)]
        [UnitTypeAttribute]
        public string UnitType { get; set; }

        [Required(ErrorMessage = "SubCategory cannot be empty!")]
        [Range(1,int.MaxValue, ErrorMessage = "SubCategoryId must be greater than 0")]
        public int SubCategoryId { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string SubCategoryName { get; set; }

        [Required(AllowEmptyStrings = true)]
        public Status Status { get; set; }
    }
}
