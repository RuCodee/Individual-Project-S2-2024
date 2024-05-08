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
using DataAccessLayer;
using Microsoft.Extensions.Logging;

namespace DesktopApp
{
    public partial class SearchPatients : Form
    {
        private User currentDoctor;
        private PatientDAL patientDal;
        private string foundPatientSSN;

        public SearchPatients(User doctor)
        {
            InitializeComponent();
            currentDoctor = doctor;
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
            ILogger<PatientDAL> logger = loggerFactory.CreateLogger<PatientDAL>();
            patientDal = new PatientDAL(logger);
            label3.Click += Label3_Click;
            label3.MouseEnter += Label3_MouseEnter;
            label3.MouseLeave += Label3_MouseLeave;
        }

    //Hover Effect
        private void Label3_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.ForeColor = Color.Blue;
                label.Font = new Font(label.Font, FontStyle.Underline);
                label.Cursor = Cursors.Hand;
            }
        }

        private void Label3_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.ForeColor = Color.Black;
                label.Font = new Font(label.Font, FontStyle.Regular);
                label.Cursor = Cursors.Default;
            }
        }
    //END Hover Effect ***

        private void Label3_Click(object sender, EventArgs e)
        {
            if (label3.Text != "Patient Name: Not found" && label3.Text != "Patient Name:")
            {
                if (!string.IsNullOrEmpty(foundPatientSSN))
                {
                    PatientSearchBox searchBox = new PatientSearchBox(currentDoctor, foundPatientSSN);
                    searchBox.Show();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string ssn = tbPatientsSSN.Text.Trim();
            if (string.IsNullOrWhiteSpace(ssn))
            {
                MessageBox.Show("Please enter a valid SSN.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string patientName = patientDal.GetPatientNameBySSN(ssn);
            if (!string.IsNullOrEmpty(patientName))
            {
                label3.Text = $"Patient Name: {patientName}";
                foundPatientSSN = ssn;  // Store the SSN for later use
            }
            else
            {
                MessageBox.Show("No patient found with the provided SSN.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label3.Text = "Patient Name: Not found";
                foundPatientSSN = null;  // Clear the stored SSN
            }
        }
    }
}
