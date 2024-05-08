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

namespace DesktopApp
{
    public partial class PatientSearchBox : Form
    {
        private User currentDoctor;
        private string patientSSN;

        public PatientSearchBox(User doctor, string ssn)
        {
            InitializeComponent();
            currentDoctor = doctor;
            patientSSN = ssn;
            btnAccess.Click += BtnAccess_Click;
            btnAccess.Click -= BtnAccess_Click;
        }

        private void BtnAccess_Click(object sender, EventArgs e)
        {
            PatientProfile patientProfileForm = new PatientProfile(currentDoctor, patientSSN);
            patientProfileForm.Show();
            this.Hide();
        }
    }
}
