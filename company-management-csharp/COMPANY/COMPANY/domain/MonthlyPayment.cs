using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace COMPANY_A2.domain
{
    internal class MonthlyPayment
    {
        public int idMonthlyPayment { get; set; }
        public Employee payEmployee { get; set; }
        public int payYear { get; set; }
        public int payMonth { get; set; }
        public decimal paySalaryGross { get; set; }
        public decimal paySalaryNet { get; set; }
        public decimal payBonusApplied { get; set; }

        private readonly MonthlyPaymentDAO _monthlyPaymentDAO;
           
        public MonthlyPayment()
        {
            _monthlyPaymentDAO = new MonthlyPaymentDAO();
        }

        public MonthlyPayment(int id)
        {
            _monthlyPaymentDAO = new MonthlyPaymentDAO();
            idMonthlyPayment = id;
        }

        public List<MonthlyPayment> ReadAllMonthlyPayments()
        {
            return _monthlyPaymentDAO.ReadAll();
        }

        public void ReadMonthlyPayment()
        {
            _monthlyPaymentDAO.Read(this);
        }

        public int InsertMonthlyPayment()
        {
            return _monthlyPaymentDAO.Insert(this);
        }

        public int UpdateMonthlyPayment()
        {
            return _monthlyPaymentDAO.Update(this);
        }

        public int DeleteMonthlyPayment()
        {
            return _monthlyPaymentDAO.Delete(this);
        }
        public List<MonthlyPayment> getPaymentsMonth(int year, int month, int posOffice, bool shouldFilter)
        {
            return _monthlyPaymentDAO.getPaymentsMonth(year, month, posOffice, shouldFilter);
        }
        public List<MonthlyPayment> monthlyPaymentPerEmployee(int empID)
        {
            return _monthlyPaymentDAO.monthlyPaymentPerEmployee(empID);
        }

        public List<List<object>> GetExpensesPerOffice(int year, int month)
        {
            return _monthlyPaymentDAO.GetExpensesPerOffice(year, month);
        }

        public List<List<object>> GetExpensesPerCountry()
        {
            return _monthlyPaymentDAO.GetExpensesPerCountry();
        }

        public override string ToString()
        {
            string empId = payEmployee != null ? payEmployee.idEmployee.ToString() : "";
            return idMonthlyPayment.ToString() + " - Emp: " + empId + " / " + payYear + "-" + payMonth;
        }

        public string[] GetClassValues()
        {
            return new string[]
            {
                idMonthlyPayment.ToString(),
                payEmployee.idEmployee.ToString(),
                payYear.ToString(),
                payMonth.ToString(),
                paySalaryGross.ToString("F2", CultureInfo.GetCultureInfo("en-US")),
                paySalaryNet.ToString("F2", CultureInfo.GetCultureInfo("en-US")),
                payBonusApplied.ToString("F2", CultureInfo.GetCultureInfo("en-US"))
            };
        }
    }
}
