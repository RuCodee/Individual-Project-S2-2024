namespace DesktopApp
{
    partial class ViewMedicalRecord
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnSearch = new Button();
            tbVisitType = new TextBox();
            tbDiagnosis = new TextBox();
            tbSymptoms = new TextBox();
            tbDoctorName = new TextBox();
            tbVisitDate = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(tbVisitType);
            panel1.Controls.Add(tbDiagnosis);
            panel1.Controls.Add(tbSymptoms);
            panel1.Controls.Add(tbDoctorName);
            panel1.Controls.Add(tbVisitDate);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1904, 221);
            panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 15F);
            btnSearch.Location = new Point(1317, 176);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(105, 36);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // tbVisitType
            // 
            tbVisitType.Font = new Font("Segoe UI", 16F);
            tbVisitType.Location = new Point(12, 176);
            tbVisitType.Name = "tbVisitType";
            tbVisitType.PlaceholderText = "Visit Type";
            tbVisitType.Size = new Size(239, 36);
            tbVisitType.TabIndex = 11;
            tbVisitType.TextChanged += tbVisitType_TextChanged;
            // 
            // tbDiagnosis
            // 
            tbDiagnosis.Font = new Font("Segoe UI", 16F);
            tbDiagnosis.Location = new Point(1031, 176);
            tbDiagnosis.Name = "tbDiagnosis";
            tbDiagnosis.PlaceholderText = "Diagnosis";
            tbDiagnosis.Size = new Size(239, 36);
            tbDiagnosis.TabIndex = 9;
            tbDiagnosis.TextChanged += tbDiagnosis_TextChanged;
            // 
            // tbSymptoms
            // 
            tbSymptoms.Font = new Font("Segoe UI", 16F);
            tbSymptoms.Location = new Point(777, 176);
            tbSymptoms.Name = "tbSymptoms";
            tbSymptoms.PlaceholderText = "Symptoms";
            tbSymptoms.Size = new Size(239, 36);
            tbSymptoms.TabIndex = 8;
            tbSymptoms.TextChanged += tbSymptoms_TextChanged;
            // 
            // tbDoctorName
            // 
            tbDoctorName.Font = new Font("Segoe UI", 16F);
            tbDoctorName.Location = new Point(517, 176);
            tbDoctorName.Name = "tbDoctorName";
            tbDoctorName.PlaceholderText = "Doctor Name";
            tbDoctorName.Size = new Size(239, 36);
            tbDoctorName.TabIndex = 7;
            tbDoctorName.TextChanged += tbDoctorName_TextChanged;
            // 
            // tbVisitDate
            // 
            tbVisitDate.Font = new Font("Segoe UI", 16F);
            tbVisitDate.Location = new Point(265, 176);
            tbVisitDate.Name = "tbVisitDate";
            tbVisitDate.PlaceholderText = "Visit Date";
            tbVisitDate.Size = new Size(239, 36);
            tbVisitDate.TabIndex = 6;
            tbVisitDate.TextChanged += tbVisitDate_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(767, 9);
            label1.Name = "label1";
            label1.Size = new Size(564, 86);
            label1.TabIndex = 4;
            label1.Text = "MEDICAL HISTORY";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 227);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1904, 814);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ViewMedicalRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "ViewMedicalRecord";
            Text = "ViewMedicalRecord";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox tbSymptoms;
        private TextBox tbDoctorName;
        private TextBox tbVisitDate;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox tbVisitType;
        private TextBox tbDiagnosis;
        private Button btnSearch;
    }
}