using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /*public class MedicalRecord
    {
        public int RecordId { get; set; }
        public int PatientId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime VisitDate { get; set; }
        public VisitType VisitType { get; set; }
        public string? Symptoms { get; set; }
        public string? Diagnosis { get; set; }
        public List<Medication>? Medications { get; set; }
        public string? MedicationNote { get; set; }
        public string? Note { get; set; }
    }*/

    public abstract class MedicalRecord
    {
        public int RecordId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime VisitDate { get; set; } = DateTime.Now;
        public string Notes { get; set; }
        public string GeneralNotes { get; set; }

        public abstract void Validate();
    }

    public class PrescriptionMedicalRecord : MedicalRecord
    {
        public string VisitType { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string PrescribedMedicines { get; set; }
        public string MedicationNotes { get; set; }

        public string DoctorName { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(PrescribedMedicines))
                throw new ArgumentException("Prescribed medicines cannot be empty.");
        }
    }
}
