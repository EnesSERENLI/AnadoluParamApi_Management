using AnadoluParamApi.Base.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AnadoluParamApi.Dto.Dtos
{
    public class UpdateAccountDto
    {
        [Required(ErrorMessage = "The ID of the category to be updated cannot be left blank.")]
        [Range(1, int.MaxValue, ErrorMessage = "ID value must be greater than 0")]
        public int ID { get; set; }

        [Required(ErrorMessage = "UserName cannot be empty.")]
        [MaxLength(50, ErrorMessage = "UserName cannot be more than 50 characters.")]
        [UserNameAttribute]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be empty.")]
        [MaxLength(25, ErrorMessage = "Password cannot be more than 25 characters.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(100, ErrorMessage = "Name cannot be more than 100 characters.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(100, ErrorMessage = "Surname cannot be more than 100 characters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "EmailAddress cannot be empty.")]
        [EmailAddressAttribute(ErrorMessage = "Please enter an address in email format.")]
        [MaxLength(127, ErrorMessage = "Email cannot be more than 127 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Role cannot be empty.")]
        [RoleAttribute]
        public string Role { get; set; }

        [Required(AllowEmptyStrings = true)]
        [MaxLength(2, ErrorMessage = "Gender cannot be more than 2 characters.")]
        public string Gender { get; set; }

        [Display(Name = "Last Activity")]
        public DateTime LastActivity { get; set; }
    }
}
