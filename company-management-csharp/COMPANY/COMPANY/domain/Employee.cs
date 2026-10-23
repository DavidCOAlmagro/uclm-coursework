using COMPANY_A2.domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace COMPANY_A2.domain
{
    internal class Employee
    {

        public int idEmployee { get; set; }
        public string empName { get; set; }
        public string empIBAN { get; set; }

        public Country empCountry { get; set; }

        private readonly EmployeeDAO _employeeDAO;
        public Employee() { 
            _employeeDAO = new EmployeeDAO();
        }
        public Employee(int idEmployee)
        {
            _employeeDAO = new EmployeeDAO();
            this.idEmployee = idEmployee;
        }

        public Employee(int idEmployee, string name, string iban,Country country)
        {
            this.idEmployee = idEmployee;
            empName = name;
            empIBAN = iban;
            _employeeDAO = new EmployeeDAO();
            empCountry = country;
        }

        
        public List<Employee> ReadAllEmployees()
        {
                return _employeeDAO.ReadAll();
        }

        public void  ReadEmployee()
        {
            _employeeDAO.Read(this);
        }

        public int InsertEmployee()
        {
           return _employeeDAO.Insert(this);
        }
        public int UpdateEmployee()
        {
            return _employeeDAO.Update(this);
        }

        public int DeleteEmployee()
        {
            return _employeeDAO.Delete(this);
        }

        internal bool idEmployeeAlreadyExists(int idEmployee)
        {
            return _employeeDAO.IdAlreadyExists(idEmployee);
        }

        public override string ToString()
        {
            return "ID: " + idEmployee.ToString() + " - Name: " + empName + " - IBAN: (" + empIBAN + ")";
        }

        public string[] GetClassValues()
        {
            /* Decimals should not be quoted. */
            return new string[] { $"{idEmployee}", $"'{empName}'",$"'{empCountry.idCountry}'", $"'{empIBAN}'" };
        }

        public List<List<object>> GetEmployeePositionEnded()
        {
            return _employeeDAO.EmployeePositionEnded();
        }

        public List<List<object>> GetEmployeePositionOngoing()
        {
            return _employeeDAO.EmployeePositionOngoing();
        }
    }
}
