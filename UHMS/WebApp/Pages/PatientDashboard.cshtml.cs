using DataAccessLayer;
using Domain;
using BusinessLogic;
using DataAccessLayer.UnitTestInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebApp.Pages
{
    [Authorize(Roles = "Patient")]
    public class PatientDashboardModel : PageModel
    {
        private readonly IUserDAL _userDAL;

        public User User { get; set; }

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }

        public PatientDashboardModel(IUserDAL userDAL)
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