namespace COMPANY_A2.presentation
{
    partial class FormReportExpensesByOfficeMonth
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dtpMonth = new DateTimePicker();
            btnRun = new Button();
            dgvResults = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Office = new DataGridViewTextBoxColumn();
            Employee = new DataGridViewTextBoxColumn();
            Year = new DataGridViewTextBoxColumn();
            Month = new DataGridViewTextBoxColumn();
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
            dtpMonth.Name = "dtpMonth";
            dtpMonth.ShowUpDown = true;
            dtpMonth.Size = new Size(100, 23);
            dtpMonth.TabIndex = 0;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(130, 12);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(100, 23);
            btnRun.TabIndex = 1;
            btnRun.Text = "Generate report";
            btnRun.Click += btnRun_Click;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.Columns.AddRange(new DataGridViewColumn[] { Id, Office, Employee, Year, Month, Gross_Salary, Net_Salary, Bonus_Applied });
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
            // Office
            // 
            Office.HeaderText = "Office";
            Office.Name = "Office";
            Office.ReadOnly = true;
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
            // FormReportExpensesByOfficeMonth
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 400);
            Controls.Add(dtpMonth);
            Controls.Add(btnRun);
            Controls.Add(dgvResults);
            Name = "FormReportExpensesByOfficeMonth";
            Text = "Expenses by Office (Month)";
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpMonth;
        private Button btnRun;
        private DataGridView dgvResults;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Office;
        private DataGridViewTextBoxColumn Employee;
        private DataGridViewTextBoxColumn Year;
        private DataGridViewTextBoxColumn Month;
        private DataGridViewTextBoxColumn Gross_Salary;
        private DataGridViewTextBoxColumn Net_Salary;
        private DataGridViewTextBoxColumn Bonus_Applied;
    }
}
