using COMPANY_A2.persistence;
using System;
using System.Collections.Generic;
using System.Text;

using static COMPANY_A2.DBConstants;

namespace COMPANY_A2.domain
{
    internal class OfficeDAO
    {
        public OfficeDAO() {

        }

        public List<Office> ReadAll()
        {
            List<Office> res = new List<Office>();
            string sql = "SELECT * FROM " + TB_NAME_OFFICE + ";";
            List<string[]> data = DBBroker.GetInstance().Read(sql);

            foreach (string[] row in data)
            {
                Office o = new Office();
                o.idOffice = Convert.ToInt32(row[0]);
                o.offCountry = new Country(row[1]);
                o.offCity = row[2];
                o.offAddress = row[3];
                o.offThreeYearBonus = Convert.ToDecimal(row[4]);
                res.Add(o);
            }

            return res;
        }
        public void Read(Office o)
        {
            string sql = "SELECT * FROM " + TB_NAME_OFFICE + " WHERE idOffice = " + o.idOffice + ";";
            List<string[]> res = DBBroker.GetInstance().Read(sql);

            if (res.Count == 1)
            {
                string[] record = res[0];
                o.offCountry = new Country(record[1]);
                o.offCity = record[2];
                o.offAddress = record[3];
                o.offThreeYearBonus = Convert.ToDecimal(record[4]);
            }

        }

        public int Insert(Office o)
        {
            string[] values = o.GetClassValues();
            string sql = "INSERT INTO " + TB_NAME_OFFICE + " (offCountry, offCity, offAddress, offThreeYearBonus) VALUES (" + values[1] + ", " + values[2] + ", " + values[3] + ", " + values[4] + ");";

            int result = DBBroker.GetInstance().Change(sql);
            string sqlId = "SELECT MAX(idOffice) FROM " + TB_NAME_OFFICE + ";";
            int id = Convert.ToInt32(DBBroker.GetInstance().Read(sqlId)[0][0]);
            o.idOffice = id;
            return result;
        }


        public int Update(Office o)
        {
            string[] values = o.GetClassValues();
            string sql = "UPDATE " + TB_NAME_OFFICE + " SET offCountry = " + values[1] + ", offCity = " + values[2] + ", offAddress = " + values[3] + ", offThreeYearBonus = " + values[4] + " WHERE idOffice = " + values[0] + ";";

            return DBBroker.GetInstance().Change(sql);
        }

        public int Delete(Office o)
        {
            string sql = "DELETE FROM " + TB_NAME_OFFICE + " WHERE idOffice = " + o.idOffice + ";";

            return DBBroker.GetInstance().Change(sql);
        }

        internal bool IdAlreadyExists(int id)
        {
            string sql = "SELECT * FROM " + TB_NAME_OFFICE + " WHERE idOffice = " + id + ";";
            List<string[]> res = DBBroker.GetInstance().Read(sql);

            return res.Count > 0;
        }
    }
}
