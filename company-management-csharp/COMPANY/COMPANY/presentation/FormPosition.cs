using COMPANY_A2.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace COMPANY_A2.presentation
{
    public partial class FormPosition : Form
    {

        public FormPosition()
        {
            InitializeComponent();
        }

        private void FormPosition_Load(object sender, EventArgs e)
        {
            try
            {
                Employee auxEmployee = new Employee();
                List<Employee> employees = auxEmployee.ReadAllEmployees();
                cmbEmployee.DataSource = employees;
                cmbEmployee.DisplayMember = "empName";
                cmbEmployee.ValueMember = "idEmployee";
                cmbEmployee.SelectedIndex = -1;

                Office auxOffice = new Office();
                List<Office> offices = auxOffice.ReadAllOffices();
                cmbOffice.DataSource = offices;
                cmbOffice.DisplayMember = "idOffice";
                cmbOffice.ValueMember = "idOffice";
                cmbOffice.SelectedIndex = -1;

                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstPosition.Items.Clear();

            if (cmbEmployee.SelectedItem != null)
            {
                Employee employee = (Employee)cmbEmployee.SelectedItem;

                try
                {
                    Position auxPosition = new Position();
                    List<Position> positions = auxPosition.ReadPositionsOfEmployee(employee);
                    foreach (Position p in positions)
                    {
                        lstPosition.Items.Add(p);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            cmbOffice.SelectedIndex = -1;
            numYearSalary.Value = 0;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
            dtpEndDate.Checked = false;

            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void lstPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPosition.SelectedItem is Position p)
            {
                txtId.Text = p.idPosition.ToString();
                txtName.Text = p.posName;
                numYearSalary.Value = p.posYearSalary;
                dtpStartDate.Value = p.posStartDate;

                if (p.posEndDate.HasValue)
                {
                    dtpEndDate.Checked = true;
                    dtpEndDate.Value = p.posEndDate.Value;
                }
                else
                {
                    dtpEndDate.Checked = false;
                }

                if (p.posOffice is not null)
                {
                    for (int i = 0; i < cmbOffice.Items.Count; i++)
                    {
                        if (cmbOffice.Items[i] is Office o && o.idOffice == p.posOffice.idOffice)
                        {
                            cmbOffice.SelectedIndex = i;
                            break;
                        }
                    }
                }

                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedItem is Employee employee
                && cmbOffice.SelectedItem is Office office
                && txtName.Text != string.Empty)
            {
                Position p = new Position
                {
                    posEmployee = employee,
                    posOffice = office,
                    posName = txtName.Text,
                    posYearSalary = numYearSalary.Value,
                    posStartDate = dtpStartDate.Value.Date,
                    posEndDate = dtpEndDate.Checked ? dtpEndDate.Value.Date : null
                };

                List<Position> positions = p.getPositions(employee);
                DateTime newStartDate = p.posStartDate.Date;
                DateTime? newEndDate = p.posEndDate;

                if (newEndDate.HasValue && newEndDate.Value.Date < newStartDate)
                {
                    MessageBox.Show("End date cannot be earlier than start date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (newEndDate.HasValue && newEndDate.Value.Date > DateTime.Today)
                {
                    MessageBox.Show("End date must be a date in the past.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool hasOverlap = false;
                foreach (Position pos in positions)
                {
                    DateTime existingStartDate = pos.posStartDate.Date;
                    DateTime? existingEndDate = pos.posEndDate;

                    DateTime effectiveNewEnd = newEndDate.HasValue ? newEndDate.Value.Date : DateTime.MaxValue.Date;
                    DateTime effectiveExistingEnd = existingEndDate.HasValue ? existingEndDate.Value.Date : DateTime.MaxValue.Date;

                    if (newStartDate <= effectiveExistingEnd && existingStartDate <= effectiveNewEnd)
                    {
                        hasOverlap = true;
                        break;
                    }
                }

                if (hasOverlap)
                {
                    MessageBox.Show("The employee already has a position during the specified period.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    if (p.InsertPosition() == 1)
                    {
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
            if (txtId.Text != string.Empty
                && cmbEmployee.SelectedItem is Employee employee
                && cmbOffice.SelectedItem is Office office
                && txtName.Text != string.Empty)
            {
                Position p = new Position
                {
                    idPosition = Convert.ToInt32(txtId.Text),
                    posEmployee = employee,
                    posOffice = office,
                    posName = txtName.Text,
                    posYearSalary = numYearSalary.Value,
                    posStartDate = dtpStartDate.Value.Date,
                    posEndDate = dtpEndDate.Checked ? dtpEndDate.Value.Date : (DateTime?) null
                };

                List<Position> positions = p.getPositions(employee);
                DateTime newStartDate = p.posStartDate.Date;
                DateTime? newEndDate = p.posEndDate;

                if (newEndDate.HasValue && newEndDate.Value.Date < newStartDate)
                {
                    MessageBox.Show("End date cannot be earlier than start date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (newEndDate.HasValue && newEndDate.Value.Date > DateTime.Today)
                {
                    MessageBox.Show("End date must be a date in the past.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool hasOverlap = false;
                foreach (Position pos in positions)
                {
                    if (pos.idPosition != p.idPosition)
                    {
                        DateTime existingStartDate = pos.posStartDate.Date;
                        DateTime? existingEndDate = pos.posEndDate;

                        DateTime effectiveNewEnd = newEndDate.HasValue ? newEndDate.Value.Date : DateTime.MaxValue.Date;
                        DateTime effectiveExistingEnd = existingEndDate.HasValue ? existingEndDate.Value.Date : DateTime.MaxValue.Date;

                        if (newStartDate <= effectiveExistingEnd && existingStartDate <= effectiveNewEnd)
                        {
                            hasOverlap = true;
                            break;
                        }
                    }
                }

                if (hasOverlap)
                {
                    MessageBox.Show("The employee already has a position during the specified period.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    if (p.UpdatePosition() == 1)
                    {
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
                Position p = new Position
                {
                    idPosition = Convert.ToInt32(txtId.Text)
                };

                if (MessageBox.Show("Are you sure you want to delete position " + p.idPosition + " ?", "Please confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    if (p.DeletePosition() == 1)
                    {
                        btnClear.PerformClick();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            cmbOffice.SelectedIndex = -1;
            numYearSalary.Value = 0;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
            dtpEndDate.Checked = false;

            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}