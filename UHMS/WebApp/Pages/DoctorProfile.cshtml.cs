using DataAccessLayer;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;

namespace WebApp.Pages
{
    public class DoctorProfileModel : PageModel
    {
        private readonly ILogger<DoctorProfileModel> _logger;
        public Doctor DoctorDetails { get; set; }

        public DoctorProfileModel(ILogger<DoctorProfileModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync(int userId)
        {
            try
            {
                if (userId <= 0)
                {
                    return NotFound("Invalid user ID.");
                }

                DoctorDetails = await GetDoctorDetails(userId);
                if (DoctorDetails == null)
                {
                    _logger.LogWarning($"No doctor information found for user ID: {userId}");
                    return NotFound("Doctor information not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching doctor information for user ID: {userId}");
                return StatusCode(500, "An error occurred while fetching doctor information.");
            }
            return Page();
        }

        private async Task<Doctor> GetDoctorDetails(int userId)
        {
            Doctor doctor = null;
            using (var connection = DBHelper.OpenConnection())
            {
                var command = new SqlCommand(@"
            SELECT u.FirstName, u.LastName, u.DateOfBirth, u.GenderId, u.TelephoneNumber, u.SSN, u.EmailAddress, u.HomeAddress,
                   d.ClinicCity, d.ClinicAddress, d.ClinicPCode, d.ClinicPhone, d.ClinicEmail, d.SpecializationId
            FROM Users u
            JOIN Doctors d ON u.UserId = d.UserId
            WHERE u.UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", userId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var genderId = reader["GenderId"] != DBNull.Value ? (int)reader["GenderId"] : 0;
                        Gender gender = Gender.Other; // Default to 'Other'
                        if (Enum.IsDefined(typeof(Gender), genderId))
                        {
                            gender = (Gender)genderId;
                        }

                        var specId = reader.IsDBNull(reader.GetOrdinal("SpecializationId")) ? 0 : reader.GetInt32(reader.GetOrdinal("SpecializationId"));
                        Specialization specialization = Specialization.Other;
                        if (Enum.IsDefined(typeof(Specialization), specId))
                        {
                            specialization = (Specialization)specId;
                        }

                        doctor = new Doctor
                        {
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Gender = gender,
                            TelephoneNumber = reader["TelephoneNumber"].ToString(),
                            SSN = reader["SSN"].ToString(),
                            EmailAddress = reader["EmailAddress"].ToString(),
                            HomeAddress = reader["HomeAddress"].ToString(),
                            ClinicCity = reader["ClinicCity"].ToString(),
                            ClinicAddress = reader["ClinicAddress"].ToString(),
                            ClinicPCode = reader["ClinicPCode"].ToString(),
                            ClinicPhone = reader["ClinicPhone"].ToString(),
                            ClinicEmail = reader["ClinicEmail"].ToString(),
                            Specialization = specialization
                        };
                    }
                }
            }
            return doctor;
        }
    }
}