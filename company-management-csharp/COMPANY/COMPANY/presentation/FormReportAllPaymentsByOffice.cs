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
    public partial class FormReportAllPaymentsByOffice : Form
    {
        public FormReportAllPaymentsByOffice()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // New data is being placed
            dgvResults.Rows.Clear();

            int officeId = cmbOffice.SelectedIndex;
            bool officeSelected = officeId == -1 ? false : true;


            // dptMonth.Value returns date in format dd/mm/yyyy hh:mm:ss
            string[] parts = dtpMonth.Value.ToString().Split('/');

            // We only get the year and avoid passing the hours, minutes and seconds.
            int year = Convert.ToInt32(parts[2].Split(' ')[0]);
            int month = Convert.ToInt32(parts[1]);

            List<MonthlyPayment> payments;
            Office o;
            MonthlyPayment aux = new MonthlyPayment();

            if (officeSelected)
            {
                o = (Office) cmbOffice.Items[officeId];
                payments = aux.getPaymentsMonth(year, month, o == null ? 0 : o.idOffice, officeSelected);
            } else
            {
                payments = aux.getPaymentsMonth(year, month, 0, officeSelected);
            }


            if (payments.Count == 0)
            {
                MessageBox.Show("No monthly payments were found with the selected conditions", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            foreach (MonthlyPayment p in payments)
            {
                string employeeText = p.payEmployee != null ? $"{p.payEmployee.idEmployee} - {p.payEmployee.empName}" : string.Empty;
                dgvResults.Rows.Add(p.idMonthlyPayment, employeeText, p.paySalaryGross, p.paySalaryNet, p.payBonusApplied);
            }
        }

        private void FormReportAllPaymentsByOffice_Load(object sender, EventArgs e)
        {
            Office auxOffice = new Office();
            List<Office> offices = auxOffice.ReadAllOffices();
            cmbOffice.DataSource = offices;
            cmbOffice.DisplayMember = "idOffice";
            cmbOffice.ValueMember = "idOffice";
            cmbOffice.SelectedIndex = -1;
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
