using System;
using Domain;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace DesktopApp
{
    public partial class PatientProfile : Form
    {
        private User currentDoctor;
        private string patientSSN;
        public PatientProfile(User doctor, string ssn)
        {
            InitializeComponent();
            currentDoctor = doctor;
            patientSSN = ssn;

            btnPrescribe.Click += btnPrescribe_Click;
            btnViewMedicalHistory.Click += btnViewMedicalHistory_Click;
            btnPrescribe.Click -= btnPrescribe_Click;
            btnViewMedicalHistory.Click -= btnViewMedicalHistory_Click;
        }

        private void btnPrescribe_Click(object sender, EventArgs e)
        {
            MedicalRecordManager medicalRecordManager = new MedicalRecordManager();

            PrescriptionMRecord prescriptionForm = new PrescriptionMRecord(currentDoctor, patientSSN, medicalRecordManager);
            prescriptionForm.Show();
        }

        private void btnViewMedicalHistory_Click(object sender, EventArgs e)
        {
            ViewMedicalRecord medicalRecordForm = new ViewMedicalRecord(patientSSN);
            medicalRecordForm.Show();
        }
    }
}
