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

        public async Task<Doctor> GetDoctorById(int doctorId)
        {
            Doctor doctor = null;
            using (var connection = DBHelper.OpenConnection())
            {
                var command = new SqlCommand(@"
            SELECT UserId, SpecializationId, DoctorJobId, ClinicCity, ClinicAddress, ClinicPCode, ClinicPhone, ClinicEmail
            FROM Doctors
            WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", doctorId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        doctor = new Doctor
                        {
                            Id = doctorId,
                            DoctorJobId = reader["DoctorJobId"].ToString(),
                            Specialization = (Specialization)reader.GetInt32(reader.GetOrdinal("SpecializationId")),
                            ClinicCity = reader["ClinicCity"].ToString(),
                            ClinicAddress = reader["ClinicAddress"].ToString(),
                            ClinicPCode = reader["ClinicPCode"].ToString(),
                            ClinicPhone = reader["ClinicPhone"].ToString(),
                            ClinicEmail = reader["ClinicEmail"].ToString()
                        };
                    }
                }
            }
            return doctor;
        }

        public void UpdateDoctor(Doctor doctor)
        {

        }

        public void DeleteDoctor(int doctorId)
        {

        }
    }
}
