using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesIncentive.Model;
using System.IO;

namespace SalesIncentive.Service
{
    public class ExportService
    {

        public string ExportDistribution(string _fileName, List<SalesIncentiveCrewModel> _crew, List<SalesIncentiveAreaModel> _area)
        {
            string message = "";

            try
            {
                if (File.Exists(_fileName))
                    File.Delete(_fileName);

                using(StreamWriter sw = File.CreateText(_fileName))
                {
                    sw.WriteLine("BRANCH,EMPLOYEE ID,NAME,BANK ACCT,DAYS WORK,INCENTIVE AMOUNT PER DAY,SPECIAL AMOUNT PER DAY,SPECIAL AMOUNT PER DAY,TOTAL INCENTIVE AMOUNT,TOTAL SPECIAL AMOUNT,GRAND TOTAL");

                    _crew.ForEach(x =>
                    {
                        sw.WriteLine(x.OutletName + "," + x.EmpID + "," + x.EmployeeName.Replace(",", "") + "," + x.BankAccountNo + "," + x.DaysWork + "," + x.IncentiveAmount + "," +
                            x.SpecialAmount + "," + x.IncentiveToReceive + "," + x.SpecialToReceive + "," + x.GrandTotal);
                    });

                    sw.WriteLine("");

                    sw.WriteLine("");

                    sw.WriteLine("AREA NAME,BANK ACCT,INCENTIVE,SPECIAL INCENTIVE,GRAND TOTAL");

                    _area.ForEach(x =>
                    {
                        sw.WriteLine(x.EmployeeName.Replace(",", "") + "," + x.BankAccount + "," + x.AreaIncentive + "," + x.AreaSpecial + "," + x.GrandTotal);
                    });
                }
            }
            catch(Exception error)
            {
                message = error.Message;
            }

            return message;
        }
        public string ExportQualifiedCSV(string _fileName, List<IncentiveDataModel> _incentive, List<SalesIncentiveAreaModel> _area)
        {
            string message = "";

            try
            {
                if (File.Exists(_fileName))
                    File.Delete(_fileName);

                using (StreamWriter sw = File.CreateText(_fileName))
                {
                    sw.WriteLine("AREA MANAGER,OUTLET NO,OUTLET NAME,TARGET NS,ACTUAL NS,INCREMENTAL,0.50% INCENTIVE,1.5% SPECIAL,DAYEND 50,DAYEND 20,VARIANCE,SPOILAGE,COMPLAIN");

                    _incentive.ForEach(x =>
                    {
                        sw.WriteLine(x.EmployeeName.Replace(",","") + "," + x.OutletNo + "," + x.OutletName + "," + x.NetTarget + "," + x.NetSales + "," + x.Incremental + "," + x.CrewAmount + "," +
                            x.SpecialAmountForCrew + "," + x.DayEnd50 + "," + x.DayEnd20 + "," + x.Variance + "," + x.Spoilage + "," + x.Complain);
                    });

                    sw.WriteLine("");

                    sw.WriteLine("");

                    sw.WriteLine("AREA MANAGER,TARGET NS,ACTUAL NS, 0.25% INCENTIVE,1% SPECIAL,GRAND TOTAL,INCREMENTAL,DAYEND,VARIANCE,VARIANCE %,SPOILAGE,SPOILAGE %");

                    _area.ForEach(x =>
                    {
                        sw.WriteLine(x.EmployeeName.Replace(",","") + "," + x.NetTarget + "," + x.NetSales + "," + x.AreaIncentive + "," + x.AreaSpecial + "," + x.GrandTotal + "," +
                            x.Incremental + "," + x.DayEnd + "," + x.Variance + "," + x.VariancePercent + "," + x.Spoilage + "," + x.SpoilagePercent);
                    });
                }

            }
            catch(Exception error)
            {
                message = error.Message;
            }

            return message = "";
        }
    }
}
