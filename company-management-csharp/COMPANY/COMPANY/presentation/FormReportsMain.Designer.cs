namespace COMPANY_A2.presentation
{
    partial class FormReportsMain
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
            buttonAllPaymentsByOffice = new Button();
            buttonAllPaymentsforEmployee = new Button();
            button3YeaPeriodEmpLocation = new Button();
            buttonPaymentExpensesOffices = new Button();
            buttonPaymentExpensesCountry = new Button();
            SuspendLayout();
            // 
            // buttonAllPaymentsByOffice
            // 
            buttonAllPaymentsByOffice.Location = new Point(231, 155);
            buttonAllPaymentsByOffice.Margin = new Padding(4, 5, 4, 5);
            buttonAllPaymentsByOffice.Name = "buttonAllPaymentsByOffice";
            buttonAllPaymentsByOffice.Size = new Size(264, 38);
            buttonAllPaymentsByOffice.TabIndex = 0;
            buttonAllPaymentsByOffice.Text = "All Payments by office";
            buttonAllPaymentsByOffice.UseVisualStyleBackColor = true;
            buttonAllPaymentsByOffice.Click += buttonAllPaymentsByOffice_Click;
            // 
            // buttonAllPaymentsforEmployee
            // 
            buttonAllPaymentsforEmployee.Location = new Point(687, 155);
            buttonAllPaymentsforEmployee.Margin = new Padding(4, 5, 4, 5);
            buttonAllPaymentsforEmployee.Name = "buttonAllPaymentsforEmployee";
            buttonAllPaymentsforEmployee.Size = new Size(264, 38);
            buttonAllPaymentsforEmployee.TabIndex = 1;
            buttonAllPaymentsforEmployee.Text = "All payments for an employee";
            buttonAllPaymentsforEmployee.UseVisualStyleBackColor = true;
            buttonAllPaymentsforEmployee.Click += buttonAllPaymentsforEmployee_Click;
            // 
            // button3YeaPeriodEmpLocation
            // 
            button3YeaPeriodEmpLocation.Location = new Point(436, 515);
            button3YeaPeriodEmpLocation.Margin = new Padding(4, 5, 4, 5);
            button3YeaPeriodEmpLocation.Name = "button3YeaPeriodEmpLocation";
            button3YeaPeriodEmpLocation.Size = new Size(293, 67);
            button3YeaPeriodEmpLocation.TabIndex = 2;
            button3YeaPeriodEmpLocation.Text = "Three year period applicable \r\nfor each employee at each location";
            button3YeaPeriodEmpLocation.UseVisualStyleBackColor = true;
            button3YeaPeriodEmpLocation.Click += button3YeaPeriodEmpLocation_Click;
            // 
            // buttonPaymentExpensesOffices
            // 
            buttonPaymentExpensesOffices.Location = new Point(231, 318);
            buttonPaymentExpensesOffices.Margin = new Padding(4, 5, 4, 5);
            buttonPaymentExpensesOffices.Name = "buttonPaymentExpensesOffices";
            buttonPaymentExpensesOffices.Size = new Size(264, 67);
            buttonPaymentExpensesOffices.TabIndex = 3;
            buttonPaymentExpensesOffices.Text = "Monthly payment expenses for each office";
            buttonPaymentExpensesOffices.UseVisualStyleBackColor = true;
            buttonPaymentExpensesOffices.Click += buttonPaymentExpensesOffices_Click;
            // 
            // buttonPaymentExpensesCountry
            // 
            buttonPaymentExpensesCountry.Location = new Point(687, 318);
            buttonPaymentExpensesCountry.Margin = new Padding(4, 5, 4, 5);
            buttonPaymentExpensesCountry.Name = "buttonPaymentExpensesCountry";
            buttonPaymentExpensesCountry.Size = new Size(264, 70);
            buttonPaymentExpensesCountry.TabIndex = 4;
            buttonPaymentExpensesCountry.Text = "Monthly payment expenses for each country";
            buttonPaymentExpensesCountry.UseVisualStyleBackColor = true;
            buttonPaymentExpensesCountry.Click += buttonPaymentExpensesCountry_Click;
            // 
            // FormReportsMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(buttonPaymentExpensesCountry);
            Controls.Add(buttonPaymentExpensesOffices);
            Controls.Add(button3YeaPeriodEmpLocation);
            Controls.Add(buttonAllPaymentsforEmployee);
            Controls.Add(buttonAllPaymentsByOffice);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormReportsMain";
            Text = "FormReportsMain";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAllPaymentsByOffice;
        private Button buttonAllPaymentsforEmployee;
        private Button button3YeaPeriodEmpLocation;
        private Button buttonPaymentExpensesOffices;
        private Button buttonPaymentExpensesCountry;
    }
}