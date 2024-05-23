using BusinessLogic;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace DesktopApp
{
    public partial class ViewMedicalRecord : Form
    {
        private string patientSSN;
        public ViewMedicalRecord(string ssn)
        {
            InitializeComponent();
            patientSSN = ssn;
            LoadMedicalRecords(ssn);
            ConfigureDataGridView();
        }

        private async void LoadMedicalRecords(string ssn)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            ILogger<PatientDAL> logger = loggerFactory.CreateLogger<PatientDAL>();
            var patientDal = new PatientDAL(logger);
            int userId = await patientDal.GetUserIdBySSN(ssn);

            if (userId == -1)
            {
                MessageBox.Show("No patient found with the given SSN.");
                return;
            }

            var medicalRecordManager = new MedicalRecordManager();
            var records = await medicalRecordManager.GetAllPrescriptionRecordsByUserId(userId);
            dataGridView1.DataSource = records;
        }

        private async Task<int> ResolveSSNToUserId(string ssn)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            ILogger<PatientDAL> logger = loggerFactory.CreateLogger<PatientDAL>();
            var patientDal = new PatientDAL(logger);
            return await patientDal.GetUserIdBySSN(ssn);
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;  //Prevents auto-creating columns
            dataGridView1.Columns.Clear();

            //Columns
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Visit Date",
                DataPropertyName = "VisitDate"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Visit Type",
                DataPropertyName = "VisitType"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Doctor Name",
                DataPropertyName = "DoctorName"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Symptoms",
                DataPropertyName = "Symptoms"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Diagnosis",
                DataPropertyName = "Diagnosis"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Prescribed Medicines",
                DataPropertyName = "PrescribedMedicines"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Medication Notes",
                DataPropertyName = "MedicationNotes"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "General Notes",
                DataPropertyName = "GeneralNotes"
            });
        }

        private void tbVisitType_TextChanged(object sender, EventArgs e) //insert visit type to filter
        {

        }

        private void tbVisitDate_TextChanged(object sender, EventArgs e) //insert visit date to filter
        {

        }

        private void tbDoctorName_TextChanged(object sender, EventArgs e) //insert Doctor Full name to filter
        {

        }

        private void tbSymptoms_TextChanged(object sender, EventArgs e) //insert symptoms to filter
        {

        }

        private void tbDiagnosis_TextChanged(object sender, EventArgs e) //insert diagnosis to filter
        {

        }

        private async void btnSearch_Click(object sender, EventArgs e) //click search button
        {
            string visitDate = tbVisitDate.Text;
            string visitType = tbVisitType.Text;
            string doctorName = tbDoctorName.Text;
            string symptoms = tbSymptoms.Text;
            string diagnosis = tbDiagnosis.Text;

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            ILogger<PatientDAL> logger = loggerFactory.CreateLogger<PatientDAL>();
            var patientDal = new PatientDAL(logger);
            int userId = await patientDal.GetUserIdBySSN(patientSSN);

            if (userId == -1)
            {
                MessageBox.Show("No patient found with the given SSN.");
                return;
            }

            var medicalRecordManager = new MedicalRecordManager();
            var records = await medicalRecordManager.GetFilteredPrescriptionRecords(userId, visitDate, visitType, doctorName, symptoms, diagnosis);
            dataGridView1.DataSource = records;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
