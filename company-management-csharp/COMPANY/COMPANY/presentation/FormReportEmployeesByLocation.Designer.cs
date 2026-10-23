namespace COMPANY_A2.presentation
{
    partial class FormReportEmployeesByLocation
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
            btnRun = new Button();
            dgvResults = new DataGridView();
            Id_Employee = new DataGridViewTextBoxColumn();
            Employee_name = new DataGridViewTextBoxColumn();
            Start_Date = new DataGridViewTextBoxColumn();
            End_Date = new DataGridViewTextBoxColumn();
            Location = new DataGridViewTextBoxColumn();
            Triennium = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // btnRun
            // 
            btnRun.Location = new Point(12, 12);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(117, 23);
            btnRun.TabIndex = 0;
            btnRun.Text = "Generate report";
            btnRun.Click += btnRun_Click;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.Columns.AddRange(new DataGridViewColumn[] { Id_Employee, Employee_name, Start_Date, End_Date, Location, Triennium });
            dgvResults.Location = new Point(12, 50);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(576, 338);
            dgvResults.TabIndex = 1;
            dgvResults.CellContentClick += dgvResults_CellContentClick;
            // 
            // Id_Employee
            // 
            Id_Employee.HeaderText = "Id Employee";
            Id_Employee.Name = "Id_Employee";
            Id_Employee.ReadOnly = true;
            // 
            // Employee_name
            // 
            Employee_name.HeaderText = "Employee name";
            Employee_name.Name = "Employee_name";
            Employee_name.ReadOnly = true;
            // 
            // Start_Date
            // 
            Start_Date.HeaderText = "Start Date";
            Start_Date.Name = "Start_Date";
            Start_Date.ReadOnly = true;
            // 
            // End_Date
            // 
            End_Date.HeaderText = "End Date";
            End_Date.Name = "End_Date";
            End_Date.ReadOnly = true;
            // 
            // Location
            // 
            Location.HeaderText = "Location";
            Location.Name = "Location";
            Location.ReadOnly = true;
            // 
            // Triennium
            // 
            Triennium.HeaderText = "Triennium";
            Triennium.Name = "Triennium";
            Triennium.ReadOnly = true;
            // 
            // FormReportEmployeesByLocation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 400);
            Controls.Add(btnRun);
            Controls.Add(dgvResults);
            Name = "FormReportEmployeesByLocation";
            Text = "Employees by Location";
            Load += FormReportEmployeesByLocation_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRun;
        private DataGridView dgvResults;
        private DataGridViewTextBoxColumn Id_Employee;
        private DataGridViewTextBoxColumn Employee_name;
        private DataGridViewTextBoxColumn Start_Date;
        private DataGridViewTextBoxColumn End_Date;
        private DataGridViewTextBoxColumn Location;
        private DataGridViewTextBoxColumn Triennium;
    }
}
