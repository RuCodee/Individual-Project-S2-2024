using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class DoctorDAL
    {
        public async Task CreateDoctor(Doctor doctor)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                var query = @"
            INSERT INTO Doctors (UserId, SpecializationId, DoctorJobId)
            VALUES (@UserId, @SpecializationId, @DoctorJobId);";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", doctor.Id);
                    command.Parameters.AddWithValue("@SpecializationId", doctor.Specialization);
                    command.Parameters.AddWithValue("@DoctorJobId", doctor.DoctorJobId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public Doctor? GetDoctorById(int doctorId)
        {
            // retrieve a doctor by their ID
            return null;
        }

        public void UpdateDoctor(Doctor doctor)
        {
            // update an existing doctor's details
        }

        public void DeleteDoctor(int doctorId)
        {
            // delete a doctor by their ID
        }
    }
}
