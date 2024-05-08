namespace DesktopApp
{
    partial class PatientProfile
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
            panel3 = new Panel();
            btnViewMedicalHistory = new Button();
            panel2 = new Panel();
            btnPrescribe = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-2, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(808, 459);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.AppWorkspace;
            panel3.Controls.Add(btnViewMedicalHistory);
            panel3.Location = new Point(427, 97);
            panel3.Name = "panel3";
            panel3.Size = new Size(256, 223);
            panel3.TabIndex = 1;
            // 
            // btnViewMedicalHistory
            // 
            btnViewMedicalHistory.Font = new Font("Segoe UI", 25F);
            btnViewMedicalHistory.Location = new Point(3, 3);
            btnViewMedicalHistory.Name = "btnViewMedicalHistory";
            btnViewMedicalHistory.Size = new Size(250, 217);
            btnViewMedicalHistory.TabIndex = 0;
            btnViewMedicalHistory.Text = "VIEW MEDICAL HISTORY";
            btnViewMedicalHistory.UseVisualStyleBackColor = true;
            btnViewMedicalHistory.Click += btnViewMedicalHistory_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.AppWorkspace;
            panel2.Controls.Add(btnPrescribe);
            panel2.Location = new Point(49, 97);
            panel2.Name = "panel2";
            panel2.Size = new Size(256, 223);
            panel2.TabIndex = 0;
            // 
            // btnPrescribe
            // 
            btnPrescribe.Font = new Font("Segoe UI", 25F);
            btnPrescribe.Location = new Point(3, 3);
            btnPrescribe.Name = "btnPrescribe";
            btnPrescribe.Size = new Size(250, 217);
            btnPrescribe.TabIndex = 0;
            btnPrescribe.Text = "PRESCRIBE";
            btnPrescribe.UseVisualStyleBackColor = true;
            btnPrescribe.Click += btnPrescribe_Click;
            // 
            // PatientProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 418);
            Controls.Add(panel1);
            Name = "PatientProfile";
            Text = "PatientProfile";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Button btnViewMedicalHistory;
        private Panel panel2;
        private Button btnPrescribe;
    }
}