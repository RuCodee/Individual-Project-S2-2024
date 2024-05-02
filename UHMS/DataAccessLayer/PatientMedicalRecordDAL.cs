using Microsoft.Data.SqlClient;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PatientMedicalRecordDAL
    {
        public async Task<int> CreatePatientMedicalRecordAsync(int userId)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                var command = new SqlCommand(
                    "INSERT INTO PatientMedicalRecords (UserId, DateCreated) VALUES (@UserId, @DateCreated); SELECT CAST(SCOPE_IDENTITY() as int);",
                    connection
                );

                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@DateCreated", DateTime.UtcNow);

                var result = await command.ExecuteScalarAsync();

                if (result != null && int.TryParse(result.ToString(), out int recordId))
                {
                    return recordId;
                }
                else
                {
                    throw new Exception("Failed to create PatientMedicalRecord.");
                }
            }
        }
    }
}