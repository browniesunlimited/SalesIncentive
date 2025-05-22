using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIncentive.Model
{
    public class SalesIncentiveCrewModel
    {
        int? _EmpID;
        public int? EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        string _OutletName;
        public string OutletName
        {
            get { return _OutletName; }
            set { _OutletName = value; }
        }

        string _EmployeeName;
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }

        int _DaysWork;
        public int DaysWork
        {
            get { return _DaysWork; }
            set { _DaysWork = value; }
        }

        string _BankAccountNo;
        public string BankAccountNo
        {
            get { return _BankAccountNo; }
            set { _BankAccountNo = value; }
        }

        double _IncentiveAmount;

        public double IncentiveAmount
        {
            get { return _IncentiveAmount; }
            set { _IncentiveAmount = value; }
        }

        double _SpecialAmount;
        public double SpecialAmount
        {
            get { return _SpecialAmount; }
            set { _SpecialAmount = value; }
        }

        public double IncentiveToReceive
        {
            get
            {
                return Math.Round(IncentiveAmount * DaysWork,2);
            }
        }

        public double SpecialToReceive
        {
            get
            {
                if (SpecialAmount > 0)
                    return Math.Round(SpecialAmount * DaysWork,2);
                else
                    return 0;
            }
        }

        public double GrandTotal
        {
            get
            {
                return SpecialToReceive + IncentiveToReceive;
            }
        }
    }
}
