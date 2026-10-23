using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace COMPANY_A2.domain
{
    internal class Office
    {

        public Office()
        {
            _officeDAO = new OfficeDAO();
        }

        public Office(int idOffice)
        {
            this.idOffice = idOffice;
        }

        public int idOffice {  get; set; }
        public Country offCountry {  get; set; }
        public string offCity { get; set; }
        public string offAddress { get; set; }
        public decimal offThreeYearBonus { get; set; }
           
        private readonly OfficeDAO _officeDAO;

        public List<Office> ReadAllOffices()
        {
            return _officeDAO.ReadAll();
        }

        public void ReadOffice()
        {
            _officeDAO.Read(this);
        }

        public int InsertOffice()
        {
            return _officeDAO.Insert(this);
        }

        public int UpdateOffice()
        {
            return _officeDAO.Update(this);
        }

        public int DeleteOffice()
        {
            return _officeDAO.Delete(this);
        }

        internal bool IdAlreadyExists(int id)
        {
            return _officeDAO.IdAlreadyExists(id);
        }

        public override string ToString()
        {
            string countryId = offCountry != null ? offCountry.idCountry : "";
            return Convert.ToString(idOffice) + " - " + countryId + " / " + offCity;
        }


        public string[] GetClassValues()
        {
            string countryValue = offCountry != null ? "'" + offCountry.idCountry + "'" : "NULL";
            string cityValue = offCity != null ? "'" + offCity + "'" : "NULL";
            string addressValue = offAddress != null ? "'" + offAddress + "'" : "NULL";

            return new string[] { $"{idOffice}", countryValue, cityValue, addressValue, offThreeYearBonus.ToString("F2", CultureInfo.GetCultureInfo("en-US")) };
        }
    }
}
