using COMPANY_A2.persistence;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static COMPANY_A2.DBConstants;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace COMPANY_A2.domain
{
    internal class EmployeeDAO
    {
        // REPORT 3:

        public List<List<object>> EmployeePositionEnded()
        {
            string sql = "SELECT o.idOffice, o.offCity, e.idEmployee, e.empName, e.empCountry, e.empIBAN, p.posStartDate, p.posEndDate " +
                         "FROM " + TB_NAME_EMPLOYEE + " e," + TB_NAME_POSITION + " p, " + TB_NAME_OFFICE + " o " +
                         "WHERE p.posEndDate IS NOT NULL AND e.idEmployee = p.posEmployee AND o.idOffice = p.posOffice " +
                         "ORDER BY o.offCity, e.empName;";

            List<string[]> queryResults = DBBroker.GetInstance().Read(sql);
            List<List<object>> result = new List<List<object>>();

            foreach (var row in queryResults)
            {
                Office o = new Office(Convert.ToInt32(row[0]));
                o.offCity = row[1];

                Employee e = new Employee(Convert.ToInt32(row[2]));
                e.empName = row[3];
                e.empCountry = new Country(row[4]);
                e.empIBAN = row[5];


                DateTime startDate = DateTime.Parse(row[6]);
                DateTime endDate = DateTime.Parse(row[7]);
                int numOfThreeYearPeriods = (endDate.Year - startDate.Year) / 3;

                result.Add(new List<object> { o, e, numOfThreeYearPeriods, startDate, endDate });
            }

            return result;
        }

        public List<List<object>> EmployeePositionOngoing()
        {
            string sql = "SELECT o.idOffice, o.offCity, e.idEmployee, e.empName, e.empCountry, e.empIBAN, p.posStartDate " +
                         "FROM " + TB_NAME_EMPLOYEE + " e, " + TB_NAME_POSITION + " p, " + TB_NAME_OFFICE + " o " +
                         "WHERE p.posEndDate IS NULL AND e.idEmployee = p.posEmployee AND o.idOffice = p.posOffice " +
                         "ORDER BY o.offCity, e.empName;";

            List<string[]> queryResults = DBBroker.GetInstance().Read(sql);
            List<List<object>> result = new List<List<object>>();

            foreach (var row in queryResults)
            {
                Office o = new Office(Convert.ToInt32(row[0]));
                o.offCity = row[1];

                Employee e = new Employee(Convert.ToInt32(row[2]));
                e.empName = row[3];
                e.empCountry = new Country(row[4]);
                e.empIBAN = row[5];


                DateTime startDate = DateTime.Parse(row[6]);
                DateTime currentDate = DateTime.Now;
                int numOfThreeYearPeriods = (currentDate.Year - startDate.Year) / 3;

                result.Add(new List<object> { o, e, numOfThreeYearPeriods, startDate, currentDate });
            }

            return result;
        }


        public int Insert(Employee e)
    {
        string sql = "INSERT INTO " + TB_NAME_EMPLOYEE + " (empName, empCountry, empIBAN) VALUES ('" + e.empName + "', '" + e.empCountry.idCountry + "', '" + e.empIBAN + "');";
        int result = DBBroker.GetInstance().Change(sql);
        string sqlId = "SELECT MAX(idEmployee) FROM " + TB_NAME_EMPLOYEE + ";";
        int id = Convert.ToInt32(DBBroker.GetInstance().Read(sqlId)[0][0]);
        e.idEmployee = id;
        return result;
    }
        public List<Employee> ReadAll()
        {
            List<Employee> res = new List<Employee>();
            string sql = "SELECT * FROM " + TB_NAME_EMPLOYEE + ";";
            List<string[]> data = DBBroker.GetInstance().Read(sql);

            foreach (string[] row in data)
            {
                Employee e = new Employee(Convert.ToInt32(row[0]));
                e.empName = row[1];
                e.empCountry = new Country(row[2]);
                e.empIBAN = (row[3]);
                res.Add(e);
            }

            return res;
        }
        public void Read(Employee e)
        {
            string[] data = e.GetClassValues();
            string sql = "SELECT * FROM " + TB_NAME_EMPLOYEE + " WHERE idEmployee = " + data[0] + ";";
            List<string[]> res = DBBroker.GetInstance().Read(sql);

            if (res.Count == 1)
            {
                string[] record = res[0];
                e.empName = record[1];
                e.empCountry = new Country(record[2]);
                e.empIBAN = (record[3]);
            }

        }

        public int Update(Employee e)
        {
            string[] values = e.GetClassValues();
           string sql = "UPDATE " + TB_NAME_EMPLOYEE + " SET empName = " + values[1] + ", empCountry = " + values[2] + ", empIBAN = " + values[3] + " WHERE idEmployee = " + values[0] + ";";

            return DBBroker.GetInstance().Change(sql);
        }

        public int Delete(Employee e)
        {
            string sql = "DELETE FROM " + TB_NAME_EMPLOYEE + " WHERE idEmployee = " + e.idEmployee + ";";

            return DBBroker.GetInstance().Change(sql);
        }

        internal bool IdAlreadyExists(int id)
        {

            string sql = "SELECT * FROM " + TB_NAME_EMPLOYEE + " WHERE idEmployee = " + id + ";";
            List<string[]> res = DBBroker.GetInstance().Read(sql);

            return res.Count > 0;
        }
    }
}


