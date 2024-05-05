using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace WebApp.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task OnGetAsync()
        {

            var prop = new AuthenticationProperties()
            {
                RedirectUri = "/Index"
            };
            // Clear the existing external cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, prop);

        }
    }
}
//check if mirroring on git is working