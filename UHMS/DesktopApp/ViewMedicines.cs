using BusinessLogic;
using Domain;
using System;
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
    public partial class ViewMedicines : Form
    {
        private List<Medication> allMedications;
        public ViewMedicines()
        {
            InitializeComponent();
            LoadMedicationsAsync();
            InitializeDataGridView();
        }

        private async void LoadMedicationsAsync()
        {
            var medicationManager = new MedicationManager();
            allMedications = await medicationManager.GetAllMedications();
            dataGridView1.DataSource = allMedications;
            AdjustColumnVisibility();
            AdjustColumnHeaders();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ScrollBars = ScrollBars.Both;

            //Specific column size adjustments
            //dataGridView1.Columns["PossibleSideEffects"].MinimumWidth = 150;
        }

        private void tbMedicineName_TextChanged(object sender, EventArgs e) //Insert Medicine Name
        {
            FilterMedications();
        }

        private void tbCompanyName_TextChanged(object sender, EventArgs e) //Insert Company Name
        {
            FilterMedications();
        }

        private void tbUsedFor_TextChanged(object sender, EventArgs e) //Insert What Used For
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

        private void AdjustColumnHeaders()
        {
            dataGridView1.Columns["CompanyName"].HeaderText = "Company Name";
            dataGridView1.Columns["PossibleSideEffects"].HeaderText = "Possible Side Effects";
            dataGridView1.Columns["DosageForm"].HeaderText = "Dosage Form";
            dataGridView1.Columns["UsedFor"].HeaderText = "Used For";
        }

        private void btnSearch_Click(object sender, EventArgs e) //search button
        {

        }
    }
}
