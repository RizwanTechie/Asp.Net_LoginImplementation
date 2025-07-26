using Asp.Net_Login_Implementation.Models;
using Asp.Net_LoginImplementation.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace Asp.Net_LoginImplementation.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserLoginContext _context;
        public LoginModel(UserLoginContext context)
        {
            _context = context;
        }

        [BindProperty]
        public virtual ViewModelUser _ViewModelUser { get; set; }
        public string ErrorMessage { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var passwordHash = ComputeSha256Hash(_ViewModelUser.Password);   
            var user = await _context.UserLogins.FirstOrDefaultAsync(
                u => u.UserName == _ViewModelUser.UserName && u.PasswordHash == passwordHash
            );
            if (user == null)
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
            
            var claims= new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToPage("/Index");
        }

        private string ComputeSha256Hash(string pwd)
        {
            using var sha256 = SHA256.Create();
            byte[] btyes=sha256.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            return Convert.ToBase64String(btyes);
        }
    }
}


