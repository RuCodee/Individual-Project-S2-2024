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
    public partial class DoctorDashboard : Form
    {
        private User currentUser;

        public DoctorDashboard(User user)
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            currentUser = user;
            UpdateWelcomeMessage();
            btnMedicines.Click += btnMedicines_Click;
            btnMedicines.Click -= btnMedicines_Click;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            SearchPatients searchPatientsForm = new SearchPatients(currentUser);
            searchPatientsForm.Show();
        }

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            ViewMedicines viewMedicinesForm = new ViewMedicines();
            viewMedicinesForm.Show();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e) //Welcome Text
        {

        }
        private void UpdateWelcomeMessage()
        {
            label2.Text = $"Welcome, Dr. {currentUser.FirstName} {currentUser.LastName}";
        }
    }
}
