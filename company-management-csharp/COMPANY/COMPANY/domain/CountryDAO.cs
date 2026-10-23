using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using COMPANY_A2.persistence;
using static COMPANY_A2.DBConstants;

namespace COMPANY_A2.domain
{
    internal class CountryDAO
    {

        public CountryDAO() {

        }

        public List<Country> ReadAll()
        {
            List<Country> res = new List<Country>();
            string sql = "SELECT * FROM " + TB_NAME_COUNTRY + ";";
            List<string[]> data = DBBroker.GetInstance().Read(sql);

            foreach (string[] row in data) {
                Country c = new Country(row[0]);
                c.couName = row[1];
                c.couTaxBase = Convert.ToDecimal(row[2]);
                res.Add(c);
            }

            return res;
        }
        public void Read(Country c)
        { 
            string[] data = c.GetClassValues();
            string sql = "SELECT * FROM " + TB_NAME_COUNTRY + " WHERE idCountry = " + data[0] + ";";
            List<string[]> res = DBBroker.GetInstance().Read(sql);

            if (res.Count == 1) { 
                string[] record = res[0];
                c.couName = record[1];
                c.couTaxBase = Convert.ToDecimal(record[2]);
            }

        }

        public int Insert(Country c)
        { 
            string[] values = c.GetClassValues();
            string sql = "INSERT INTO " + TB_NAME_COUNTRY + " (idCountry, couName, couTaxBase) VALUES (" + values[0] + "," + values[1] + "," + values[2] + ");";

            return DBBroker.GetInstance().Change(sql);
        }


        public int Update(Country c)
        {
            string[] values = c.GetClassValues();
            string sql = "UPDATE " + TB_NAME_COUNTRY + " SET couName = " + values[1] + ", couTaxBase = " + values[2] + " WHERE idCountry = " + values[0] + ";";

            return DBBroker.GetInstance().Change(sql);
        }

        public int Delete(Country c)
        { 
            string sql = "DELETE FROM " + TB_NAME_COUNTRY + " WHERE idCountry = '" + c.idCountry + "';";

            return DBBroker.GetInstance().Change(sql);
        }

        internal bool IdAlreadyExists(string id) { 
        
            string sql = "SELECT * FROM " + TB_NAME_COUNTRY + " WHERE idCountry = '" + id + "';";
            List<string[]> res = DBBroker.GetInstance().Read(sql);

            return res.Count > 0;
        }
    } 
}
