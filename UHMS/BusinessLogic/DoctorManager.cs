using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccessLayer;

namespace BusinessLogic
{
    public class DoctorManager
    {
        private readonly DoctorDAL _doctorDAL;

        public DoctorManager(DoctorDAL doctorDAL)
        {
            _doctorDAL = doctorDAL;
        }

        public async Task AddDoctor(Doctor doctor)
        {
            await _doctorDAL.CreateDoctor(doctor);
        }

        public void UpdateMedicalRecord(int patientId, int recordId, MedicalRecord updatedRecord)
        {
            // implement medical record update logic for a doctor
        }
    }
}
