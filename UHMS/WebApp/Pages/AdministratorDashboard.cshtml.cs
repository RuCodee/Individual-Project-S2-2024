using DataAccessLayer;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace WebApp.Pages
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorDashboardModel : PageModel
    {
        private readonly UserDAL _userDAL;

        public User User { get; set; }

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }

        public AdministratorDashboardModel(UserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (UserId <= 0)
            {
                return NotFound("User ID is not provided.");
            }

            User = await _userDAL.GetUserById(UserId);

            if (User == null)
            {
                return NotFound($"No user found with ID {UserId}.");
            }

            return Page();
        }
    }
}