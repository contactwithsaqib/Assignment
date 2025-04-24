using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(10, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Only alphanumeric and underscore allowed.")]
        public string DomainName { get; set; } = string.Empty;
    }
}
