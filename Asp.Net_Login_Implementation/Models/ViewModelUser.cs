using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Login_Implementation.Models
{
    public class ViewModelUser
    {
        [Required(ErrorMessage = "User name is required.")]
        [StringLength(100, ErrorMessage = "User name cannot be longer than 100 characters.")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
