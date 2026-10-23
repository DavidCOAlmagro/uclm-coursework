namespace COMPANY_A2.presentation
{
    partial class FormMenu
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
            ManageCountries = new Button();
            ManageOffices = new Button();
            ManageEmployees = new Button();
            ManagePositions = new Button();
            ManageMonthlyPayments = new Button();
            ManageReports = new Button();
            SuspendLayout();
            // 
            // ManageCountries
            // 
            ManageCountries.Location = new Point(77, 54);
            ManageCountries.Name = "ManageCountries";
            ManageCountries.Size = new Size(169, 23);
            ManageCountries.TabIndex = 0;
            ManageCountries.Text = "Manage Countries";
            ManageCountries.UseVisualStyleBackColor = true;
            ManageCountries.Click += ManageCountries_Click;
            // 
            // ManageOffices
            // 
            ManageOffices.Location = new Point(77, 97);
            ManageOffices.Name = "ManageOffices";
            ManageOffices.Size = new Size(169, 23);
            ManageOffices.TabIndex = 1;
            ManageOffices.Text = "Manage Offices";
            ManageOffices.UseVisualStyleBackColor = true;
            ManageOffices.Click += ManageOffices_Click;
            // 
            // ManageEmployees
            // 
            ManageEmployees.Location = new Point(77, 141);
            ManageEmployees.Name = "ManageEmployees";
            ManageEmployees.Size = new Size(169, 23);
            ManageEmployees.TabIndex = 2;
            ManageEmployees.Text = "Manage Employees";
            ManageEmployees.UseVisualStyleBackColor = true;
            ManageEmployees.Click += ManageEmployees_Click;
            // 
            // ManagePositions
            // 
            ManagePositions.Location = new Point(77, 187);
            ManagePositions.Name = "ManagePositions";
            ManagePositions.Size = new Size(169, 23);
            ManagePositions.TabIndex = 3;
            ManagePositions.Text = "Manage Positions";
            ManagePositions.UseVisualStyleBackColor = true;
            ManagePositions.Click += button1_Click;
            // 
            // ManageMonthlyPayments
            // 
            ManageMonthlyPayments.Location = new Point(77, 232);
            ManageMonthlyPayments.Name = "ManageMonthlyPayments";
            ManageMonthlyPayments.Size = new Size(169, 23);
            ManageMonthlyPayments.TabIndex = 4;
            ManageMonthlyPayments.Text = "Manage Monthly Payments";
            ManageMonthlyPayments.UseVisualStyleBackColor = true;
            ManageMonthlyPayments.Click += button1_Click_1;
            // 
            // ManageReports
            // 
            ManageReports.Location = new Point(77, 278);
            ManageReports.Name = "ManageReports";
            ManageReports.Size = new Size(169, 23);
            ManageReports.TabIndex = 5;
            ManageReports.Text = "Manage reports";
            ManageReports.UseVisualStyleBackColor = true;
            ManageReports.Click += button2_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ManageReports);
            Controls.Add(ManageMonthlyPayments);
            Controls.Add(ManagePositions);
            Controls.Add(ManageEmployees);
            Controls.Add(ManageOffices);
            Controls.Add(ManageCountries);
            Name = "FormMenu";
            Text = "FormMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button ManageCountries;
        private Button ManageOffices;
        private Button ManageEmployees;
        private Button ManagePositions;
        private Button ManageMonthlyPayments;
        private Button ManageReports;
    }
}