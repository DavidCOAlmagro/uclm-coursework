using System;
using System.Collections.Generic;
using System.Windows.Forms;
using COMPANY_A2.domain;

namespace COMPANY_A2.presentation
{
    public partial class FormReportEmployeesByLocation : Form
    {
        public FormReportEmployeesByLocation()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // Clear the DataViewGrid
            dgvResults.Rows.Clear();

            // Obtaining data from already terminated positions.
            Employee employee = new Employee();
            List<List<object>> endedPositions = employee.GetEmployeePositionEnded();

            foreach (List<object> pair in endedPositions)
            {
                Office office = (Office)pair[0];
                Employee emp = (Employee)pair[1];
                int numOfThreeYearPeriods = (int)pair[2];
                DateTime startDate = (DateTime)pair[3];
                DateTime endDate = (DateTime)pair[4];

                dgvResults.Rows.Add(emp.idEmployee, emp.empName, startDate.ToShortDateString(), endDate.ToShortDateString(), office.offCity, numOfThreeYearPeriods);
            }

            // Obtaining data from ongoing positions.
            List<List<object>> ongoingPositions = employee.GetEmployeePositionOngoing();

            foreach (List<object> pair in ongoingPositions)
            {
                Office office = (Office) pair[0];
                Employee emp = (Employee) pair[1];
                int numOfThreeYearPeriods = (int) pair[2];
                DateTime startDate = (DateTime) pair[3];
                DateTime currentDate = (DateTime) pair[4];

                dgvResults.Rows.Add(emp.idEmployee, emp.empName, startDate.ToShortDateString(), currentDate.ToShortDateString(), office.offCity, numOfThreeYearPeriods);
            }
        }

        private void FormReportEmployeesByLocation_Load(object sender, EventArgs e)
        {

        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
