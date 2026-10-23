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
    public partial class FormOffice : Form
    {
        public FormOffice()
        {
            InitializeComponent();
        }

        private void FormOffice_Load(object sender, EventArgs e)
        {
            Office aux = new Office();

            try
            {
                List<Office> offices = aux.ReadAllOffices();

                foreach (Office office in offices)
                {
                    lstOffice.Items.Add(office);
                }
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Country auxCountry = new Country();
            try
            {
                List<Country> countries = auxCountry.ReadAllCountries();
                cmbCountry.DataSource = countries;
                cmbCountry.DisplayMember = "couName";
                cmbCountry.ValueMember = "idCountry";
                cmbCountry.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOffice.SelectedItem != null)
            {
                Office oAux = (Office) lstOffice.SelectedItem;
                txtId.Text = oAux.idOffice.ToString();
                cmbCountry.SelectedValue = oAux.offCountry.idCountry;
                txtCity.Text = oAux.offCity;
                txtAddress.Text = oAux.offAddress;
                numThreeYearBonus.Value = oAux.offThreeYearBonus;

                btnInsert.Enabled = false; 
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cmbCountry.SelectedIndex != -1 && txtCity.Text != string.Empty && txtAddress.Text != string.Empty)
            {
                Office o = new Office();
                o.offCountry = (Country)cmbCountry.SelectedItem;
                o.offCity = txtCity.Text;
                o.offAddress = txtAddress.Text;
                o.offThreeYearBonus = numThreeYearBonus.Value;

                try
                {
                    if (o.InsertOffice() == 1)
                    {
                        lstOffice.Items.Add(o);
                        btnClear.PerformClick();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void numThreeYearBonus_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty && cmbCountry.SelectedIndex != -1 && txtCity.Text != string.Empty && txtAddress.Text != string.Empty)
            {
                Office o = new Office();
                o.idOffice = Convert.ToInt32(txtId.Text);
                o.offCountry = (Country)cmbCountry.SelectedItem;
                o.offCity = txtCity.Text;
                o.offAddress = txtAddress.Text;
                o.offThreeYearBonus = numThreeYearBonus.Value;

                try
                {
                    if (o.UpdateOffice() == 1)
                    {
                        int index = lstOffice.SelectedIndex;
                        lstOffice.Items.RemoveAt(index);
                        lstOffice.Items.Insert(index, o);
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
                Office o = new Office();
                o.idOffice = Convert.ToInt32(txtId.Text);

                if (MessageBox.Show("Are you sure you want to delete office " + o.idOffice + " ?", "Please confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (o.DeleteOffice() == 1)
                        {
                            int index = lstOffice.SelectedIndex;
                            lstOffice.Items.RemoveAt(index);
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
            cmbCountry.SelectedIndex = -1;
            txtCity.Text = string.Empty;
            txtAddress.Text = string.Empty;
            numThreeYearBonus.Value = 0;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
