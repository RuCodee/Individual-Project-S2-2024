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

        public List<MedicalRecord> GetMedicalRecordsByPatientId(int patientId)
        {
            return new List<MedicalRecord>();
        }
    }
}
