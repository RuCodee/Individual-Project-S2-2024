using DataAccessLayer;
using Domain;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserManager _userManager;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public LoginModel(UserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User user = await _userManager.LoginAsync(Username, Password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                string role = DetermineUserRole(Username);

                claims.Add(new Claim(ClaimTypes.Role, role));

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
    CookieAuthenticationDefaults.AuthenticationScheme,
    principal,
    new AuthenticationProperties { IsPersistent = true }
);

                return RedirectToProperDashboard(user);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }

        private string DetermineUserRole(string username)
        {
            if (username.StartsWith("D")) return nameof(Role.Doctor);
            if (username.StartsWith("A")) return nameof(Role.Administrator);
            if (char.IsDigit(username[0])) return nameof(Role.Patient);
            return string.Empty;
        }

        private IActionResult RedirectToProperDashboard(User user)
        {
            switch (user.Role)
            {
                case Role.Doctor:
                    return RedirectToPage("/DoctorDashboard", new { userId = user.Id });
                case Role.Administrator:
                    return RedirectToPage("/AdministratorDashboard", new { userId = user.Id });
                case Role.Patient:
                    return RedirectToPage("/PatientDashboard", new { userId = user.Id });
                default:
                    throw new Exception("The user role is not recognized.");
            }
        }
    }
}