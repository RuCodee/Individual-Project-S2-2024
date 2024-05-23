using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace DataAccessLayer
{
    public class MedicalRecordDAL
    {
        // Method to insert a new prescription medical record into the database
        public async Task<int> CreatePrescriptionMedicalRecord(PrescriptionMedicalRecord record)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                var command = new SqlCommand(@"
                    INSERT INTO PrescriptionMedicalRecords
                    (PatientId, DoctorId, VisitDate, VisitType, Symptoms, Diagnosis, PrescribedMedicines, MedicationNotes, GeneralNotes)
                    VALUES (@PatientId, @DoctorId, @VisitDate, @VisitType, @Symptoms, @Diagnosis, @PrescribedMedicines, @MedicationNotes, @GeneralNotes);
                    SELECT CAST(SCOPE_IDENTITY() AS int);", connection);

                command.Parameters.AddWithValue("@PatientId", record.PatientId);
                command.Parameters.AddWithValue("@DoctorId", record.DoctorId);
                command.Parameters.AddWithValue("@VisitDate", DateTime.Now);
                command.Parameters.AddWithValue("@VisitType", record.VisitType);
                command.Parameters.AddWithValue("@Symptoms", record.Symptoms);
                command.Parameters.AddWithValue("@Diagnosis", record.Diagnosis);
                command.Parameters.AddWithValue("@PrescribedMedicines", record.PrescribedMedicines);
                command.Parameters.AddWithValue("@MedicationNotes", record.MedicationNotes);
                command.Parameters.AddWithValue("@GeneralNotes", record.GeneralNotes);

                int recordId = (int)await command.ExecuteScalarAsync();
                return recordId;
            }
        }


        //ViewMedicalRecord form

        public async Task<List<PrescriptionMedicalRecord>> GetAllPrescriptionRecords(int? userId = null)
        {
            var records = new List<PrescriptionMedicalRecord>();
            using (var connection = DBHelper.OpenConnection())
            {
                StringBuilder queryBuilder = new StringBuilder(@"
                    SELECT u.FirstName + ' ' + u.LastName AS DoctorName, pmr.VisitDate, pmr.Symptoms, 
                           pmr.Diagnosis, pmr.PrescribedMedicines, pmr.MedicationNotes, pmr.GeneralNotes, pmr.VisitType
                    FROM PrescriptionMedicalRecords pmr
                    JOIN Users u ON pmr.IssuedDoctorId = u.UserId");

                if (userId.HasValue)
                {
                    queryBuilder.Append(" WHERE pmr.PatientId = @UserId");
                }

                queryBuilder.Append(" ORDER BY pmr.VisitDate DESC");

                SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection);
                if (userId.HasValue)
                {
                    command.Parameters.AddWithValue("@UserId", userId.Value);
                }

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        records.Add(new PrescriptionMedicalRecord
                        {
                            DoctorName = reader.GetString(0),
                            VisitDate = reader.GetDateTime(1),
                            Symptoms = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Diagnosis = reader.IsDBNull(3) ? null : reader.GetString(3),
                            PrescribedMedicines = reader.IsDBNull(4) ? null : reader.GetString(4),
                            MedicationNotes = reader.IsDBNull(5) ? null : reader.GetString(5),
                            GeneralNotes = reader.IsDBNull(6) ? null : reader.GetString(6),
                            VisitType = reader.IsDBNull(7) ? null : reader.GetString(7)
                        });
                    }
                }
            }
            return records;
        }

        //END ViewMedicalRecord form

        //Filtering for Medical Records(Visit Date - Visit Type - Doctor Name - Symptoms - Diagnosis)

        public async Task<List<PrescriptionMedicalRecord>> GetFilteredPrescriptionRecords(int userId, string visitDate, string visitType, string doctorName, string symptoms, string diagnosis)
        {
            var records = new List<PrescriptionMedicalRecord>();
            using (var connection = DBHelper.OpenConnection())
            {
                StringBuilder queryBuilder = new StringBuilder(@"
                    SELECT u.FirstName + ' ' + u.LastName AS DoctorName, pmr.VisitDate, pmr.Symptoms, 
                           pmr.Diagnosis, pmr.PrescribedMedicines, pmr.MedicationNotes, pmr.GeneralNotes, pmr.VisitType
                    FROM PrescriptionMedicalRecords pmr
                    JOIN Users u ON pmr.IssuedDoctorId = u.UserId
                    WHERE pmr.PatientId = @UserId");

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@UserId", SqlDbType.Int) { Value = userId }
                };

                if (!string.IsNullOrEmpty(visitDate))
                {
                    if (DateTime.TryParse(visitDate, out DateTime parsedDate))
                    {
                        queryBuilder.Append(" AND CAST(pmr.VisitDate AS DATE) = @VisitDate");
                        parameters.Add(new SqlParameter("@VisitDate", SqlDbType.Date) { Value = parsedDate });
                    }
                    else if (int.TryParse(visitDate, out int year))
                    {
                        queryBuilder.Append(" AND YEAR(pmr.VisitDate) = @Year");
                        parameters.Add(new SqlParameter("@Year", SqlDbType.Int) { Value = year });
                    }
                }
                if (!string.IsNullOrEmpty(visitType))
                {
                    queryBuilder.Append(" AND pmr.VisitType LIKE @VisitType");
                    parameters.Add(new SqlParameter("@VisitType", SqlDbType.NVarChar) { Value = $"%{visitType}%" });
                }
                if (!string.IsNullOrEmpty(doctorName))
                {
                    queryBuilder.Append(" AND u.FirstName + ' ' + u.LastName LIKE @DoctorName");
                    parameters.Add(new SqlParameter("@DoctorName", SqlDbType.NVarChar) { Value = $"%{doctorName}%" });
                }
                if (!string.IsNullOrEmpty(symptoms))
                {
                    queryBuilder.Append(" AND pmr.Symptoms LIKE @Symptoms");
                    parameters.Add(new SqlParameter("@Symptoms", SqlDbType.NVarChar) { Value = $"%{symptoms}%" });
                }
                if (!string.IsNullOrEmpty(diagnosis))
                {
                    queryBuilder.Append(" AND pmr.Diagnosis LIKE @Diagnosis");
                    parameters.Add(new SqlParameter("@Diagnosis", SqlDbType.NVarChar) { Value = $"%{diagnosis}%" });
                }

                queryBuilder.Append(" ORDER BY pmr.VisitDate DESC");

                SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection);
                command.Parameters.AddRange(parameters.ToArray());

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        records.Add(new PrescriptionMedicalRecord
                        {
                            DoctorName = reader.GetString(0),
                            VisitDate = reader.GetDateTime(1),
                            Symptoms = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Diagnosis = reader.IsDBNull(3) ? null : reader.GetString(3),
                            PrescribedMedicines = reader.IsDBNull(4) ? null : reader.GetString(4),
                            MedicationNotes = reader.IsDBNull(5) ? null : reader.GetString(5),
                            GeneralNotes = reader.IsDBNull(6) ? null : reader.GetString(6),
                            VisitType = reader.IsDBNull(7) ? null : reader.GetString(7)
                        });
                    }
                }
            }
            return records;
        }

        //END Filtering for Medical Records (Visit Date - Visit Type - Doctor Name - Symptoms - Diagnosis)
    }

    //END ViewMedicalRecord form
    /*
            public MedicalRecord? GetMedicalRecordById(int recordId)
            {

            }

            private List<Medication> GetMedicationsForRecord(int patientId, SqlConnection connection)
            {

            }
    */
    /*
    public void UpdateMedicalRecord(MedicalRecord medicalRecord)
    {
        // update an existing medical record
    }

    public List<MedicalRecord> GetMedicalRecordsByPatientId(int patientId)
    {
        return new List<MedicalRecord>();
    }
    */
}
