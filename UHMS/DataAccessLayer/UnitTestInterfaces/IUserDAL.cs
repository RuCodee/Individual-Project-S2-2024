using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitTestInterfaces
{
    public interface IUserDAL
    {
        Task<int> RegisterUserAsync(User user);
        Task<User> GetUserByIdentifierAsync(string identifier);
        Task<User> GetUserById(int userId);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        void UpdateUserPassword(int userId, string newPassword);
    }
}
