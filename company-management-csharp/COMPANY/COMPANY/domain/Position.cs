using COMPANY_A2.domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace COMPANY_A2.domain
{
    internal class Position
    {
        public Position() { 
            _positionDAO = new PositionDAO();
        }

        public Position(int id)
        {
            _positionDAO = new PositionDAO();
            idPosition = id;
        }

        private readonly PositionDAO _positionDAO;
        public int idPosition { get; set;}
        public Employee posEmployee { get; set; }
        public Office posOffice { get; set; }
        public string posName { get; set; }
        public decimal posYearSalary { get; set; }
        public DateTime posStartDate { get; set; }
        public DateTime? posEndDate { get; set; }

        public void ReadPosition()
        {
            _positionDAO.Read(this);
        }

        public List<Position> ReadPositionsOfEmployee(Employee e)
        {
            return _positionDAO.GetPositionsOfEmployee(e);
        }

        public int InsertPosition()
        {
            return _positionDAO.Insert(this);
        }

        public List<Position> getPositions(Employee e)
        {
            return _positionDAO.GetPositionsOfEmployee(e);
        }

        public int UpdatePosition()
        {
            return _positionDAO.Update(this);
        }

        public int DeletePosition()
        {
            return _positionDAO.Delete(this);
        }

        public override string ToString()
        {
            string start = posStartDate.ToString("yyyy-MM-dd");
            string end = posEndDate.HasValue ? posEndDate.Value.ToString("yyyy-MM-dd") : "Current";
            return idPosition.ToString() + " - " + posName + " (" + start + " -> " + end + ")";
        }

        public string[] GetClassValues()
        {
            /* Decimals should not be quoted. */
            string endDateValue;
            if (posEndDate.HasValue)
            {
                endDateValue = "'" + posEndDate.Value.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                endDateValue = "NULL";
            }

            return new string[]
            {
                $"{idPosition}",
                $"{posEmployee.idEmployee}",
                $"{posOffice.idOffice}",
                "'" + posName + "'",
                posYearSalary.ToString("F2", CultureInfo.GetCultureInfo("en-US")),
                "'" + posStartDate.ToString("yyyy-MM-dd") + "'",
                endDateValue
            };
        }

    }
}
