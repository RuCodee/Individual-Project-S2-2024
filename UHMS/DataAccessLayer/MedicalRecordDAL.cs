using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class MedicalRecordDAL
    {
/*
        public MedicalRecord? GetMedicalRecordById(int recordId)
        {
            
        }

        private List<Medication> GetMedicationsForRecord(int patientId, SqlConnection connection)
        {
          
        }
*/

        public void UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            // update an existing medical record
        }

        public void DeleteMedicalRecord(int recordId)
        {
            // delete a medical record by its ID
        }

        public List<MedicalRecord> GetMedicalRecordsByPatientId(int patientId)
        {
            // retrieve all medical records for a given patient
            return new List<MedicalRecord>();
        }
    }
}
