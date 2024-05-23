using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccessLayer;
using Microsoft.Data.SqlClient;

namespace BusinessLogic
{
    public class MedicalRecordManager
    {
        private MedicalRecordDAL _medicalRecordDal;

        public MedicalRecordManager()
        {
            _medicalRecordDal = new MedicalRecordDAL();
        }

        public async Task<int> AddPrescriptionMedicalRecord(PrescriptionMedicalRecord record)
        {
            int resultId = 0;
            try
            {
                using (var connection = DBHelper.OpenConnection())
                {
                    var query = @"
                INSERT INTO PrescriptionMedicalRecords
                (PatientId, IssuedDoctorId, Symptoms, Diagnosis, PrescribedMedicines, MedicationNotes, GeneralNotes, VisitType)
                VALUES
                (@PatientId, @IssuedDoctorId, @Symptoms, @Diagnosis, @PrescribedMedicines, @MedicationNotes, @GeneralNotes, @VisitType);
                SELECT CAST(SCOPE_IDENTITY() as int)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientId", record.PatientId);
                        command.Parameters.AddWithValue("@IssuedDoctorId", record.DoctorId);
                        command.Parameters.AddWithValue("@Symptoms", record.Symptoms);
                        command.Parameters.AddWithValue("@Diagnosis", record.Diagnosis);
                        command.Parameters.AddWithValue("@PrescribedMedicines", record.PrescribedMedicines);
                        command.Parameters.AddWithValue("@MedicationNotes", record.MedicationNotes);
                        command.Parameters.AddWithValue("@GeneralNotes", record.GeneralNotes);
                        command.Parameters.AddWithValue("@VisitType", record.VisitType);

                        resultId = (int)await command.ExecuteScalarAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to add medical record: " + ex.Message);
                throw;
            }
            return resultId;
        }


        //ViewMedicalRecord form

        public async Task<List<PrescriptionMedicalRecord>> GetAllPrescriptionRecordsByUserId(int userId)
        {
            return await _medicalRecordDal.GetAllPrescriptionRecords(userId);
        }

        //END ViewMedicalRecord form

        //Filtering for Medical Records (Visit Date - Visit Type - Doctor Name - Symptoms - Diagnosis)

        public async Task<List<PrescriptionMedicalRecord>> GetFilteredPrescriptionRecords(int userId, string visitDate, string visitType, string doctorName, string symptoms, string diagnosis)
        {
            return await _medicalRecordDal.GetFilteredPrescriptionRecords(userId, visitDate, visitType, doctorName, symptoms, diagnosis);
        }

        //END Filtering for Medical Records (Visit Date - Visit Type - Doctor Name - Symptoms - Diagnosis)




        /* 
         * 
         * Before abstract is created

        public void CreateMedicalRecord(MedicalRecord medicalRecord)
        {

        }

        public MedicalRecord? GetMedicalRecord(int recordId)
        {
            // logic to retrieve a medical record
            return null;
        }

        public void UpdateMedicalRecord(int recordId, MedicalRecord updatedRecord)
        {

        }

        public List<MedicalRecord> GetPatientMedicalRecords(int patientId)
        {
            // logic to retrieve all medical records for a patient
            return new List<MedicalRecord>();
        }

        END before abstract is created
        *
        *
        */
    }
}
