using DataAccessLayer;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApp.Pages
{
    public class DoctorsModel : PageModel
    {
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();

        public async Task OnGetAsync(string doctorName, string specialization, string city, string postalCode)
        {
            Doctors = new List<Doctor>(); // Ensure the list is initialized

            try
            {
                using (var connection = DBHelper.OpenConnection())
                {
                    var sqlQuery = @"
            SELECT u.*, d.SpecializationId, d.DoctorJobId, s.Name as SpecializationName
            FROM Users u 
            INNER JOIN Doctors d ON u.UserId = d.UserId 
            INNER JOIN Specializations s ON d.SpecializationId = s.SpecializationId
            WHERE u.RoleId = @DoctorRoleId";

                    var parameters = new List<SqlParameter>
            {
                new SqlParameter("@DoctorRoleId", SqlDbType.Int) { Value = (int)Role.Doctor }
            };

                    if (!string.IsNullOrEmpty(doctorName))
                    {
                        sqlQuery += " AND (u.FirstName + ' ' + u.LastName LIKE @DoctorName)";
                        parameters.Add(new SqlParameter("@DoctorName", SqlDbType.NVarChar) { Value = $"%{doctorName}%" });
                    }
                    if (!string.IsNullOrEmpty(specialization))
                    {
                        sqlQuery += " AND s.Name LIKE @SpecializationName";
                        parameters.Add(new SqlParameter("@SpecializationName", SqlDbType.NVarChar) { Value = $"%{specialization}%" });
                    }
                    if (!string.IsNullOrEmpty(city))
                    {
                        sqlQuery += " AND u.City = @City";
                        parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar) { Value = city });
                    }
                    if (!string.IsNullOrEmpty(postalCode))
                    {
                        sqlQuery += " AND u.PostalCode = @PostalCode";
                        parameters.Add(new SqlParameter("@PostalCode", SqlDbType.NVarChar) { Value = postalCode });
                    }

                    using (var command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddRange(parameters.ToArray());

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