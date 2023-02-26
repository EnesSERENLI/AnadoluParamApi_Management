using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluParamApi.Dto.Dtos
{
    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "The ID of the category to be updated cannot be left blank.")]
        [Range(1, int.MaxValue, ErrorMessage = "ID value must be greater than 0")]
        public int ID { get; set; }

        [Required(ErrorMessage = "CategoryName cannot be empty.")]
        [MaxLength(255, ErrorMessage = "CategoryName cannot be more than 255 characters.")]
        public string CategoryName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(1000, ErrorMessage = "Description cannot be more than 1000 characters.")]
        public string Description { get; set; }
    }
}
