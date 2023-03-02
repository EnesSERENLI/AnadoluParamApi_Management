using AnadoluParamApi.Base.Types;
using System.ComponentModel.DataAnnotations;

namespace AnadoluParamApi.Dto.Dtos
{
    public class SubCategoryDto
    {
        [Required(ErrorMessage = "SubCategoryName cannot be empty.")]
        [MaxLength(255,ErrorMessage = "SubCategoryName cannot be more than 255 characters.")]
        public string SubCategoryName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(1000,ErrorMessage = "Description cannot be more than 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "CategoryId cannot be empty.")]
        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than 0")]
        public int CategoryId { get; set; }

        [Required(AllowEmptyStrings = true)]
        public Status Status { get; set; }
    }
}
