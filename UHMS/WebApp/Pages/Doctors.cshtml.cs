using DataAccessLayer;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApp.Pages
{
    public class DoctorsModel : PageModel
    {
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();

        public async Task OnGetAsync()
        {
            try
            {
                using (var connection = DBHelper.OpenConnection())
                {
                    var sqlQuery = @"
                SELECT u.*, d.SpecializationId, d.DoctorJobId 
                FROM Users u 
                INNER JOIN Doctors d ON u.UserId = d.UserId 
                WHERE u.RoleId = @DoctorRoleId";

                    using (var command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@DoctorRoleId", (int)Role.Doctor);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                var doctor = new Doctor
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                    DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                                    Gender = (Gender)reader.GetInt32(reader.GetOrdinal("GenderId")),
                                    TelephoneNumber = reader.GetString(reader.GetOrdinal("TelephoneNumber")),
                                    SSN = reader.GetString(reader.GetOrdinal("SSN")),
                                    EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress")),
                                    HomeAddress = reader.GetString(reader.GetOrdinal("HomeAddress")),
                                    Password = reader.GetString(reader.GetOrdinal("Password")),
                                    Specialization = (Specialization)reader.GetInt32(reader.GetOrdinal("SpecializationId")),
                                    DoctorJobId = reader.GetString(reader.GetOrdinal("DoctorJobId")),
                                };
                                Doctors.Add(doctor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}