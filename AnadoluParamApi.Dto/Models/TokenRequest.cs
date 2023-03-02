using AnadoluParamApi.Base.Attribute;
using System.ComponentModel.DataAnnotations;

namespace AnadoluParamApi.Dto.Models
{
    public class TokenRequest
    {
        [Required(ErrorMessage = "Please enter your username..")]
        [MaxLength(50,ErrorMessage = "UserName cannot be more than 50 characters.")]
        [UserNameAttribute]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password..")]
        [MaxLength(25, ErrorMessage = "Password cannot be more than 25 characters.")]
        public string Password { get; set; }
    }
}
