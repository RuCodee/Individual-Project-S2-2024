using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class PrescriptionDAL
    {
        public void CreatePrescription(Prescription prescription)
        {
            // add a new prescription to the database
        }

        public Prescription GetPrescriptionById(int prescriptionId)
        {
            // retrieve a prescription by its ID
            return null;
        }

        public void UpdatePrescription(Prescription prescription)
        {
            // update an existing prescription
        }

        public void DeletePrescription(int prescriptionId)
        {
            // delete a prescription by its ID
        }

        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            // retrieve all prescriptions for a given patient
            return new List<Prescription>();
        }
    }
}
