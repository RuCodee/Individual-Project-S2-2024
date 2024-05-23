namespace DesktopApp
{
    partial class PrescriptionMRecord

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            btnComplete = new Button();
            btnSearch = new Button();
            label1 = new Label();
            tbGeneralNotes = new TextBox();
            tbMedicineName = new TextBox();
            tbMedicationNotes = new TextBox();
            tbUsedFor = new TextBox();
            tbCompanyName = new TextBox();
            tbPrescribedMedicines = new TextBox();
            tbDiagnosis = new TextBox();
            tbSymptoms = new TextBox();
            tbVisitType = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 15F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = SystemColors.Window;
            dataGridView1.Location = new Point(0, 539);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1904, 502);
            dataGridView1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(btnComplete);
            panel3.Controls.Add(btnSearch);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(tbGeneralNotes);
            panel3.Controls.Add(tbMedicineName);
            panel3.Controls.Add(tbMedicationNotes);
            panel3.Controls.Add(tbUsedFor);
            panel3.Controls.Add(tbCompanyName);
            panel3.Controls.Add(tbPrescribedMedicines);
            panel3.Controls.Add(tbDiagnosis);
            panel3.Controls.Add(tbSymptoms);
            panel3.Controls.Add(tbVisitType);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1904, 539);
            panel3.TabIndex = 3;
            // 
            // btnComplete
            // 
            btnComplete.FlatStyle = FlatStyle.System;
            btnComplete.Font = new Font("Segoe UI", 16F);
            btnComplete.Location = new Point(1712, 66);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(125, 43);
            btnComplete.TabIndex = 1;
            btnComplete.Text = "Complete";
            btnComplete.UseVisualStyleBackColor = true;
            btnComplete.Click += btnComplete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 16F);
            btnSearch.Location = new Point(1236, 483);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(104, 49);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(899, 425);
            label1.Name = "label1";
            label1.Size = new Size(332, 37);
            label1.TabIndex = 2;
            label1.Text = "PRESCRIBE MEDICATION";
            // 
            // tbGeneralNotes
            // 
            tbGeneralNotes.Font = new Font("Segoe UI", 16F);
            tbGeneralNotes.Location = new Point(1387, 66);
            tbGeneralNotes.Multiline = true;
            tbGeneralNotes.Name = "tbGeneralNotes";
            tbGeneralNotes.Size = new Size(307, 323);
            tbGeneralNotes.TabIndex = 0;
            // 
            // tbMedicineName
            // 
            tbMedicineName.Font = new Font("Segoe UI", 16F);
            tbMedicineName.Location = new Point(216, 489);
            tbMedicineName.Name = "tbMedicineName";
            tbMedicineName.PlaceholderText = "Type Medicine Name";
            tbMedicineName.Size = new Size(297, 36);
            tbMedicineName.TabIndex = 10;
            tbMedicineName.TextChanged += tbMedicineName_TextChanged;
            // 
            // tbMedicationNotes
            // 
            tbMedicationNotes.Font = new Font("Segoe UI", 16F);
            tbMedicationNotes.Location = new Point(1118, 66);
            tbMedicationNotes.Multiline = true;
            tbMedicationNotes.Name = "tbMedicationNotes";
            tbMedicationNotes.Size = new Size(269, 323);
            tbMedicationNotes.TabIndex = 0;
            // 
            // tbUsedFor
            // 
            tbUsedFor.Font = new Font("Segoe UI", 16F);
            tbUsedFor.Location = new Point(809, 489);
            tbUsedFor.Name = "tbUsedFor";
            tbUsedFor.PlaceholderText = "Used For (Fever, Headache and etc.)";
            tbUsedFor.Size = new Size(375, 36);
            tbUsedFor.TabIndex = 12;
            tbUsedFor.TextChanged += tbUsedFor_TextChanged;
            // 
            // tbCompanyName
            // 
            tbCompanyName.Font = new Font("Segoe UI", 16F);
            tbCompanyName.Location = new Point(532, 489);
            tbCompanyName.Name = "tbCompanyName";
            tbCompanyName.PlaceholderText = "Type Company Name";
            tbCompanyName.Size = new Size(257, 36);
            tbCompanyName.TabIndex = 11;
            tbCompanyName.TextChanged += tbCompanyName_TextChanged;
            // 
            // tbPrescribedMedicines
            // 
            tbPrescribedMedicines.BackColor = SystemColors.Window;
            tbPrescribedMedicines.Font = new Font("Segoe UI", 16F);
            tbPrescribedMedicines.Location = new Point(841, 65);
            tbPrescribedMedicines.Multiline = true;
            tbPrescribedMedicines.Name = "tbPrescribedMedicines";
            tbPrescribedMedicines.ReadOnly = true;
            tbPrescribedMedicines.Size = new Size(277, 324);
            tbPrescribedMedicines.TabIndex = 0;
            // 
            // tbDiagnosis
            // 
            tbDiagnosis.Font = new Font("Segoe UI", 16F);
            tbDiagnosis.Location = new Point(565, 63);
            tbDiagnosis.Multiline = true;
            tbDiagnosis.Name = "tbDiagnosis";
            tbDiagnosis.Size = new Size(276, 326);
            tbDiagnosis.TabIndex = 0;
            // 
            // tbSymptoms
            // 
            tbSymptoms.Font = new Font("Segoe UI", 16F);
            tbSymptoms.Location = new Point(296, 63);
            tbSymptoms.Multiline = true;
            tbSymptoms.Name = "tbSymptoms";
            tbSymptoms.Size = new Size(269, 326);
            tbSymptoms.TabIndex = 0;
            // 
            // tbVisitType
            // 
            tbVisitType.Font = new Font("Segoe UI", 16F);
            tbVisitType.Location = new Point(20, 63);
            tbVisitType.Multiline = true;
            tbVisitType.Name = "tbVisitType";
            tbVisitType.Size = new Size(276, 326);
            tbVisitType.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label8.Location = new Point(1452, 19);
            label8.Name = "label8";
            label8.Size = new Size(176, 32);
            label8.TabIndex = 7;
            label8.Text = "General Notes";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label7.Location = new Point(1144, 19);
            label7.Name = "label7";
            label7.Size = new Size(217, 32);
            label7.TabIndex = 6;
            label7.Text = "Medication Notes";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label6.Location = new Point(853, 19);
            label6.Name = "label6";
            label6.Size = new Size(258, 32);
            label6.TabIndex = 5;
            label6.Text = "Prescribed Medicines";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.Location = new Point(643, 19);
            label5.Name = "label5";
            label5.Size = new Size(126, 32);
            label5.TabIndex = 4;
            label5.Text = "Diagnosis";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label4.Location = new Point(369, 18);
            label4.Name = "label4";
            label4.Size = new Size(133, 32);
            label4.TabIndex = 3;
            label4.Text = "Symptoms";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label3.Location = new Point(92, 19);
            label3.Name = "label3";
            label3.Size = new Size(125, 32);
            label3.TabIndex = 2;
            label3.Text = "Visit Type";
            // 
            // PrescriptionMRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(dataGridView1);
            Controls.Add(panel3);
            Name = "PrescriptionMRecord";
            Text = "Prescription";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private Panel panel3;
        private Button btnComplete;
        private Button btnSearch;
        private Label label1;
        private TextBox tbGeneralNotes;
        private TextBox tbMedicineName;
        private TextBox tbMedicationNotes;
        private TextBox tbUsedFor;
        private TextBox tbCompanyName;
        private TextBox tbPrescribedMedicines;
        private TextBox tbDiagnosis;
        private TextBox tbSymptoms;
        private TextBox tbVisitType;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
    }
}