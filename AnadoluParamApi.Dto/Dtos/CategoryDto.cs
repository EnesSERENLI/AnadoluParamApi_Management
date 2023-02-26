using AnadoluParamApi.Base.Types;
using System.ComponentModel.DataAnnotations;

namespace AnadoluParamApi.Dto.Dtos
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "CategoryName cannot be empty.")]
        [MaxLength(255,ErrorMessage = "CategoryName cannot be more than 255 characters.")]
        public string CategoryName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(1000,ErrorMessage = "Description cannot be more than 1000 characters.")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = true)]
        public Status Status { get; set; }
    }
}
