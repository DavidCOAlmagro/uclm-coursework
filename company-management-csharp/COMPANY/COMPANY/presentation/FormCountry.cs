using COMPANY_A2.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPANY_A2.presentation
{
    public partial class FormCountry : Form
    {
        public FormCountry()
        {
            InitializeComponent();
        }

        private void FormCountry_Load(object sender, EventArgs e)
        {
            Country aux = new Country();

            try
            {
                List<Country> countries = aux.ReadAllCountries();

                foreach (Country country in countries)
                {
                    lstCountries.Items.Add(country);
                }
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCountries.SelectedItem != null)
            {
                Country cAux = (Country) lstCountries.SelectedItem;
                txtId.Text = cAux.idCountry;
                txtName.Text = cAux.couName;
                numTaxBase.Value = cAux.couTaxBase;

                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            numTaxBase.Value = 0;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {
                string id = getCountryId(txtName.Text);
                Country c = new Country(id);
                c.couName = txtName.Text;
                c.couTaxBase = numTaxBase.Value;

                try
                {
                    if (c.InsertCountry() == 1)
                    {
                        lstCountries.Items.Add(c);
                        btnClear.PerformClick(); // Simulate that the clear button is pressed
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private string getCountryId(string name)
        {
            string idBase = name.Substring(0, 2).ToUpper();
            string id = idBase;
            bool found = false;
            Country cAux = new Country();

            for (int i = 2; i < name.Length && !found; i++)
            {
                id = idBase + name.Substring(i, 1).ToUpper();

                if (!cAux.IdAlreadyExists(id))
                {
                    found = true;
                }
            }

            return id;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text != string.Empty && txtName.Text != string.Empty)
            {
                Country c = new Country(txtId.Text);
                c.couName = txtName.Text;
                c.couTaxBase = numTaxBase.Value;

                try
                {
                    if (c.UpdateCountry() == 1)
                    {
                        int index = lstCountries.SelectedIndex;
                        lstCountries.Items.RemoveAt(index);
                        lstCountries.Items.Insert(index, c);
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
                Country c = new Country(txtId.Text);

                if (MessageBox.Show("Are you sure you want to delete " + c.idCountry + " ?", "Please confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    
                    try
                    {
                        if (c.DeleteCountry() == 1)
                        {
                            int index = lstCountries.SelectedIndex;
                            lstCountries.Items.RemoveAt(index);
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
    }
}
