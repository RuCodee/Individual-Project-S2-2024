using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PatientMedicalRecord
    {
        public int RecordId { get; set; }
        public int PatientId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
