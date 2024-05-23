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
using DataAccessLayer;
using Microsoft.Extensions.Logging;

namespace DesktopApp
{
    public partial class PrescriptionMRecord : Form
    {
        private List<Medication> allMedications;
        private User currentUser;
        private string patientSSN;
        private int currentPatientId;
        private MedicalRecordManager _medicalRecordManager;

        public PrescriptionMRecord(User user, string ssn, MedicalRecordManager medicalRecordManager)

        {
            InitializeComponent();
            currentUser = user;
            patientSSN = ssn;
            _medicalRecordManager = medicalRecordManager;
            InitializePatientId();
            InitializeDataGridView();
            LoadMedicationsAsync();

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            btnComplete.Click += btnComplete_Click;
            btnComplete.Click -= btnComplete_Click;
        }

        private void InitializePatientId()
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger<PatientDAL> logger = loggerFactory.CreateLogger<PatientDAL>();

            //creating PatientDAL with the required logger
            PatientDAL patientDAL = new PatientDAL(logger);

            //using PatientDAL to get patient ID by SSN
            currentPatientId = patientDAL.GetPatientIdBySSN(patientSSN);
            if (currentPatientId == 0)
            {
                MessageBox.Show("No patient found with this SSN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;  //set to false to manually configure columns

            // add checkbox column first
            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.HeaderText = "Select";
            chkColumn.Name = "Select";
            chkColumn.Width = 50;
            dataGridView1.Columns.Add(chkColumn);

            dataGridView1.Columns.Add(CreateTextColumn("Name", "Medicine Name"));
            dataGridView1.Columns.Add(CreateTextColumn("CompanyName", "Company Name"));
            dataGridView1.Columns.Add(CreateTextColumn("PossibleSideEffects", "Possible Side Effects"));
            dataGridView1.Columns.Add(CreateTextColumn("Contraindications", "Contraindications"));
            dataGridView1.Columns.Add(CreateTextColumn("DosageForm", "Dosage Form"));
            dataGridView1.Columns.Add(CreateTextColumn("Dosage", "Dosage"));
            dataGridView1.Columns.Add(CreateTextColumn("UsedFor", "Used For"));
        }

        private DataGridViewTextBoxColumn CreateTextColumn(string dataPropertyName, string headerText)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = dataPropertyName;
            column.HeaderText = headerText;
            column.Name = dataPropertyName;
            return column;
        }

        private async void LoadMedicationsAsync()
        {
            var medicationManager = new MedicationManager();
            allMedications = await medicationManager.GetAllMedications();
            dataGridView1.DataSource = new BindingList<Medication>(allMedications);
            AdjustColumnVisibility();
        }

        private void tbMedicineName_TextChanged(object sender, EventArgs e) //insert medicine name
        {
            FilterMedications();
        }

        private void tbCompanyName_TextChanged(object sender, EventArgs e) //insert company name
        {
            FilterMedications();
        }

        private void tbUsedFor_TextChanged(object sender, EventArgs e) //insert what used for
        {
            FilterMedications();
        }

        private void FilterMedications()
        {
            if (allMedications == null) return;

            string filterName = tbMedicineName.Text.ToLower();
            string filterCompany = tbCompanyName.Text.ToLower();
            string filterUsedFor = tbUsedFor.Text.ToLower();

            var filteredMedications = allMedications.Where(m =>
                (string.IsNullOrEmpty(filterName) || m.Name.ToLower().Contains(filterName)) &&
                (string.IsNullOrEmpty(filterCompany) || m.CompanyName.ToLower().Contains(filterCompany)) &&
                (string.IsNullOrEmpty(filterUsedFor) || m.UsedFor.ToLower().Split(',').Any(u => u.Trim().Contains(filterUsedFor)))
            ).ToList();

            dataGridView1.DataSource = filteredMedications;
        }

        private void AdjustColumnVisibility()
        {
            if (dataGridView1.Columns["MedicationId"] != null)
            {
                dataGridView1.Columns["MedicationId"].Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Select"].Index && e.RowIndex != -1)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Select"].Index && e.RowIndex != -1)
            {
                UpdatePrescribedMedicines();
            }
        }

        private void UpdatePrescribedMedicines()
        {
            var selectedMedicines = new StringBuilder();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected)
                {
                    if (selectedMedicines.Length > 0) selectedMedicines.Append(", ");
                    string medicineName = row.Cells["Name"].Value.ToString();
                    selectedMedicines.Append(medicineName);
                }
            }
            tbPrescribedMedicines.Text = selectedMedicines.ToString();
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) //search button
        {

        }

        private async void btnComplete_Click(object sender, EventArgs e) //complete button
        {

            try
            {
                var record = new PrescriptionMedicalRecord
                {
                    PatientId = currentPatientId,
                    DoctorId = currentUser.Id,
                    VisitType = tbVisitType.Text,
                    Symptoms = tbSymptoms.Text,
                    Diagnosis = tbDiagnosis.Text,
                    PrescribedMedicines = tbPrescribedMedicines.Text,
                    MedicationNotes = tbMedicationNotes.Text,
                    GeneralNotes = tbGeneralNotes.Text
                };

                int recordId = await _medicalRecordManager.AddPrescriptionMedicalRecord(record);

                MessageBox.Show("Record added successfully with ID: " + recordId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
