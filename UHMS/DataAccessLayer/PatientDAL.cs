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
                SELECT FirstName + ' ' + LastName AS FullName
                FROM Users
                WHERE SSN = @SSN";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SSN", ssn);
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            _logger.LogInformation($"Found patient name {result.ToString()} for SSN {ssn}.");
                            return result.ToString(); //Full name as a string
                        }
                        else
                        {
                            _logger.LogWarning($"No patient found for SSN {ssn}.");
                            return null; //No patient found
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching patient name by SSN: {ssn}. Error: {ex.Message}");
                return null; // Error condition
            }
        }
        //END SearchPatients *********

        //Another method to recognize the patient in PrescriptionMRecord desktop

        public int GetPatientIdBySSN(string ssn)
        {
            try
            {
                using (var connection = DBHelper.OpenConnection())
                {
                    var query = @"SELECT UserId FROM Users WHERE SSN = @SSN";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SSN", ssn);
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching patient ID by SSN: {ssn}. Error: {ex.Message}");
            }
            return 0; //Not found
        }

        //END PrescriptionMRecord

        //ViewMedicalRecord form

        public async Task<int> GetUserIdBySSN(string ssn)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                var query = @"
            SELECT UserId
            FROM Users
            WHERE SSN = @SSN";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SSN", ssn);
                    var result = await command.ExecuteScalarAsync();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        // No user is found with the given SSN
                        return -1; //Throw new Exception("No user found with the specified SSN.");
                    }
                }
            }
        }

        //END ViewMedicalRecord form

    }
}