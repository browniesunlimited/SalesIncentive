using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIncentive.Model
{
    public class DaysWorkFinalModel
    {

    }
    public class IncentiveDaysWorkModel
    {
        int? _EMPID;
        public int? EMPID
        {
            get { return _EMPID; }
            set { _EMPID = value; }
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
            get { return _DaysWork ; }
            set { _DaysWork = value; }
        }

        string _OutletName;
        public string OutletName
        {
            get { return _OutletName; }
            set { _OutletName = value; }
        }

        string _BankAccountNo;
        public string BankAccountNo
        {
            get { return _BankAccountNo; }
            set { _BankAccountNo = value; }
        }
    }
}