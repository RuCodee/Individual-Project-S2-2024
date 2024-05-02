using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MedicalRecord
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
    }
}
