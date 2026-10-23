using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace COMPANY_A2.domain
{
    internal class Country
    {
        public Country() { 
            _countryDAO = new CountryDAO();
        }

        public Country(string idCountry)
        {
            _countryDAO = new CountryDAO();
            this.idCountry = idCountry;
        }

        public Country(string id, string name, decimal taxBase)
        {
            idCountry = id;
            couName = name;
            couTaxBase = taxBase;
            _countryDAO = new CountryDAO();
        }




        /*.NET creates the member variables when we declare the getter and setter.*/
        public string idCountry { get; set; }
        public string couName { get; set; }
        public decimal couTaxBase { get; set; }

        private readonly CountryDAO _countryDAO;

        public List<Country> ReadAllCountries()
        {
            return _countryDAO.ReadAll();
        }

        public void ReadCountry() {
            _countryDAO.Read(this);
        }

        public int InsertCountry()
        {
            return _countryDAO.Insert(this);
        }

        public int UpdateCountry()
        {
            return _countryDAO.Update(this);
        }

        public int DeleteCountry()
        {
            return _countryDAO.Delete(this);
        }

        internal bool IdAlreadyExists(string id)
        {
            return _countryDAO.IdAlreadyExists(id);
        }

        public override string ToString()
        {
            return idCountry + " - " + couName + " (Tax: " + couTaxBase.ToString("F2", CultureInfo.GetCultureInfo("en-US")) + ")";
        }

        public string[] GetClassValues()
        {  
            /* Decimals should not be quoted. */
            return new string[] { $"'{idCountry}'", $"'{couName}'", $"{couTaxBase.ToString("F2", CultureInfo.GetCultureInfo("en-US"))}" };
        }
    }
}
