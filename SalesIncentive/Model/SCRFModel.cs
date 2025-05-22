using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIncentive.Model
{
    public class SCRFModel
    {
        int _EmpID;
        public int EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }

        string _EmployeeName;
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }

        int _Month;
        public int Month
        {
            get { return _Month; }
            set { _Month = value; }
        }

        int _Year;
        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
    }
}
