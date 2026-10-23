using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using COMPANY_A2.persistence;
using static COMPANY_A2.DBConstants;

namespace COMPANY_A2.domain
{
    internal class PositionDAO
    {

        public List<Position> GetPositionsOfEmployee(Employee e)
        {
            List<Position> res = new List<Position>();
            string sql = "SELECT * FROM " + TB_NAME_POSITION + " WHERE posEmployee = " + e.idEmployee + ";";
            List<string[]> data = DBBroker.GetInstance().Read(sql);
            foreach (string[] row in data)
            {
                Position p = new Position(Convert.ToInt32(row[0]));
                p.posEmployee = e;
                p.posOffice = new Office();
                p.posOffice.idOffice = Convert.ToInt32(row[2]);
                p.posName = row[3];
                p.posYearSalary = Convert.ToDecimal(row[4]);
                p.posStartDate = Convert.ToDateTime(row[5]);
                p.posEndDate = string.IsNullOrEmpty(row[6]) ? null : Convert.ToDateTime(row[6]);
                res.Add(p);
            }
            return res;
        }

        public int Insert(Position p)
        {
            string[] values = p.GetClassValues();
            string sql = "INSERT INTO " + TB_NAME_POSITION + " (posEmployee, posOffice, posName, posYearSalary, posStartDate, posEndDate) VALUES (" + 
                         values[1] + ", " + values[2] + ", " + values[3] + ", " + values[4] + ", " + values[5] + ", " + values[6] + ");";
            int result = DBBroker.GetInstance().Change(sql);
            string sqlId = "SELECT MAX(idPosition) FROM " + TB_NAME_POSITION + ";";
            int id = Convert.ToInt32(DBBroker.GetInstance().Read(sqlId)[0][0]);
            p.idPosition = id;
            return result;
        }


        public void Read(Position p)
        {
            string[] data = p.GetClassValues();
            string sql = "SELECT * FROM " + TB_NAME_POSITION + " WHERE idPosition = " + data[0] + ";";
            List<string[]> res = DBBroker.GetInstance().Read(sql);

            if (res.Count == 1)
            {
                string[] record = res[0];
                p.posEmployee = new Employee(Convert.ToInt32(record[1]));
                p.posOffice = new Office();
                p.posOffice.idOffice = Convert.ToInt32(record[2]);
                p.posName = record[3];
                p.posYearSalary = Convert.ToDecimal(record[4]);
                p.posStartDate = Convert.ToDateTime(record[5]);
                p.posEndDate = string.IsNullOrEmpty(record[6]) ? null : Convert.ToDateTime(record[6]);
            }
        }

        public int Update(Position p)
        {
           
            string[] values = p.GetClassValues();
            string sql = "UPDATE " + TB_NAME_POSITION + " SET posEmployee = " + values[1] + ", posOffice = " + values[2] + 
                         ", posName = " + values[3] + ", posYearSalary = " + values[4] + ", posStartDate = " + values[5] + 
                         ", posEndDate = " + values[6] + " WHERE idPosition = " + values[0] + ";";

            return DBBroker.GetInstance().Change(sql);
        }

        public int Delete(Position p)
        {
            string sql = "DELETE FROM " + TB_NAME_POSITION + " WHERE idPosition = " + p.idPosition + ";";

            return DBBroker.GetInstance().Change(sql);
        }

        internal bool IdAlreadyExists(int id)
        {
            string sql = "SELECT * FROM " + TB_NAME_POSITION + " WHERE idPosition = " + id + ";";
            List<string[]> res = DBBroker.GetInstance().Read(sql);

            return res.Count > 0;
        }
    }
}
