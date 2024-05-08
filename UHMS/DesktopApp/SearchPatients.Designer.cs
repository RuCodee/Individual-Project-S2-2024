namespace DesktopApp
{
    partial class SearchPatients
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
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label3 = new Label();
            btnSearch = new Button();
            tbPatientsSSN = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(708, 16);
            label1.Name = "label1";
            label1.Size = new Size(550, 86);
            label1.TabIndex = 3;
            label1.Text = "SEARCH PATIENTS";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(tbPatientsSSN);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 126);
            panel1.Name = "panel1";
            panel1.Size = new Size(1880, 899);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.Controls.Add(label3);
            panel2.Location = new Point(0, 147);
            panel2.Name = "panel2";
            panel2.Size = new Size(1880, 752);
            panel2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(5, 5);
            label3.Name = "label3";
            label3.Size = new Size(0, 32);
            label3.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 16F);
            btnSearch.Location = new Point(949, 68);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(109, 36);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // tbPatientsSSN
            // 
            tbPatientsSSN.Font = new Font("Segoe UI", 16F);
            tbPatientsSSN.Location = new Point(676, 68);
            tbPatientsSSN.Name = "tbPatientsSSN";
            tbPatientsSSN.PlaceholderText = "Insert Patient's SSN";
            tbPatientsSSN.Size = new Size(238, 36);
            tbPatientsSSN.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1764, 2);
            label2.Name = "label2";
            label2.Size = new Size(111, 30);
            label2.TabIndex = 0;
            label2.Text = "WELCOME";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // SearchPatients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "SearchPatients";
            Text = "SearchPatients";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button btnSearch;
        private TextBox tbPatientsSSN;
        private Label label2;
        private Panel panel2;
        private Label label3;
    }
}