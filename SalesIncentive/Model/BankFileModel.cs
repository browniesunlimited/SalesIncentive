using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIncentive.Model
{
    public class BankFileModel
    {
        long _ID;
        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

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


        string _BankAccount;
        public string BankAccount
        {
            get
            {
                return _BankAccount.Replace(" ", "");
            }
            set { _BankAccount = value; }
        }

        Nullable<decimal> _Incentive;
        public Nullable<decimal> Incentive
        {
            get { return _Incentive; }
            set { _Incentive = value; }
        }

        public int? Month { get; set; }

        public int? Year { get; set; }



        string _Particulars;
        public string Particulars
        {
            get { return _Particulars; }
            set { _Particulars = value; }
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

        string _Group1;
        public string Group1
        {
            get { return _Group1; }
            set { _Group1 = value; }
        }

        string _Group2;
        public string Group2
        {
            get { return _Group2; }
            set { _Group2 = value; }
        }

        string _Group3;
        public string Group3
        {
            get { return _Group3; }
            set { _Group3 = value; }
        }

        string _Group4;
        public string Group4
        {
            get { return _Group4; }
            set { _Group4 = value; }
        }

        string _Group5;
        public string Group5
        {
            get { return _Group5; }
            set { _Group5 = value; }
        }

        string _Group6;
        public string Group6
        {
            get { return _Group6; }
            set { _Group6 = value; }
        }

        string _Group7;
        public string Group7
        {
            get { return _Group7; }
            set { _Group7 = value; }
        }

        string _Group8;
        public string Group8
        {
            get { return _Group8; }
            set { _Group8 = value; }
        }

        string _FinalProduct;
        public string FinalProduct
        {
            get { return _FinalProduct; }
            set { _FinalProduct = value; }
        }

        string _PCName;
        public string PCName
        {
            get { return _PCName; }
            set { _PCName = value; }
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
