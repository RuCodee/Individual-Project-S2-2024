using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Patient : User
    {
        public MedicalRecord? MedicalRecord { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<Allergy>? Allergies { get; set; }

        // Emergency Contact
        public string? ECFirstName { get; set; }
        public string? ECLastName { get; set; }
        public DateTime? ECDateOfBirth { get; set; }
        public string? ECGender { get; set; }
        public string? ECPhoneNumber { get; set; }
        public string? ECEmailAddress { get; set; }
        public string? ECSSN { get; set; }
        public string? ECRelationship { get; set; }
        public string? ECHomeAddress { get; set; }
        public string? ECPostCode { get; set; }

        // Parent Contact
        public string? PCFirstName { get; set; }
        public string? PCLastName { get; set; }
        public DateTime? PCDateOfBirth { get; set; }
        public string? PCGender { get; set; }
        public string? PCPhoneNumber { get; set; }
        public string? PCEmailAddress { get; set; }
        public string? PCSSN { get; set; }
        public string? PCRelationship { get; set; }
        public string? PCHomeAddress { get; set; }
        public string? PCPostCode { get; set; }
    }

    public enum Allergy
    {
        Penicillin = 1,
        Nuts = 2,
        Latex = 3,
        Pollen = 4,
        AnimalDander = 5
    }
}
