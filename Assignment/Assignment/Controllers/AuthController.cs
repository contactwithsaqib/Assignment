using Assignment.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

      
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

     

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var userExists = await _userManager.FindByEmailAsync(model.Email);
                if (userExists != null)
                    return BadRequest(new { message = "Email is already taken." });

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok(new { message = "Registration successful!" });
                }
                else
                {
                    return BadRequest(new { message = string.Join(", ", result.Errors.Select(e => e.Description)) });
                }
            }

            return BadRequest(new { message = "Invalid data." });
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok(new { message = "Login successful" });
            }

            return Unauthorized(new { message = "Invalid credentials" });
        }
    }

    public class RegisterDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9_]*$")]
        public string DomainName { get; set; } = string.Empty;
    }
}
