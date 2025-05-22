using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesIncentive.Model;
using System.Data.Entity;

namespace SalesIncentive.Service
{
    public class DatabaseService
    {




        public List<SpecialIncentiveModel> GetAllSpecialIncentive(string _dateFrom, string _dateTo)
        {
            var db = new KHAS_BO_BUEntities();

            var query = from i in db.T_SALES_INCENTIVE_SPECIAL
                        where i.PERIOD_FROM == _dateFrom && i.PERIOD_TO == _dateTo && i.DAYS_WORKED_PER_EMP > 0
                        select new SpecialIncentiveModel
                        {
                            EmployeeID = i.EMPID,
                            EmployeeName = i.EMPNAME,
                            DaysWorkPerEmployee = i.DAYS_WORKED_PER_EMP,
                            ActualSales = i.ACTUAL_SALES,
                            Column1 = i.COLUMN1,
                            Column2 = i.COLUMN2,
                            Column3 = i.COLUMN3,
                            Column4 = i.COLUMN4,
                            Column5 = i.COLUMN5,
                            GeneratedBy = i.GENERATED_BY,
                            GeneratedDate = i.GENERATED_DATE,
                            Incentive = i.INCENTIVE,
                            TargetSales = i.TARGET_SALES,
                            TotalDaysWork = i.TOTAL_DAYS_WORKED,
                            TotalIncentive = i.TOTAL_INCENTIVE,
                            IncentivePerDay = i.INCENTIVE_PER_DAY,
                            PeriodFrom = i.PERIOD_FROM,
                            PeriodTo = i.PERIOD_TO
                        };

            return query.ToList();
        }

        private List<AreaBankInfo> GetAreaBankInfo()
        {
            var db = new KHAS_BO_BUEntities();

            var query = from i in db.NEW_SALES_INCENTIVE_AREA_BNK
                        select new AreaBankInfo
                        {
                            EmpID = i.EMPID,
                            BankAccount = i.BANK_ACCT_NO
                        };

            return query.ToList();
        }

        public List<SalesIncentiveAreaModel> GetAllIncentiveArea(List<IncentiveDataModel> _incentiveList)
        {
            var query = _incentiveList.GroupBy(r => r.EmployeeName).Select(cl => new SalesIncentiveAreaModel
            {
                EmployeeName = cl.First().EmployeeName,
                DayEnd = cl.Sum(c=>c.DayEndTotal),
                NetSales = cl.Sum(c=>c.NetSales),
                NetTarget = cl.Sum(c=>c.NetTarget),
                Spoilage = cl.Sum(c=>c.Spoilage),
                Variance = cl.Sum(c=>c.Variance)
            }).ToList();

            var areaBankList = GetAreaBankInfo();

            query.ForEach(x =>
            {
                var forID = _incentiveList.Where(r => r.EmployeeName == x.EmployeeName).FirstOrDefault();

                if (forID != null)
                    x.EmpID = forID.EmpID;

                var temp = areaBankList.Where(r => r.EmpID == x.EmpID).FirstOrDefault();

                if(temp != null)
                    x.BankAccount = temp.BankAccount;
            });

            return query.ToList();
        }


        public List<IncentiveDataModel> GetAllIncentive(int _month, int _year)
        {
            var db = new KHAS_BO_BUEntities();

            var query = from i in db.NEW_SALES_INCENTIVE_VIEW
                        where i.MONTH == _month && i.YEAR == _year
                        orderby i.EMP_NAME ascending
                        select new IncentiveDataModel
                        {
                            Complain = i.COMPLAIN,
                            DayEnd20 = i.DAYEND20,
                            DayEnd50 = i.DAYEND50,
                            EmpID = i.EMPID,
                            EmployeeName = i.EMP_NAME,
                            Month = i.MONTH,
                            NetSales = i.NETSALES,
                            NetTarget = i.NET_TARGET,
                            OutletName = i.OUTLET_NAME,
                            OutletNo = i.OUTLET_NO,
                            Spoilage = i.SPOILAGE,
                            Variance = i.VARIANCE,
                            TargetSales = i.TARGET_SALES,
                            Year = i.YEAR
                        };

            return query.ToList();
        }




        public string SaveSpecialIncentive(string _dateFrom, string _dateTo, string _dateToday, string _username)
        {
            try
            {
                var db = new KHAS_BO_BUEntities();

                var result = db.SpecialIncentivebyRam(_dateTo, _dateFrom, _dateToday, _username);

                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string SaveSCRF(string _dateFrom, string _dateTo, string _dateToday, string _username)
        {
            try
            {
                var db = new KHAS_BO_BUEntities();

                var result = db.SCRFbyRam(_dateTo, _dateFrom, _dateToday, _username);

                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

       
        public string SaveSCRF(SCRFModel _scrf)
        {
            string message = "";
            try
            {
                var db = new KHAS_BO_BUEntities();

                INCENTIVE_SCRF newSCRF = new INCENTIVE_SCRF
                {
                    EMPID = _scrf.EmpID,
                    EMP_NAME = _scrf.EmployeeName,
                    DATE_MONTH = _scrf.Month,
                    DATE_YEAR = _scrf.Year,
                    IF_SCRF = "Y"  
                };

                db.Entry(newSCRF).State = EntityState.Added;

                db.SaveChanges();
            }
            catch(Exception e)
            {
                message = "Error in Saving SCRF: " + e.Message;
            }

            return message;
        }

        public string DeleteSCRF(SCRFModel _scrf)
        {
            try
            {
                var db = new KHAS_BO_BUEntities();

                var item = db.INCENTIVE_SCRF.FirstOrDefault(r => r.EMPID == _scrf.EmpID && r.DATE_MONTH == _scrf.Month && r.DATE_YEAR == _scrf.Year);

                db.Entry(item).State = EntityState.Deleted;

                db.SaveChanges();

                return "";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}
