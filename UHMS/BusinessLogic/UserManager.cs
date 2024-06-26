﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using DataAccessLayer;
using DataAccessLayer.UnitTestInterfaces;
using BCrypt.Net;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;


namespace BusinessLogic
{
    public class UserManager
    {
        private readonly IUserDAL _userDAL;
        private readonly ILogger<UserManager> _logger;

        public UserManager(IUserDAL userDAL, ILogger<UserManager> logger)
        {
            _userDAL = userDAL;
            _logger = logger;
        }

        public async Task<int> RegisterUserAsync(User user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Password))
                {
                    _logger.LogError("Password is null or empty.");
                    throw new ArgumentException("Password cannot be null or empty.");
                }

                //generate a salt
                string salt = BCrypt.Net.BCrypt.GenerateSalt();
                //hash with the salt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password + salt);
                //combine the salt and hashed
                user.Password = salt + ":" + hashedPassword;

                _logger.LogInformation($"Attempting to register user: {user.EmailAddress}");

                int userId = await _userDAL.RegisterUserAsync(user);

                if (userId == 0)
                {
                    _logger.LogWarning($"Registration failed: User not added to database. Email: {user.EmailAddress}");
                    throw new Exception("User registration failed. The operation did not modify any records.");
                }

                _logger.LogInformation($"User registered successfully with ID: {userId}");
                return userId;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, $"Database error during user registration. Email: {user.EmailAddress}");
                throw new Exception("User registration failed due to a database error.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unexpected error during user registration. Email: {user.EmailAddress}");
                throw;
            }
        }

        public async Task<User> LoginAsync(string identifier, string password)
        {
            try
            {
                _logger.LogInformation($"Attempting to log in user: {identifier}");

                User user = await _userDAL.GetUserByIdentifierAsync(identifier);

                if (user != null)
                {
                    //split the stored password into salt and hash
                    var parts = user.Password.Split(':');
                    if (parts.Length != 2)
                    {
                        _logger.LogError("Stored password format is invalid.");
                        throw new Exception("Stored password format is invalid.");
                    }

                    var salt = parts[0];
                    var storedHash = parts[1];

                    //verify the provided password with the stored hash
                    bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(password + salt, storedHash);

                    if (isPasswordMatch)
                    {
                        _logger.LogInformation($"User logged in successfully: {user.Id}");
                        return user;
                    }
                    else
                    {
                        _logger.LogWarning($"Login failed for user: {identifier}");
                        return null;
                    }
                }
                else
                {
                    _logger.LogWarning($"Login failed for user: {identifier}");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "A database error occurred during the login process.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred during the login process.");
                throw;
            }
        }

        public void UpdateUserProfile(int userId, User updatedUser)
        {
            try
            {
                _logger.LogInformation($"Updating user profile: {userId}");
                _userDAL.UpdateUser(updatedUser);
                _logger.LogInformation($"User profile updated successfully: {userId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update user profile: {userId}");
                throw new Exception("User profile update failed.", ex);
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                _logger.LogInformation($"Attempting to delete user: {userId}");
                _userDAL.DeleteUser(userId);
                _logger.LogInformation($"User deleted successfully: {userId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete user: {userId}");
                throw new Exception("User deletion failed.", ex);
            }
        }

        public async Task UpdateUserPassword(int userId, string newPassword)
        {
            //generate a salt
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            //hash the new password with the salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword + salt);
            string passwordHash = salt + ":" + hashedPassword;

            using (var connection = DBHelper.OpenConnection())
            {
                string updatePasswordSql = @"
                    UPDATE Users
                    SET Password = @NewPassword
                    WHERE UserId = @UserId";

                using (var command = new SqlCommand(updatePasswordSql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@NewPassword", passwordHash);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}