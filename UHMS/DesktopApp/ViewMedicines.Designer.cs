namespace DesktopApp
{
    partial class ViewMedicines
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
            label1 = new Label();
            tbMedicineName = new TextBox();
            tbCompanyName = new TextBox();
            tbUsedFor = new TextBox();
            btnSearch = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
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
            dataGridView1.Location = new Point(0, 227);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1886, 814);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(696, 38);
            label1.Name = "label1";
            label1.Size = new Size(526, 86);
            label1.TabIndex = 4;
            label1.Text = "VIEW MEDICINES";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbMedicineName
            // 
            tbMedicineName.Font = new Font("Segoe UI", 16F);
            tbMedicineName.Location = new Point(22, 179);
            tbMedicineName.Name = "tbMedicineName";
            tbMedicineName.PlaceholderText = "Type Medicine Name";
            tbMedicineName.Size = new Size(297, 36);
            tbMedicineName.TabIndex = 5;
            tbMedicineName.TextChanged += tbMedicineName_TextChanged;
            // 
            // tbCompanyName
            // 
            tbCompanyName.Font = new Font("Segoe UI", 16F);
            tbCompanyName.Location = new Point(338, 179);
            tbCompanyName.Name = "tbCompanyName";
            tbCompanyName.PlaceholderText = "Type Company Name";
            tbCompanyName.Size = new Size(257, 36);
            tbCompanyName.TabIndex = 6;
            tbCompanyName.TextChanged += tbCompanyName_TextChanged;
            // 
            // tbUsedFor
            // 
            tbUsedFor.Font = new Font("Segoe UI", 16F);
            tbUsedFor.Location = new Point(615, 179);
            tbUsedFor.Name = "tbUsedFor";
            tbUsedFor.PlaceholderText = "Used For (Fever, Headache and etc.)";
            tbUsedFor.Size = new Size(375, 36);
            tbUsedFor.TabIndex = 7;
            tbUsedFor.TextChanged += tbUsedFor_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 16F);
            btnSearch.Location = new Point(1042, 173);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(104, 49);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1886, 1041);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1886, 227);
            panel2.TabIndex = 10;
            // 
            // ViewMedicines
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1886, 1041);
            Controls.Add(btnSearch);
            Controls.Add(tbUsedFor);
            Controls.Add(tbCompanyName);
            Controls.Add(tbMedicineName);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ViewMedicines";
            Text = "ViewMedicines";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox tbMedicineName;
        private TextBox tbCompanyName;
        private TextBox tbUsedFor;
        private Button btnSearch;
        private Panel panel1;
        private Panel panel2;
    }
}