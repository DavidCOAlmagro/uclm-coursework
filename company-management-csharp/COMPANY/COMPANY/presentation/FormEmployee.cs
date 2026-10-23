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
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            Employee aux = new Employee();

            try
            {
                List<Employee> employees = aux.ReadAllEmployees();

                foreach (Employee employee in employees)
                {
                    lstEmployee.Items.Add(employee);
                }
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            Country aux2 = new Country();
            try
            {
                List<Country> countries = aux2.ReadAllCountries();
                cmbCountry.DataSource = countries;
                cmbCountry.DisplayMember = "couName";
                cmbCountry.ValueMember = "idCountry";
                cmbCountry.SelectedIndex = -1;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEmployee.SelectedItem != null)
            {
                Employee emp = (Employee)lstEmployee.SelectedItem;
                txtId.Text = emp.idEmployee.ToString();
                txtName.Text = emp.empName;
                cmbCountry.SelectedValue = emp.empCountry.idCountry;
                txtIban.Text = emp.empIBAN;

                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty && txtIban.Text != string.Empty && cmbCountry.SelectedIndex != -1)
            {
                Employee emp = new Employee();
                emp.empName = txtName.Text;
                emp.empIBAN = txtIban.Text;
                emp.empCountry = (Country)cmbCountry.SelectedItem;

                try
                {
                    if (emp.InsertEmployee() == 1)
                    {
                        lstEmployee.Items.Add(emp);
                        btnClear.PerformClick();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty && txtName.Text != string.Empty && txtIban.Text != string.Empty)
            {
                Employee emp = new Employee();
                emp.idEmployee = Convert.ToInt32(txtId.Text);
                emp.empName = txtName.Text;
                emp.empIBAN = txtIban.Text;
                emp.empCountry = (Country)cmbCountry.SelectedItem;

                try
                {
                    if (emp.UpdateEmployee() == 1)
                    {
                        int index = lstEmployee.SelectedIndex;
                        lstEmployee.Items.RemoveAt(index);
                        lstEmployee.Items.Insert(index, emp);
                        btnClear.PerformClick();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty)
            {
                Employee emp = new Employee();
                emp.idEmployee = Convert.ToInt32(txtId.Text);

                if (MessageBox.Show("Are you sure you want to delete employee " + emp.idEmployee + " ?", "Please confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (emp.DeleteEmployee() == 1)
                        {
                            int index = lstEmployee.SelectedIndex;
                            lstEmployee.Items.RemoveAt(index);
                            btnClear.PerformClick();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtIban.Text = string.Empty;
            cmbCountry.SelectedIndex = -1;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
