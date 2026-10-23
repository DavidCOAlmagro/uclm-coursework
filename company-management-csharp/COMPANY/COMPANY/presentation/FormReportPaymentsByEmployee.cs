using COMPANY_A2.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace COMPANY_A2.presentation
{
    public partial class FormReportPaymentsByEmployee : Form
    {
        public FormReportPaymentsByEmployee()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {   
            // New incoming results
            dgvResults.Rows.Clear();

            int empIdx;

            if ((empIdx = cmbEmployee.SelectedIndex) == -1) {
                MessageBox.Show("The selection of an employee is mandatory.", null, MessageBoxButtons.OK);
            } else
            {
                MonthlyPayment aux = new MonthlyPayment();
                Employee emp = (Employee) cmbEmployee.Items[empIdx];

                List<MonthlyPayment> payments = aux.monthlyPaymentPerEmployee(emp.idEmployee);

                if (payments.Count == 0)
                {
                    MessageBox.Show("No elements were found", null, MessageBoxButtons.OK);
                }

                foreach (MonthlyPayment p in payments)
                {
                    string employeeText = p.payEmployee != null ? $"{p.payEmployee.idEmployee} - {p.payEmployee.empName}" : string.Empty;
                    dgvResults.Rows.Add(p.idMonthlyPayment, employeeText, p.payYear, p.payMonth, p.paySalaryGross, p.paySalaryNet, p.payBonusApplied);
                }
            }
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   

        }

        private void FormReportPaymentsByEmployee_Load(object sender, EventArgs e)
        {
            Employee auxEmployee = new Employee();
            List<Employee> employees = auxEmployee.ReadAllEmployees();
            cmbEmployee.DataSource = employees;
            cmbEmployee.DisplayMember = "empName";
            cmbEmployee.ValueMember = "idEmployee";
            cmbEmployee.SelectedIndex = -1;
        }
    }
}
