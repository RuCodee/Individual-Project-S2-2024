using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer
{
    public class PatientDAL
    {
        private readonly ILogger<PatientDAL> _logger;

        public PatientDAL(ILogger<PatientDAL> logger)
        {
            _logger = logger;
        }

        public async Task<bool> UpdatePatient(Patient patient)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updatePatientSql = @"
                            UPDATE Patients
                            SET SSN = @SSN
                            WHERE UserId = @UserId;";
                        using (SqlCommand command = new SqlCommand(updatePatientSql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserId", patient.Id);
                            command.Parameters.AddWithValue("@SSN", patient.SSN);
                            int rowsAffected = await command.ExecuteNonQueryAsync();
                            transaction.Commit();
                            _logger.LogInformation($"Updated {rowsAffected} patient record for UserId: {patient.Id}");
                            return rowsAffected > 0;
                        }
                    }
                    catch (SqlException ex)
                    {
                        _logger.LogError($"SQL Error: {ex.Message}", ex);
                        transaction.Rollback();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"General Error: {ex.Message}", ex);
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        // Used for doctors to retrieve patients by their SSN (DesktopApp SearchPatients.cs).

        public string GetPatientNameBySSN(string ssn)
        {
            try
            {
                using (var connection = DBHelper.OpenConnection())
                {
                    var query = @"
                SELECT u.FirstName, u.LastName
                FROM Users u
                INNER JOIN Patients p ON p.UserId = u.UserId
                WHERE u.SSN = @SSN";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SSN", ssn);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string firstName = reader["FirstName"] as string;  // Get the first name from the Users table
                                string lastName = reader["LastName"] as string;    // Get the last name from the Users table
                                return $"{firstName} {lastName}".Trim();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching patient name by SSN: {ssn}. Error: {ex.Message}");
            }
            return null;
        }
        //END SearchPatients *********
    }
}