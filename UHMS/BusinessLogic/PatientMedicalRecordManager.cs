using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PatientMedicalRecordManager
    {
        private readonly PatientMedicalRecordDAL _patientMedicalRecordDAL;

        public PatientMedicalRecordManager(PatientMedicalRecordDAL patientMedicalRecordDAL)
        {
            _patientMedicalRecordDAL = patientMedicalRecordDAL;
        }

        public async Task<int> CreatePatientMedicalRecordAsync(int userId)
        {
            int recordId = await _patientMedicalRecordDAL.CreatePatientMedicalRecordAsync(userId);
            return recordId;
        }
    }
}