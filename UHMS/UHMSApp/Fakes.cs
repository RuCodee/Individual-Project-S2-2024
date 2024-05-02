using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccessLayer.UnitTestInterfaces;

namespace UHMSApp
{
        public class FakeUserDAL : IUserDAL
        {
            public Task<int> RegisterUserAsync(User user)
            {
                return Task.FromResult(1);
            }

            public Task<User> GetUserByIdentifierAsync(string identifier)
            {
                return Task.FromResult(new User
                {
                    Id = 1,
                    EmailAddress = identifier,
                    FirstName = "Pen",
                    LastName = "Blue",
                    DateOfBirth = new System.DateTime(1985, 4, 12),
                    Gender = Gender.Male,
                    SSN = identifier,
                    Role = Role.Patient
                });
            }

            public Task<User> GetUserById(int userId)
            {
                return Task.FromResult(new User
                {
                    Id = userId,
                    FirstName = "Test",
                    LastName = "User",
                    DateOfBirth = new System.DateTime(1990, 1, 1),
                    Gender = Gender.Female,
                    SSN = "123456789",
                    Role = Role.Doctor
                });
            }

            public void UpdateUser(User user)
            {
            }

            public void DeleteUser(int userId)
            {
            }

            public void UpdateUserPassword(int userId, string newPassword)
            {
            }
        }
}