using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIncentive.Model
{
    public class IncentiveDataModel
    {
        int? _OutletNo;

        public int? OutletNo
        {
            get { return _OutletNo; }
            set { _OutletNo = value; }
        }

        string _OutletName;
        public string OutletName
        {
            get { return _OutletName; }
            set { _OutletName = value; }
        }

        int? _Month;

        public int? Month
        {
            get { return _Month; }
            set { _Month = value; }
        }

        int? _Year;
        public int? Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        decimal _TargetSales;
        public decimal TargetSales
        {
            get { return _TargetSales; }
            set { _TargetSales = value; }
        }

        decimal _NetTarget;
        public decimal NetTarget
        {
            get { return _NetTarget; }
            set { _NetTarget = value; }
        }

        decimal _NetSales;
        public decimal NetSales
        {
            get { return _NetSales; }
            set { _NetSales = value; }
        }

        decimal _DayEnd50;
        public decimal DayEnd50
        {
            get { return _DayEnd50; }
            set { _DayEnd50 = value; }
        }

        decimal _DayEnd20;
        public decimal DayEnd20
        {
            get { return _DayEnd20; }
            set { _DayEnd20 = value; }
        }

        public decimal DayEndTotal
        {
            get
            {
                return _DayEnd20 + _DayEnd50;
            }
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

        int? _EmpId;
        public int? EmpID
        {
            get { return _EmpId; }
            set { _EmpId = value; }
        }

        int _EmpCount;
        public int EmpCount
        {
            get { return _EmpCount; }
            set { _EmpCount = value; }
        }

        string _EmployeeName;
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }

        int _TotalDaysWork;
        public int TotalDaysWork
        {
            get { return _TotalDaysWork; }
            set { _TotalDaysWork = value; }
        }

        string _Complain;
        public string Complain
        {
            get
            {
                return _Complain.Replace(" ", "");
            }
            set { _Complain = value; }
        }

        public decimal Incremental
        {
            get { return NetSales - NetTarget; }
        }

        public bool IfQualified
        {
            get
            {
                //ALL CONDITION MUST BE TRUE TO BE ACTIVATED
                if (NetSales > NetTarget &&                                              //IF ACTUAL SALES IS HIGHER THAN TARGET SALES
                    Complain == "N" &&                                                        //IF OUTLET HAS NO COMPLAINS
                    (double.Parse(Variance.ToString()) / double.Parse(NetSales.ToString())) * 100 < 0.10  &&      //IF VARIANCE IS NOT GREATER THAN 0.10%
                    (double.Parse(Spoilage.ToString()) / double.Parse(NetSales.ToString())) * 100 < 0.4 &&                                 //IF SPOILAGE IS LESS THAN 0.4%
                    (double.Parse(DayEndTotal.ToString())/ double.Parse(NetSales.ToString())) * 100 < 0.5                //DAY END 50% and 20% MUST NOT EXCEED 0.5% of NET SALES
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
        public double ClusterManagerAmount //0.25% OF ACTUAL SALES
        {
            get
            {
                if (IfQualified)
                    return Double.Parse(NetSales.ToString()) * 0.0025;
                else
                    return 0;
            }
        }

        public double CrewAmount // 0.50% OF ACTUAL SALES
        {
            get
            {
                if (IfQualified)
                    return Math.Round(Double.Parse(NetSales.ToString()) * 0.005,2);
                else
                    return 0;
            }
        }

        public double SpecialAmountForCluster //1% of Incremental Amount
        {
            get
            {
                if ((Double.Parse(Incremental.ToString()) / double.Parse(NetTarget.ToString())) * 100 > 10 && IfQualified)
                    return Math.Round(Double.Parse(Incremental.ToString()) * 0.01,2);
                else
                    return 0;
            }
        }

        public double SpecialAmountForCrew // 1.5% Incremental Amount
        {
            get
            {
                if ((Double.Parse(Incremental.ToString()) / (double.Parse(NetTarget.ToString()))) * 100 > 10 && IfQualified)
                    return Math.Round(Double.Parse(Incremental.ToString()) * 0.015, 2);
                else
                    return 0;
            }
        }

        public double IncentivePerCew
        {
            get
            {
                 return Math.Round(CrewAmount / TotalDaysWork,2);
            }
        }

        public double SpecialPerCrew
        {
            get
            {
                return Math.Round(SpecialAmountForCrew / TotalDaysWork, 2);
            }
        }

        public string BankAccount { get; set; }
    }
}
