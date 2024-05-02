using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccessLayer;

namespace BusinessLogic
{
    public class MedicalRecordManager
    {
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
    }
}
