using System.ComponentModel.DataAnnotations;

namespace AnadoluParamApi.Dto.Dtos
{
    public class OrderDto
    {
        [Required(ErrorMessage = "AccountId cannot be empty.")]
        [Range(1, int.MaxValue, ErrorMessage = "AccountId must be greater than 0")]
        public int AccountId { get; set; }
    }
}
