using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace COMPANY_A2.presentation
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void ManageCountries_Click(object sender, EventArgs e)
        {
            var form = new FormCountry();
            form.Show();
        }

        private void ManageOffices_Click(object sender, EventArgs e)
        {
            var form = new FormOffice();
            form.Show();
        }

        private void ManageEmployees_Click(object sender, EventArgs e)
        {
            var form = new FormEmployee();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new FormPosition();
            form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new FormMonthlyPayments();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new FormReportsMain();
            form.Show();
        }
    }
}
