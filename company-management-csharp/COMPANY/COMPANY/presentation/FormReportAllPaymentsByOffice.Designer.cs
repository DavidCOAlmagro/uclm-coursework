namespace COMPANY_A2.presentation
{
    partial class FormReportAllPaymentsByOffice
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
            dtpMonth = new DateTimePicker();
            cmbOffice = new ComboBox();
            btnRun = new Button();
            dgvResults = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Employee = new DataGridViewTextBoxColumn();
            Gross_Salary = new DataGridViewTextBoxColumn();
            Net_Salary = new DataGridViewTextBoxColumn();
            Bonus_Applied = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // dtpMonth
            // 
            dtpMonth.CustomFormat = "yyyy-MM";
            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpMonth.Location = new Point(12, 12);
            dtpMonth.MaxDate = new DateTime(2026, 4, 25, 0, 0, 0, 0);
            dtpMonth.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtpMonth.Name = "dtpMonth";
            dtpMonth.ShowUpDown = true;
            dtpMonth.Size = new Size(100, 23);
            dtpMonth.TabIndex = 0;
            dtpMonth.Value = new DateTime(2009, 12, 31, 0, 0, 0, 0);
            dtpMonth.ValueChanged += dtpMonth_ValueChanged;
            // 
            // cmbOffice
            // 
            cmbOffice.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOffice.Location = new Point(130, 12);
            cmbOffice.Name = "cmbOffice";
            cmbOffice.Size = new Size(200, 23);
            cmbOffice.TabIndex = 1;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(350, 12);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(100, 23);
            btnRun.TabIndex = 2;
            btnRun.Text = "Generate report";
            btnRun.Click += btnRun_Click;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.Columns.AddRange(new DataGridViewColumn[] { Id, Employee, Gross_Salary, Net_Salary, Bonus_Applied });
            dgvResults.Location = new Point(12, 50);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(760, 380);
            dgvResults.TabIndex = 3;
            dgvResults.CellContentClick += dgvResults_CellContentClick;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Employee
            // 
            Employee.HeaderText = "Employee";
            Employee.Name = "Employee";
            Employee.ReadOnly = true;
            // 
            // Gross_Salary
            // 
            Gross_Salary.HeaderText = "Gross Salary";
            Gross_Salary.Name = "Gross_Salary";
            Gross_Salary.ReadOnly = true;
            // 
            // Net_Salary
            // 
            Net_Salary.HeaderText = "Net salary";
            Net_Salary.Name = "Net_Salary";
            Net_Salary.ReadOnly = true;
            // 
            // Bonus_Applied
            // 
            Bonus_Applied.HeaderText = "Bonus Applied";
            Bonus_Applied.Name = "Bonus_Applied";
            Bonus_Applied.ReadOnly = true;
            // 
            // FormReportAllPaymentsByOffice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpMonth);
            Controls.Add(cmbOffice);
            Controls.Add(btnRun);
            Controls.Add(dgvResults);
            Name = "FormReportAllPaymentsByOffice";
            Text = "All Payments by Office";
            Load += FormReportAllPaymentsByOffice_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpMonth;
        private ComboBox cmbOffice;
        private Button btnRun;
        private DataGridView dgvResults;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Employee;
        private DataGridViewTextBoxColumn Gross_Salary;
        private DataGridViewTextBoxColumn Net_Salary;
        private DataGridViewTextBoxColumn Bonus_Applied;
    }
}
