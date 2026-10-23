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
    public partial class FormReportExpensesByOfficeMonth : Form
    {
        public FormReportExpensesByOfficeMonth()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            dgvResults.Rows.Clear();

            // dptMonth.Value returns date in format dd/mm/yyyy hh:mm:ss
            string[] parts = dtpMonth.Value.ToString().Split('/');

            // We only get the year and avoid passing the hours, minutes and seconds.
            int year = Convert.ToInt32(parts[2].Split(' ')[0]);
            int month = Convert.ToInt32(parts[1]);
            

            MonthlyPayment aux = new MonthlyPayment();
            List<List<object>> paymentsAndOffice = aux.GetExpensesPerOffice(year, month);

            if (paymentsAndOffice.Count == 0)
            {
                MessageBox.Show("No monthly payments were found with the selected conditions", null, MessageBoxButtons.OK);
            }

            foreach (List<object> pair in paymentsAndOffice)
            {
                MonthlyPayment p = (MonthlyPayment) pair[0];
                Office o = (Office) pair[1];

                string employeeText = p.payEmployee != null ? $"{p.payEmployee.idEmployee} - {p.payEmployee.empName}" : string.Empty;
                dgvResults.Rows.Add(p.idMonthlyPayment, o.offCity, employeeText, p.payYear, p.payMonth, p.paySalaryGross, p.paySalaryNet, p.payBonusApplied);
            }
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
