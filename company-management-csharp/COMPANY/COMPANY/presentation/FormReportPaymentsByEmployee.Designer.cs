namespace COMPANY_A2.presentation
{
    partial class FormReportPaymentsByEmployee
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
            cmbEmployee = new ComboBox();
            btnRun = new Button();
            dgvResults = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Employee = new DataGridViewTextBoxColumn();
            Year = new DataGridViewTextBoxColumn();
            Month = new DataGridViewTextBoxColumn();
            Gross_Salary = new DataGridViewTextBoxColumn();
            Net_Salary = new DataGridViewTextBoxColumn();
            Bonus_Applied = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // cmbEmployee
            // 
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.Location = new Point(12, 12);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(300, 23);
            cmbEmployee.TabIndex = 0;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(330, 12);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(112, 23);
            btnRun.TabIndex = 1;
            btnRun.Text = "Generate report";
            btnRun.Click += btnRun_Click;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.Columns.AddRange(new DataGridViewColumn[] { Id, Employee, Year, Month, Gross_Salary, Net_Salary, Bonus_Applied });
            dgvResults.Location = new Point(12, 50);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(576, 338);
            dgvResults.TabIndex = 2;
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
            // Year
            // 
            Year.HeaderText = "Year";
            Year.Name = "Year";
            Year.ReadOnly = true;
            // 
            // Month
            // 
            Month.HeaderText = "Month";
            Month.Name = "Month";
            Month.ReadOnly = true;
            // 
            // Gross_Salary
            // 
            Gross_Salary.HeaderText = "Gross Salary";
            Gross_Salary.Name = "Gross_Salary";
            Gross_Salary.ReadOnly = true;
            // 
            // Net_Salary
            // 
            Net_Salary.HeaderText = "Net Salary";
            Net_Salary.Name = "Net_Salary";
            Net_Salary.ReadOnly = true;
            // 
            // Bonus_Applied
            // 
            Bonus_Applied.HeaderText = "Bonus Applied";
            Bonus_Applied.Name = "Bonus_Applied";
            Bonus_Applied.ReadOnly = true;
            // 
            // FormReportPaymentsByEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 400);
            Controls.Add(cmbEmployee);
            Controls.Add(btnRun);
            Controls.Add(dgvResults);
            Name = "FormReportPaymentsByEmployee";
            Text = "Payments by Employee";
            Load += FormReportPaymentsByEmployee_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private ComboBox cmbEmployee;
        private Button btnRun;
        private DataGridView dgvResults;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Employee;
        private DataGridViewTextBoxColumn Year;
        private DataGridViewTextBoxColumn Month;
        private DataGridViewTextBoxColumn Gross_Salary;
        private DataGridViewTextBoxColumn Net_Salary;
        private DataGridViewTextBoxColumn Bonus_Applied;
    }
}
