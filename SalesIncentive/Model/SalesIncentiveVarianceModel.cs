using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIncentive.Model
{
    public class SalesIncentiveVarianceModel
    {
        private long _ID;
        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int? _OutletNo;
        public int? OutletNo
        {
            get { return _OutletNo; }
            set { _OutletNo = value; }
        }

        private string _OutletName;
        public string OutletName
        {
            get { return _OutletName; }
            set { _OutletName = value; }
        }

        private decimal _Amount;
        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        private decimal _Spoilage;
        public decimal Spoilage
        {
            get { return _Spoilage; }
            set { _Spoilage = value; }
        }

        private int _ModifiedBy;
        public int ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }

        private DateTime _ModifiedDate;
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }

        private int _DateMonth;
        public int DateMonth
        {
            get { return _DateMonth; }
            set { _DateMonth = value; }
        }

        private int _DateYear;
        public int DateYear
        {
            get { return _DateYear; }
            set { _DateYear = value; }
        }
    }
}
