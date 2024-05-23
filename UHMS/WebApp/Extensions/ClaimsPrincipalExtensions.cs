using System.Security.Claims;

namespace WebApp.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetFirstName(this ClaimsPrincipal user)
        {
            return user.FindFirst("FirstName")?.Value;
        }

        public static string GetLastName(this ClaimsPrincipal user)
        {
            return user.FindFirst("LastName")?.Value;
        }
    }
}