using COMPANY_A2.persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static COMPANY_A2.DBConstants;

namespace COMPANY_A2.domain
{
    internal class MonthlyPaymentDAO
    {

        //REPORT 1:
        public List<MonthlyPayment> getPaymentsMonth(int year, int month, int posOffice, bool shouldFilter)
        {
            List<MonthlyPayment> listMonthlyPayments = new List<MonthlyPayment>();
            string sql;
            if (shouldFilter)
            {
                sql = "SELECT distinct m.idMonthlyPayment, e.empName, m.payYear, m.payMonth, m.paySalaryGross, m.paySalaryNet, m.payBonusApplied, m.payEmployee " +
                    "FROM " + TB_NAME_PAYMENT + " m, " + TB_NAME_POSITION + " p, " + TB_NAME_EMPLOYEE + " e " +
                    "WHERE m.payEmployee = p.posEmployee " +
                        "AND m.payYear = " + year +
                        " AND m.payMonth = " + month +
                        " AND p.posOffice = " + posOffice +
                        " AND m.payEmployee = e.idEmployee " +
                    " ORDER BY m.paySalaryGross DESC;";
            }
            else
            {
                sql = "SELECT distinct m.idMonthlyPayment, e.empName, m.payYear, m.payMonth, m.paySalaryGross, m.paySalaryNet, m.payBonusApplied, m.payEmployee " +
                    "FROM " + TB_NAME_PAYMENT + " m, " + TB_NAME_POSITION + " p, " + TB_NAME_EMPLOYEE + " e " +
                    "WHERE m.payEmployee = p.posEmployee " +
                        "AND m.payYear = " + year +
                        " AND m.payMonth = " + month +
                        " AND m.payEmployee = e.idEmployee " +
                    " ORDER BY m.paySalaryGross DESC;";
            }
            List<string[]> query = DBBroker.GetInstance().Read(sql);

            foreach (string[] row in query)
            {
                MonthlyPayment p = new MonthlyPayment(Convert.ToInt32(row[0]));
                p.payEmployee = new Employee(Convert.ToInt32(row[7]));
                p.payEmployee.empName = row[1];
                p.payYear = Convert.ToInt32(row[2]);
                p.payMonth = Convert.ToInt32(row[3]);
                p.paySalaryGross = Convert.ToDecimal(row[4]);
                p.paySalaryNet = Convert.ToDecimal(row[5]);
                p.payBonusApplied = Convert.ToDecimal(row[6]);
                listMonthlyPayments.Add(p);
            }

            return listMonthlyPayments;
        }
        //REPORT 2:
        public List<MonthlyPayment> monthlyPaymentPerEmployee(int empID)
        {
            string sql;
            sql = "SELECT m.idMonthlyPayment, e.empName, m.payYear, m.payMonth, m.paySalaryGross, m.paySalaryNet, m.payBonusApplied, m.payEmployee " +
                "FROM " + TB_NAME_PAYMENT + " m, " + TB_NAME_EMPLOYEE + " e " +
                "WHERE m.payEmployee = " + empID + " AND m.payEmployee = e.idEmployee;";
            List<string[]> query = DBBroker.GetInstance().Read(sql);
            List<MonthlyPayment> listMonthlyPayments = new List<MonthlyPayment>();
            foreach (string[] row in query)
            {
                MonthlyPayment p = new MonthlyPayment(Convert.ToInt32(row[0]));
                p.payEmployee = new Employee(Convert.ToInt32(row[7]));
                p.payEmployee.empName = row[1];
                p.payYear = Convert.ToInt32(row[2]);
                p.payMonth = Convert.ToInt32(row[3]);
                p.paySalaryGross = Convert.ToDecimal(row[4]);
                p.paySalaryNet = Convert.ToDecimal(row[5]);
                p.payBonusApplied = Convert.ToDecimal(row[6]);
                listMonthlyPayments.Add(p);
            }

            return listMonthlyPayments;
        }

        // Report 4
        public List<List<object>> GetExpensesPerOffice(int year, int month)
        {
            string sql = "SELECT m.idMonthlyPayment, m.payEmployee, m.payYear, m.payMonth, SUM(m.paySalaryGross), SUM(m.paySalaryNet), m.payBonusApplied, o.offCity, e.empName " +
                         "FROM " + TB_NAME_PAYMENT + " m, " + TB_NAME_POSITION + " p, " + TB_NAME_OFFICE + " o, " + TB_NAME_EMPLOYEE + " e " +
                         "WHERE m.payEmployee = p.posEmployee " +
                         "AND m.payEmployee = e.idEmployee " +
                         "AND p.posOffice = o.idOffice " +
                         "AND m.payYear = " + year + " AND m.payMonth = " + month + " " +
                         "GROUP BY o.idOffice, o.offCity, m.idMonthlyPayment, m.payEmployee, m.payYear, m.payMonth, m.payBonusApplied, e.empName " +
                         "ORDER BY o.offCity, m.payEmployee;";

            List<string[]> query = DBBroker.GetInstance().Read(sql);
            List<List<object>> listMonthlyPayments = new List<List<object>>();
            List<object> monthlyPaymentAndOffice = new List<object>();

            foreach (string[] row in query)
            {
                monthlyPaymentAndOffice.Clear();
                MonthlyPayment p = new MonthlyPayment(Convert.ToInt32(row[0]));
                p.payEmployee = new Employee(Convert.ToInt32(row[1]));
                p.payEmployee.empName = row[8];
                p.payYear = Convert.ToInt32(row[2]);
                p.payMonth = Convert.ToInt32(row[3]);
                p.paySalaryGross = Convert.ToDecimal(row[4]);
                p.paySalaryNet = Convert.ToDecimal(row[5]);
                p.payBonusApplied = Convert.ToDecimal(row[6]);
                
                Office o = new Office();
                o.offCity = row[7];

                monthlyPaymentAndOffice.Add(p);
                monthlyPaymentAndOffice.Add(o);
                listMonthlyPayments.Add(new List<object>(monthlyPaymentAndOffice));
            }

            return listMonthlyPayments;
        }

        // Report 5
        public List<List<object>> GetExpensesPerCountry()
        {
            string sql = "SELECT m.idMonthlyPayment, m.payEmployee, m.payYear, m.payMonth, SUM(m.paySalaryGross), SUM(m.paySalaryNet), m.payBonusApplied, c.couName, e.empName " +
                         "FROM " + TB_NAME_PAYMENT + " m, " + TB_NAME_POSITION + " p, " + TB_NAME_OFFICE + " o, " + TB_NAME_COUNTRY + " c, " + TB_NAME_EMPLOYEE + " e " +
                         "WHERE m.payEmployee = p.posEmployee " +
                         "AND m.payEmployee = e.idEmployee " +
                         "AND p.posOffice = o.idOffice " +
                         "AND o.offCountry = c.idCountry " +
                         "GROUP BY c.idCountry, c.couName, m.payYear, m.payMonth, m.idMonthlyPayment, m.payEmployee, m.payBonusApplied, e.empName " +
                         "ORDER BY c.couName, m.payYear, m.payMonth;";
            List<string[]> query = DBBroker.GetInstance().Read(sql);
            List<List<object>> listMonthlyPayments = new List<List<object>>();
            List<object> monthlyPaymentAndCountry = new List<object>();

            foreach (string[] row in query)
            {
                monthlyPaymentAndCountry.Clear();

                MonthlyPayment p = new MonthlyPayment(Convert.ToInt32(row[0]));
                p.payEmployee = new Employee(Convert.ToInt32(row[1]));
                p.payEmployee.empName = row[8];
                p.payYear = Convert.ToInt32(row[2]);
                p.payMonth = Convert.ToInt32(row[3]);
                p.paySalaryGross = Convert.ToDecimal(row[4]);
                p.paySalaryNet = Convert.ToDecimal(row[5]);
                p.payBonusApplied = Convert.ToDecimal(row[6]);

                Country c = new Country();
                c.couName = row[7];

                monthlyPaymentAndCountry.Add(p);
                monthlyPaymentAndCountry.Add(c);
                listMonthlyPayments.Add(new List<object>(monthlyPaymentAndCountry));
            }

            return listMonthlyPayments;
        }

        public List<MonthlyPayment> ReadAll()
        {
            List<MonthlyPayment> res = new List<MonthlyPayment>();
            string sql = "SELECT * FROM " + TB_NAME_PAYMENT + ";";
            List<string[]> data = DBBroker.GetInstance().Read(sql);

            foreach (string[] row in data)
            {
                MonthlyPayment p = new MonthlyPayment(Convert.ToInt32(row[0]));
                p.payEmployee = new Employee(Convert.ToInt32(row[1]));
                p.payYear = Convert.ToInt32(row[2]);
                p.payMonth = Convert.ToInt32(row[3]);
                p.paySalaryGross = Convert.ToDecimal(row[4]);
                p.paySalaryNet = Convert.ToDecimal(row[5]);
                p.payBonusApplied = Convert.ToDecimal(row[6]);
                res.Add(p);
            }

            return res;
        }

        public void Read(MonthlyPayment p)
        {
            string[] data = p.GetClassValues();
            string sql = "SELECT * FROM " + TB_NAME_PAYMENT + " WHERE idMonthlyPayment = " + data[0] + ";";
            List<string[]> res = DBBroker.GetInstance().Read(sql);

            if (res.Count == 1)
            {
                string[] record = res[0];
                p.payEmployee = new Employee(Convert.ToInt32(record[1]));
                p.payYear = Convert.ToInt32(record[2]);
                p.payMonth = Convert.ToInt32(record[3]);
                p.paySalaryGross = Convert.ToDecimal(record[4]);
                p.paySalaryNet = Convert.ToDecimal(record[5]);
                p.payBonusApplied = Convert.ToDecimal(record[6]);
            }
        }

        public int Insert(MonthlyPayment p)
        {
            string[] values = p.GetClassValues();
            string sql = "INSERT INTO " + TB_NAME_PAYMENT + " (payEmployee, payYear, payMonth, paySalaryGross, paySalaryNet, payBonusApplied) VALUES (" +
                         values[1] + ", " + values[2] + ", " + values[3] + ", " + values[4] + ", " + values[5] + ", " + values[6] + ");";
            int result = DBBroker.GetInstance().Change(sql);
            string sqlId = "SELECT MAX(idMonthlyPayment) FROM " + TB_NAME_PAYMENT + ";";
            int id = Convert.ToInt32(DBBroker.GetInstance().Read(sqlId)[0][0]);
            p.idMonthlyPayment = id;
            return result;
        }

        public int Update(MonthlyPayment p)
        {
            string[] values = p.GetClassValues();
            string sql = "UPDATE " + TB_NAME_PAYMENT + " SET payEmployee = " + values[1] + ", payYear = " + values[2] + ", payMonth = " + values[3] +
                         ", paySalaryGross = " + values[4] + ", paySalaryNet = " + values[5] + ", payBonusApplied = " + values[6] +
                         " WHERE idMonthlyPayment = " + values[0] + ";";
            return DBBroker.GetInstance().Change(sql);
        }

        public int Delete(MonthlyPayment p)
        {
            string sql = "DELETE FROM " + TB_NAME_PAYMENT + " WHERE idMonthlyPayment = " + p.idMonthlyPayment + ";";
            return DBBroker.GetInstance().Change(sql);
        }
    }
}
