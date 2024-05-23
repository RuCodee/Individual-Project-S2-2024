namespace DesktopApp
{
    partial class PatientSearchBox
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
            panel2 = new Panel();
            tbAccessCode = new TextBox();
            btnAccess = new Button();
            label3 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-1, -5);
            panel1.Name = "panel1";
            panel1.Size = new Size(600, 578);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(tbAccessCode);
            panel2.Controls.Add(btnAccess);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(10, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(410, 526);
            panel2.TabIndex = 0;
            // 
            // tbAccessCode
            // 
            tbAccessCode.BackColor = SystemColors.InactiveBorder;
            tbAccessCode.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbAccessCode.Location = new Point(87, 279);
            tbAccessCode.Name = "tbAccessCode";
            tbAccessCode.PlaceholderText = "Enter the Access Code";
            tbAccessCode.Size = new Size(222, 35);
            tbAccessCode.TabIndex = 4;
            tbAccessCode.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAccess
            // 
            btnAccess.BackColor = Color.FromArgb(255, 128, 128);
            btnAccess.Font = new Font("Segoe UI", 16F);
            btnAccess.Location = new Point(128, 330);
            btnAccess.Name = "btnAccess";
            btnAccess.Size = new Size(137, 52);
            btnAccess.TabIndex = 3;
            btnAccess.Text = "ACCESS";
            btnAccess.UseVisualStyleBackColor = false;
            btnAccess.Click += BtnAccess_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F);
            label3.Location = new Point(159, 60);
            label3.Name = "label3";
            label3.Size = new Size(65, 37);
            label3.TabIndex = 2;
            label3.Text = "SSN";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(128, 109);
            label1.Name = "label1";
            label1.Size = new Size(137, 37);
            label1.TabIndex = 0;
            label1.Text = "Full Name";
            // 
            // PatientSearchBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 550);
            Controls.Add(panel1);
            Name = "PatientSearchBox";
            Text = "PatientProfile";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnAccess;
        private Label label3;
        private Label label1;
        private TextBox tbAccessCode;
    }
}