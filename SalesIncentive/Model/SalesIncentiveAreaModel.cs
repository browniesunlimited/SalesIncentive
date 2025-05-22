using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIncentive.Model
{
    public class SalesIncentiveAreaModel
    {
        public int? EmpID { get; set; }
        
        string _EmployeeName;
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }

        public string BankAccount { get; set; }

        decimal _NetSales;
        public decimal NetSales
        {
            get { return _NetSales; }
            set { _NetSales = value; }
        }

        decimal _NetTarget;
        public decimal NetTarget
        {
            get { return _NetTarget; }
            set { _NetTarget = value; }
        }

        decimal _DayEnd;
        public decimal DayEnd
        {
            get { return _DayEnd; }
            set { _DayEnd = value; }
        }

        decimal _Variance;
        public decimal Variance
        {
            get { return _Variance; }
            set { _Variance = value; }
        }

        decimal _Spoilage;
        public decimal Spoilage
        {
            get { return _Spoilage; }
            set { _Spoilage = value; }
        }

        public double AreaIncentive
        {
            get 
            {
                if (NetSales > NetTarget)
                {
                    double total = double.Parse(NetSales.ToString()) * 0.0025;

                    return Math.Round(total, 2);
                }
                else
                    return 0;
            }
        }

        public double AreaSpecial
        {
            get 
            {
                if ((Incremental / NetSales) * 100 > 10)
                {
                    double total = double.Parse(Incremental.ToString()) * 0.01;

                    return Math.Round(total, 2);
                }
                else
                    return 0;
            }
        }

        public double GrandTotal
        {
            get
            {
                return Math.Round(AreaSpecial + AreaIncentive, 2);
            }
        }

        public decimal Incremental
        {
            get
            {
                return NetSales - NetTarget;
            }
        }

        public bool IfQualified
        {
            get
            {
                if (NetSales > NetTarget && // IF SALES IS HIGHER THAN TARGET SALES
                    (double.Parse(Variance.ToString()) / double.Parse(NetSales.ToString())) * 100 < 0.10 &&
                    (double.Parse(Spoilage.ToString()) / double.Parse(NetSales.ToString())) * 100 < 0.4 &&
                    (double.Parse(DayEnd.ToString()) / double.Parse(NetSales.ToString())) * 100 < 0.5
                    )
                    return true;
                else
                    return false;
            }
        }

        public string RPTQualified
        {
            get
            {
                if (IfQualified)
                    return "Y";
                else
                    return "N";
            }
        }

        public double TotalAmount
        {
            get
            {
                return Math.Round(AreaIncentive + AreaSpecial,2);
            }
        }

        public string VariancePercent
        {
            get
            {
                var result = Math.Round((Variance / NetSales) * 100, 2).ToString();

                return result + " %";
            }
        }

        public string SpoilagePercent
        {
            get
            {
                var result = Math.Round((Spoilage / NetSales) * 100, 2).ToString();

                return result + " %";
            }
        }

    }
}
