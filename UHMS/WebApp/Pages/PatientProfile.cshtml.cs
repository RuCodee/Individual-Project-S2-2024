using DataAccessLayer;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;

namespace WebApp.Pages
{
    public class PatientProfileModel : PageModel
    {
        private readonly ILogger<PatientProfileModel> _logger;
        public Patient PatientDetails { get; set; }

        public PatientProfileModel(ILogger<PatientProfileModel> logger)
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

                PatientDetails = await GetPatientDetails(userId);
                if (PatientDetails == null)
                {
                    _logger.LogWarning($"No patient information found for user ID: {userId}");
                    return NotFound("Patient information not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching patient information for user ID: {userId}");
                return StatusCode(500, "An error occurred while fetching patient information.");
            }
            return Page();
        }

        private async Task<Patient> GetPatientDetails(int userId)
        {
            Patient patient = null;
            using (var connection = DBHelper.OpenConnection())
            {
                var command = new SqlCommand(@"
                    SELECT u.FirstName, u.LastName, u.DateOfBirth, u.GenderId, u.TelephoneNumber, u.SSN, u.EmailAddress, u.HomeAddress,
                           p.ECFirstName, p.ECLastName, p.ECDateOfBirth, p.ECGender, p.ECPhoneNumber, p.ECEmailAddress, p.ECSSN, p.ECRelationship, p.ECHomeAddress, p.ECPostCode,
                           p.PCFirstName, p.PCLastName, p.PCDateOfBirth, p.PCGender, p.PCPhoneNumber, p.PCEmailAddress, p.PCSSN, p.PCRelationship, p.PCHomeAddress, p.PCPostCode
                    FROM Users u
                    LEFT JOIN Patients p ON u.UserId = p.UserId
                    WHERE u.UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", userId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var genderId = reader["GenderId"] != DBNull.Value ? (int)reader["GenderId"] : 0;
                        Gender gender = Gender.Other;
                        if (Enum.IsDefined(typeof(Gender), genderId))
                        {
                            gender = (Gender)genderId;
                        }

                        patient = new Patient
                        {
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Gender = gender,
                            TelephoneNumber = reader["TelephoneNumber"].ToString(),
                            SSN = reader["SSN"].ToString(),
                            EmailAddress = reader["EmailAddress"].ToString(),
                            HomeAddress = reader["HomeAddress"].ToString(),
                            ECFirstName = reader["ECFirstName"]?.ToString(),
                            ECLastName = reader["ECLastName"]?.ToString(),
                            ECDateOfBirth = reader.IsDBNull(reader.GetOrdinal("ECDateOfBirth")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ECDateOfBirth")),
                            ECGender = reader["ECGender"]?.ToString(),
                            ECPhoneNumber = reader["ECPhoneNumber"]?.ToString(),
                            ECEmailAddress = reader["ECEmailAddress"]?.ToString(),
                            ECSSN = reader["ECSSN"]?.ToString(),
                            ECRelationship = reader["ECRelationship"]?.ToString(),
                            ECHomeAddress = reader["ECHomeAddress"]?.ToString(),
                            ECPostCode = reader["ECPostCode"]?.ToString(),
                            PCFirstName = reader["PCFirstName"]?.ToString(),
                            PCLastName = reader["PCLastName"]?.ToString(),
                            PCDateOfBirth = reader.IsDBNull(reader.GetOrdinal("PCDateOfBirth")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("PCDateOfBirth")),
                            PCGender = reader["PCGender"]?.ToString(),
                            PCPhoneNumber = reader["PCPhoneNumber"]?.ToString(),
                            PCEmailAddress = reader["PCEmailAddress"]?.ToString(),
                            PCSSN = reader["PCSSN"]?.ToString(),
                            PCRelationship = reader["PCRelationship"]?.ToString(),
                            PCHomeAddress = reader["PCHomeAddress"]?.ToString(),
                            PCPostCode = reader["PCPostCode"]?.ToString(),
                        };
                    }
                }
            }
            return patient;
        }
    }
}