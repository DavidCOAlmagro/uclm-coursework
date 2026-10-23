using COMPANY_A2.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace COMPANY_A2.presentation
{
    public partial class FormReportExpensesByCountryMonths : Form
    {
        public FormReportExpensesByCountryMonths()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // New incoming rows
            dgvResults.Rows.Clear();

            // We call the method from MonthlyPaymentDAO
            MonthlyPayment aux = new MonthlyPayment();
            List<List<object>> paymentsAndCountry = aux.GetExpensesPerCountry();

            foreach (List<object> pair in paymentsAndCountry)
            {
                MonthlyPayment p = (MonthlyPayment) pair[0];
                Country c = (Country) pair[1];

                // We add each new Monthly Payment to the Data View Grid, employee id and name for extra info
                string employeeText = p.payEmployee != null ? $"{p.payEmployee.idEmployee} - {p.payEmployee.empName}" : string.Empty;
                dgvResults.Rows.Add(p.idMonthlyPayment,c.couName, employeeText, p.payYear, p.payMonth, p.paySalaryGross, p.paySalaryNet, p.payBonusApplied);
            }
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
