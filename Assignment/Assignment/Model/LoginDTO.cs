using System.ComponentModel.DataAnnotations;

namespace Assignment.Model
{
   public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters.")]
        public string Password { get; set; }

       
    }
}
