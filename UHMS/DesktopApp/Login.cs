using System;
using System.Windows.Forms;
using Domain;
using BusinessLogic;
using DataAccessLayer.UnitTestInterfaces;
using DataAccessLayer;
using Microsoft.Extensions.Logging;

namespace DesktopApp
{
    public partial class Login : Form
    {
        private UserManager _userManager;

        public Login(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;

            tbPassword.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbJobId_TextChanged(object sender, EventArgs e) //insert job id in this text box
        {

        }

        private void tbPassword_TextChanged(object sender, EventArgs e) //insert password in this text box
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e) //login button
        {
            string jobId = tbJobId.Text;
            string password = tbPassword.Text;

            try
            {
                User user = await _userManager.LoginAsync(jobId, password);
                if (user != null)
                {
                    OpenDashboard(user);
                }
                else
                {
                    MessageBox.Show("Invalid login attempt.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void OpenDashboard(User user)
        {
            Form dashboard;
            switch (user.Role)
            {
                case Role.Doctor:
                    dashboard = new DoctorDashboard(user);
                    break;
                case Role.Administrator:
                    dashboard = new AdministratorDashboard(user);
                    break;
                default:
                    MessageBox.Show("User role is not recognized.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            this.Hide();
            dashboard.Show();
        }
    }
}
