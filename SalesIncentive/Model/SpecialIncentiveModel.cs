using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIncentive.Model
{
    public class SpecialIncentiveModel
    {
        Nullable<int> _EmployeeID;
        public Nullable<int> EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        string _EmployeeName;
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }

        Nullable<decimal> _ActualSales;

        public Nullable<decimal> ActualSales
        {
            get { return _ActualSales; }
            set { _ActualSales = value; }
        }

        Nullable<decimal> _TargetSales;
        public Nullable<decimal> TargetSales
        {
            get { return _TargetSales; }
            set { _TargetSales = value; }
        }

        Nullable<decimal> _Incentive;
        public Nullable<decimal> Incentive
        {
            get { return _Incentive; }
            set { _Incentive = value; }
        }

        Nullable<int> _DaysWorkPerEmployee;
        public Nullable<int> DaysWorkPerEmployee
        {
            get { return _DaysWorkPerEmployee; }
            set { _DaysWorkPerEmployee = value; }
        }

        Nullable<int> _TotalDaysWork;
        public Nullable<int> TotalDaysWork
        {
            get { return _TotalDaysWork; }
            set { _TotalDaysWork = value; }
        }

        Nullable<decimal> _IncentivePerDay;
        public Nullable<decimal> IncentivePerDay
        {
            get { return _IncentivePerDay; }
            set { _IncentivePerDay = value; }
        }

        Nullable<decimal> _TotalIncentive;
        public Nullable<decimal> TotalIncentive
        {
            get { return _TotalIncentive; }
            set { _TotalIncentive = value; }
        }

        string _PeriodFrom;
        public string PeriodFrom
        {
            get { return _PeriodFrom; }
            set { _PeriodFrom = value; }
        }

        string _PeriodTo;
        public string PeriodTo
        {
            get { return _PeriodTo; }
            set { _PeriodTo = value; }
        }

        Nullable<int> _GeneratedBy;
        public Nullable<int> GeneratedBy
        {
            get { return _GeneratedBy; }
            set { _GeneratedBy = value; }
        }

        string _GeneratedDate;
        public string GeneratedDate
        {
            get { return _GeneratedDate; }
            set { _GeneratedDate = value; }
        }

        string _Column1;
        public string Column1
        {
            get { return _Column1; }
            set { _Column1 = value; }
        }

        string _Column2;
        public string Column2
        {
            get { return _Column2; }
            set { _Column2 = value; }
        }

        string _Column3;
        public string Column3
        {
            get { return _Column3; }
            set { _Column3 = value; }
        }

        string _Column4;
        public string Column4
        {
            get { return _Column4; }
            set { _Column4 = value; }
        }

        string _Column5;
        public string Column5
        {
            get { return _Column5; }
            set { _Column5 = value; }
        }
    }
}
