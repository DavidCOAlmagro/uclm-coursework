using System;
using System.Collections.Generic;
using System.Text;

namespace COMPANY_A2.domain
{
    internal class GeneratorMonthlyPayment
    {
        public List<MonthlyPayment> ListMonthlyPayments { get; set; }

        public GeneratorMonthlyPayment()
        {
            ListMonthlyPayments = new List<MonthlyPayment>();
        }

        public List<MonthlyPayment> ReadMonthlyPayments(int year, int month)
        {
            MonthlyPayment aux = new MonthlyPayment();
            List<MonthlyPayment> all = aux.ReadAllMonthlyPayments();
            List<MonthlyPayment> res = new List<MonthlyPayment>();

            foreach (MonthlyPayment p in all)
            {
                if (p.payYear == year && p.payMonth == month)
                {
                    res.Add(p);
                }
            }

            return res;
        }

        private bool IsPastMonth(int year, int month)
        {
            DateTime monthStart = new DateTime(year, month, 1);
            DateTime monthEnd = monthStart.AddMonths(1).AddDays(-1);
            return monthEnd.Date <= DateTime.Today.Date;
        }

        private DateTime GetMonthStart(int year, int month)
        {
            return new DateTime(year, month, 1);
        }

        private DateTime GetMonthEnd(int year, int month)
        {
            return new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
        }

        private int GetDaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        private List<Employee> ReadAllEmployees()
        {
            Employee auxEmployee = new Employee();
            return auxEmployee.ReadAllEmployees();
        }

        private List<Position> ReadPositionsOfEmployee(Employee emp)
        {
            Position auxPosition = new Position();
            return auxPosition.ReadPositionsOfEmployee(emp);
        }

        private bool HasAnyActiveDayInMonth(Position pos, DateTime monthStart, DateTime monthEnd)
        {
            DateTime posStart = pos.posStartDate.Date;
            DateTime posEnd = pos.posEndDate.HasValue ? pos.posEndDate.Value.Date : DateTime.MaxValue.Date;

            DateTime overlapStart = posStart > monthStart ? posStart : monthStart;
            DateTime overlapEnd = posEnd < monthEnd ? posEnd : monthEnd;

            return overlapEnd >= overlapStart;
        }

        private int GetWorkedDaysInMonth(Position pos, DateTime monthStart, DateTime monthEnd)
        {
            DateTime posStart = pos.posStartDate.Date;
            DateTime posEnd = pos.posEndDate.HasValue ? pos.posEndDate.Value.Date : DateTime.MaxValue.Date;

            DateTime overlapStart = posStart > monthStart ? posStart : monthStart;
            DateTime overlapEnd = posEnd < monthEnd ? posEnd : monthEnd;

            if (overlapEnd < overlapStart)
            {
                return 0;
            }

            return (int)(overlapEnd - overlapStart).TotalDays + 1;
        }

        private int GetTotalWorkedDaysUpToCutoff(List<Position> positions, DateTime cutoff)
        {
            int total = 0;

            foreach (Position pos in positions)
            {
                DateTime s = pos.posStartDate.Date;
                DateTime e = pos.posEndDate.HasValue ? pos.posEndDate.Value.Date : DateTime.MaxValue.Date;

                if (e > cutoff)
                {
                    e = cutoff;
                }

                if (e >= s)
                {
                    total += (int)(e - s).TotalDays + 1;
                }
            }

            return total;
        }

        private int GetThreeYearPeriodsWorked(List<Position> positions, DateTime cutoff)
        {
            int totalDaysWorkedUpToMonthEnd = GetTotalWorkedDaysUpToCutoff(positions, cutoff);
            return totalDaysWorkedUpToMonthEnd / 1095;
        }

        private decimal GetBonusBaseForOffice(Position pos)
        {
            if (pos.posOffice == null)
            {
                return 0;
            }

            Office auxOffice = new Office();
            auxOffice.idOffice = pos.posOffice.idOffice;
            auxOffice.ReadOffice();
            return auxOffice.offThreeYearBonus;
        }

        private decimal GetCountryTaxBaseForOffice(Position pos)
        {
            if (pos.posOffice == null)
            {
                return 0;
            }

            Office auxOffice = new Office();
            auxOffice.idOffice = pos.posOffice.idOffice;
            auxOffice.ReadOffice();

            if (auxOffice.offCountry == null)
            {
                return 0;
            }

            Country auxCountry = new Country(auxOffice.offCountry.idCountry);
            auxCountry.ReadCountry();
            return auxCountry.couTaxBase;
        }

        private decimal CalculateProportionalSalaryGross(Position pos, int workedDaysInMonth, int daysInMonth)
        {
            decimal monthlyBaseSalary = pos.posYearSalary / 12m;
            return monthlyBaseSalary * workedDaysInMonth / daysInMonth;
        }

        private decimal CalculateProportionalBonus(Position pos, int workedDaysInMonth, int daysInMonth, int threeYearPeriods)
        {
            decimal bonusBase = GetBonusBaseForOffice(pos);
            decimal bonusForThisPosition = bonusBase * threeYearPeriods;
            return bonusForThisPosition * workedDaysInMonth / daysInMonth;
        }

        private decimal CalculateNetFromGross(decimal gross, decimal taxBase)
        {
            return gross * (1 - taxBase);
        }

        private bool ShouldGenerateForEmployee(List<Position> positions, DateTime monthStart, DateTime monthEnd)
        {
            foreach (Position pos in positions)
            {
                if (HasAnyActiveDayInMonth(pos, monthStart, monthEnd))
                {
                    return true;
                }
            }

            return false;
        }

        private MonthlyPayment BuildMonthlyPayment(Employee emp, int year, int month, decimal salaryGross, decimal bonusApplied, decimal gross, decimal net)
        {
            MonthlyPayment payment = new MonthlyPayment();
            payment.payEmployee = emp;
            payment.payYear = year;
            payment.payMonth = month;
            payment.paySalaryGross = salaryGross;
            payment.payBonusApplied = bonusApplied;
            payment.paySalaryNet = net;
            return payment;
        }

        public int GenerateMonthlyPayments(int year, int month)
        {
            ListMonthlyPayments.Clear();

            if (!IsPastMonth(year, month))
            {
                return 0;
            }

            DateTime monthStart = GetMonthStart(year, month);
            DateTime monthEnd = GetMonthEnd(year, month);
            int daysInMonth = GetDaysInMonth(year, month);

            List<Employee> employees = ReadAllEmployees();

            int created = 0;

            foreach (Employee emp in employees)
            {
                List<Position> positions = ReadPositionsOfEmployee(emp);

                bool shouldGenerate = ShouldGenerateForEmployee(positions, monthStart, monthEnd);

                decimal salaryGrossFromPositions = 0;
                decimal bonusAppliedTotal = 0;
                decimal grossTotal = 0;
                decimal netTotal = 0;

                if (shouldGenerate)
                {
                    int threeYearPeriods = GetThreeYearPeriodsWorked(positions, monthEnd);

                    foreach (Position pos in positions)
                    {
                        int workedDaysInThisPositionThisMonth = GetWorkedDaysInMonth(pos, monthStart, monthEnd);
                        if (workedDaysInThisPositionThisMonth > 0)
                        {
                            decimal proportionalSalary = CalculateProportionalSalaryGross(pos, workedDaysInThisPositionThisMonth, daysInMonth);
                            salaryGrossFromPositions += proportionalSalary;

                            decimal proportionalBonus = CalculateProportionalBonus(pos, workedDaysInThisPositionThisMonth, daysInMonth, threeYearPeriods);
                            bonusAppliedTotal += proportionalBonus;

                            decimal grossForThisPosition = proportionalSalary + proportionalBonus;
                            grossTotal += grossForThisPosition;

                            decimal taxBase = GetCountryTaxBaseForOffice(pos);
                            decimal netForThisPosition = CalculateNetFromGross(grossForThisPosition, taxBase);
                            netTotal += netForThisPosition;
                        }
                    }

                    if (grossTotal > 0)
                    {
                        MonthlyPayment payment = BuildMonthlyPayment(emp, year, month, salaryGrossFromPositions, bonusAppliedTotal, grossTotal, netTotal);

                        int inserted = payment.InsertMonthlyPayment();
                        if (inserted == 1)
                        {
                            created++;
                            ListMonthlyPayments.Add(payment);
                        }
                    }
                }
            }

            return created;
        }


    }
}
