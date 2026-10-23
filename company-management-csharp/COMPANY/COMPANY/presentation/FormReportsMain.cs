using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace COMPANY_A2.presentation
{
    public partial class FormReportsMain : Form
    {
        public FormReportsMain()
        {
            InitializeComponent();
        }

        private void buttonAllPaymentsByOffice_Click(object sender, EventArgs e)
        {
            var form = new FormReportAllPaymentsByOffice();
            form.Show();
        }

        private void buttonAllPaymentsforEmployee_Click(object sender, EventArgs e)
        {
            var form = new FormReportPaymentsByEmployee();
            form.Show();
        }

        private void button3YeaPeriodEmpLocation_Click(object sender, EventArgs e)
        {
            var form = new FormReportEmployeesByLocation();
            form.Show();
        }

        private void buttonPaymentExpensesOffices_Click(object sender, EventArgs e)
        {
            var form = new FormReportExpensesByOfficeMonth();
            form.Show();
        }

        private void buttonPaymentExpensesCountry_Click(object sender, EventArgs e)
        {
            var form = new FormReportExpensesByCountryMonths();
            form.Show();
        }
    }
}
