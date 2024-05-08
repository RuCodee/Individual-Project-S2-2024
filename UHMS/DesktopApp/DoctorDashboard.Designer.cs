namespace DesktopApp
{
    partial class DoctorDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel4 = new Panel();
            btnAppointments = new Button();
            panel3 = new Panel();
            btnMedicines = new Button();
            panel2 = new Panel();
            btnSearchPatient = new Button();
            label2 = new Label();
            label1 = new Label();
            btnLogout = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 130);
            panel1.Name = "panel1";
            panel1.Size = new Size(1880, 899);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonFace;
            panel4.Controls.Add(btnAppointments);
            panel4.Location = new Point(929, 70);
            panel4.Name = "panel4";
            panel4.Size = new Size(323, 212);
            panel4.TabIndex = 3;
            // 
            // btnAppointments
            // 
            btnAppointments.Font = new Font("Segoe UI", 33F);
            btnAppointments.Location = new Point(3, 3);
            btnAppointments.Name = "btnAppointments";
            btnAppointments.Size = new Size(317, 206);
            btnAppointments.TabIndex = 0;
            btnAppointments.Text = "Appointments";
            btnAppointments.UseVisualStyleBackColor = true;
            btnAppointments.Click += btnAppointments_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonFace;
            panel3.Controls.Add(btnMedicines);
            panel3.Location = new Point(495, 70);
            panel3.Name = "panel3";
            panel3.Size = new Size(323, 212);
            panel3.TabIndex = 2;
            // 
            // btnMedicines
            // 
            btnMedicines.Font = new Font("Segoe UI", 36F);
            btnMedicines.Location = new Point(3, 3);
            btnMedicines.Name = "btnMedicines";
            btnMedicines.Size = new Size(317, 206);
            btnMedicines.TabIndex = 0;
            btnMedicines.Text = "Medicines";
            btnMedicines.UseVisualStyleBackColor = true;
            btnMedicines.Click += btnMedicines_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.Controls.Add(btnSearchPatient);
            panel2.Location = new Point(93, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(323, 212);
            panel2.TabIndex = 1;
            // 
            // btnSearchPatient
            // 
            btnSearchPatient.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearchPatient.Location = new Point(3, 3);
            btnSearchPatient.Name = "btnSearchPatient";
            btnSearchPatient.Size = new Size(317, 206);
            btnSearchPatient.TabIndex = 0;
            btnSearchPatient.Text = "Search Patient";
            btnSearchPatient.UseVisualStyleBackColor = true;
            btnSearchPatient.Click += btnSearchPatient_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 97);
            label2.Name = "label2";
            label2.Size = new Size(111, 30);
            label2.TabIndex = 0;
            label2.Text = "WELCOME";
            label2.TextAlign = ContentAlignment.TopRight;
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(708, 20);
            label1.Name = "label1";
            label1.Size = new Size(675, 86);
            label1.TabIndex = 1;
            label1.Text = "DOCTOR DASHBOARD";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(255, 128, 128);
            btnLogout.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(1784, 87);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(108, 40);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // DoctorDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btnLogout);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(label2);
            Name = "DoctorDashboard";
            Text = "Dashboard";
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Label label2;
        private Button btnAppointments;
        private Button btnMedicines;
        private Button btnSearchPatient;
        private Button btnLogout;
    }
}