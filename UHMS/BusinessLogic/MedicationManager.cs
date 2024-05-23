using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataAccessLayer;

namespace BusinessLogic
{
    public class MedicationManager
    {
        public void AddMedication(Medication medication)
        {
            // medication addition logic
        }

        public Medication GetMedication(int medicationId)
        {
            // logic to retrieve a medication
            return null;
        }

        public void UpdateMedication(int medicationId, Medication updatedMedication)
        {
            // medication update logic
        }

        public void DeleteMedication(int medicationId)
        {
            // medication deletion logic
        }

        // Used in ViewMedicines.cs for doctors.
        private MedicationDAL medicationDal = new MedicationDAL();

        public async Task<List<Medication>> GetAllMedications()
        {
            return await medicationDal.GetAllMedications();
        }
        //END ViewMedicines.cs

        public void CheckForHealthAlerts(int patientId, Medication medication)
        {
            // logic to check for health alerts related to a medication
        }
    }
}
