using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SalesIncentive.Model
{
    public class EmployeeModel
    {
        int _EmployeeID;
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        public string Fullname
        {
            get
            {
                return _LastName + " " + _FirstName + " " + MiddleInitial;
            }
        }

        string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        string _MiddleInitial;
        public string MiddleInitial
        {
            get { return _MiddleInitial; }
            set { _MiddleInitial = value; }
        }

        string _EmploymentStatus;
        public string EmploymentStatus
        {
            get { return _EmploymentStatus; }
            set { _EmploymentStatus = value; }
        }

        string _Division;
        public string Division
        {
            get { return _Division; }
            set { _Division = value; }
        }

        string _Department;
        public string Department
        {
            get { return _Department; }
            set
            {
                _Department = value;
            }
        }


        string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set { _Password = value; }
        }

        string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value; }
        }

        string _Active;
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        string _Expired;
        public string Expired
        {
            get { return _Expired; }
            set { _Expired = value; }
        }

        string _PassKey;
        public string PassKey
        {
            get { return _PassKey; }
            set { _PassKey = value; }
        }

        int _LoginFailed;
        public int LoginFailed
        {
            get { return _LoginFailed; }
            set { _LoginFailed = value; }
        }

        string _Locked;
        public string Locked
        {
            get { return _Locked; }
            set { _Locked = value; }
        }

        string _Roles;
        public string Roles
        {
            get { return _Roles; }
            set { _Roles = value; }
        }

        string _UserProgram;
        public string UserProgram
        {
            get { return _UserProgram; }
            set { _UserProgram = value; }
        }

        int _ModifiedBy;
        public int ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }

        string _ModifiedDate;
        public string ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }

        string _SystemDate;
        public string SystemDate
        {
            get { return _SystemDate; }
            set { _SystemDate = value;}
        }
    }
}
