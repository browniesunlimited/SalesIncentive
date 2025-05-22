using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesIncentive.Model;

namespace SalesIncentive.Service
{
    public class DistributionService
    {

        public List<SalesIncentiveCrewModel> DistributeToCrew(List<IncentiveDataModel> _QualifiedOutlet, List<IncentiveDaysWorkModel> _DaysWork)
        {
            var query = from o in _QualifiedOutlet
                        join d in _DaysWork on o.OutletName equals d.OutletName
                        select new SalesIncentiveCrewModel
                        {
                            EmpID = d.EMPID,
                            DaysWork = d.DaysWork,
                            EmployeeName = d.EmployeeName,
                            IncentiveAmount = o.IncentivePerCew,
                            SpecialAmount = o.SpecialPerCrew,
                            OutletName = o.OutletName,
                            BankAccountNo = d.BankAccountNo
                        };

            return query.ToList();
        }

        public List<IncentiveDaysWorkModel> GetDaysWorkModels(int _month, int _year)
        {
            var db = new KHAS_BO_BUEntities();

            var query = from o in db.SP_DAYS_WORK_PER_OUTLET(_month, _year)
                        select new IncentiveDaysWorkModel
                        {
                            EMPID = o.EMPID,
                            EmployeeName = o.EMP_NAME,
                            DaysWork = o.DAYS_WORK,
                            OutletName = o.OUTLET_NAME,
                            BankAccountNo = o.BANK_ACCT_NO
                        };

            return query.ToList();

        }

        public List<SCRFModel> GetForSCRF(int _month, int _year)
        {
            var db = new KHAS_BO_BUEntities();

            var query = from o in db.INCENTIVE_DAYS_WORK
                        where o.MONTH == _month && o.YEAR == _year && o.DEPARTMENT == "SALES"
                        select new SCRFModel
                        {
                            EmpID = o.EMPID,
                            EmployeeName = o.EMP_NAME,
                            Month = _month,
                            Year = _year
                        };

            var list = query.ToList();

            return list.GroupBy(r=>r.EmployeeName).Select(x=>x.First()).OrderBy(r=>r.EmployeeName).ToList();
        }

        public List<SCRFModel> GetSavedSCRF(int _month, int _year)
        {
            var db = new KHAS_BO_BUEntities();

            var query = from o in db.INCENTIVE_SCRF
                        where o.DATE_MONTH == _month && o.DATE_YEAR == _year
                        orderby o.EMP_NAME ascending
                        select new SCRFModel
                        {
                            EmpID = o.EMPID,
                            EmployeeName = o.EMP_NAME,
                            Month = o.DATE_MONTH,
                            Year = o.DATE_YEAR
                        };

            return query.ToList();
        }
    }
}
