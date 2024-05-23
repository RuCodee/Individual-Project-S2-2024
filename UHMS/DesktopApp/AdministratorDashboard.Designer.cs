namespace DesktopApp
{
    partial class AdministratorDashboard
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
            button3 = new Button();
            panel4 = new Panel();
            panel2 = new Panel();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(button3);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 126);
            panel1.Name = "panel1";
            panel1.Size = new Size(1880, 899);
            panel1.TabIndex = 2;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 33F);
            button3.Location = new Point(509, 76);
            button3.Name = "button3";
            button3.Size = new Size(317, 206);
            button3.TabIndex = 0;
            button3.Text = "Appointments";
            button3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonFace;
            panel4.Location = new Point(506, 73);
            panel4.Name = "panel4";
            panel4.Size = new Size(323, 212);
            panel4.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.Controls.Add(button1);
            panel2.Location = new Point(93, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(323, 212);
            panel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(317, 206);
            button1.TabIndex = 0;
            button1.Text = "Search Patient";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 93);
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
            label1.Location = new Point(708, 16);
            label1.Name = "label1";
            label1.Size = new Size(909, 86);
            label1.TabIndex = 3;
            label1.Text = "ADMINISTRATOR DASHBOARD";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // AdministratorDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "AdministratorDashboard";
            Text = "AdministratorDashboard";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button3;
        private Panel panel4;
        private Panel panel2;
        private Button button1;
        private Label label2;
        private Label label1;
    }
}