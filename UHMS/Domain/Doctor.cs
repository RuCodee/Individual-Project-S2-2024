using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Doctor : User
    {
        public string? DoctorJobId { get; set; }
        public Specialization Specialization { get; set; }
        public string? ClinicCity { get; set; }
        public string? ClinicAddress { get; set; }
        public string? ClinicPCode { get; set; }
        public string? ClinicPhone { get; set; }
        public string? ClinicEmail { get; set; }
    }

    public enum Specialization
    {
        Dentist = 1,
        EyeDoctor = 2,
        GeneralPractitioner = 3,
        Neurologist = 4,
        Cardiologist = 5,
        Oncologist = 6
    }
}
