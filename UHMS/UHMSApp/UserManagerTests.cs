using Microsoft.VisualStudio.TestTools.UnitTesting;
using UHMSApp;
using System.Threading.Tasks;
using Domain;
using BusinessLogic;
using Microsoft.Extensions.Logging.Abstractions;

namespace UHMSApp
{
    [TestClass]
    public class UserManagerTests
    {
        [TestMethod]
        public async Task RegisterUserAsync_UserIsRegistered_ReturnsUserId() //Register Users
        {
            var fakeUserDAL = new FakeUserDAL();
            var userManager = new UserManager(fakeUserDAL, new NullLogger<UserManager>());
            var user = new User { EmailAddress = "test@example.com", Password = "securePassword123" };

            int result = await userManager.RegisterUserAsync(user);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public async Task GetUserByIdentifier_ExistingIdentifier_ReturnsUser() //Login (retrieve a user by their identifier)
        {
            var fakeUserDAL = new FakeUserDAL();
            var userManager = new UserManager(fakeUserDAL, new NullLogger<UserManager>());
            var identifier = "test@example.com";


            User result = await userManager.LoginAsync(identifier, "securePassword123");

            Assert.IsNotNull(result);
            Assert.AreEqual(identifier, result.EmailAddress);
        }
    }
}