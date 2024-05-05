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
    public partial class AdministratorDashboard : Form
    {
        private User currentUser;
        public AdministratorDashboard(User user)
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            currentUser = user;
            UpdateWelcomeMessage();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void UpdateWelcomeMessage()
        {
            label2.Text = $"Welcome, {currentUser.FirstName} {currentUser.LastName}";
        }
    }
}
