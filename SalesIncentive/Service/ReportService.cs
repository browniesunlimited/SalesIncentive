using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesIncentive.Model;
using System.Data.Entity;

namespace SalesIncentive.Service
{
    public class ReportService
    {
        public void SaveIncentive(List<SalesIncentiveCrewModel> _crewList, List<SalesIncentiveAreaModel> _areaList)
        {
            var db = new KHAS_BO_BUEntities();

            var forDeleteCrew = db.RPT_CREW_INCENTIVE.ToList();

            forDeleteCrew.ForEach(r =>
            {
                db.Entry(r).State = EntityState.Deleted;
            });

            var forDeleteArea = db.RPT_AREA_INCENTIVE.ToList();

            forDeleteArea.ForEach(r =>
            {
                db.Entry(r).State = EntityState.Deleted;
            });

            db.SaveChanges();

            _crewList.ForEach(r =>
            {
                RPT_CREW_INCENTIVE crew = new RPT_CREW_INCENTIVE
                {
                    BRANCH = r.OutletName,
                    EMPLOYEE_ID = r.EmpID.ToString(),
                    DAYS_WORK = r.DaysWork.ToString(),
                    GRAND_TOTAL = r.GrandTotal.ToString(),
                    INCENTIVE_PER_DAY = r.IncentiveAmount.ToString(),
                    NAME = r.EmployeeName,
                    SPECIAL_PER_DATE = r.SpecialAmount.ToString(),
                    TOTAL_INCENTIVE = r.IncentiveAmount.ToString(),
                    TOTAL_SPECIAL = r.SpecialToReceive.ToString()
                };

                db.Entry(crew).State = EntityState.Added;
            });

            _areaList.ForEach(r =>
            {
                RPT_AREA_INCENTIVE area = new RPT_AREA_INCENTIVE
                {
                    AREA_NAME = r.EmployeeName,
                    INCENTIVE = r.AreaIncentive.ToString(),
                    SPECIAL = r.AreaSpecial.ToString(),
                    TOTAL = r.TotalAmount.ToString()
                };

                db.Entry(area).State = EntityState.Added;
            });

            db.SaveChanges();
        }
        public void SaveQualifiedOutletRPT(List<IncentiveDataModel> _QualifiedOutlet, List<SalesIncentiveAreaModel> _QualifiedArea)
        {
            var db = new KHAS_BO_BUEntities();

            var forDeleteOutlet = db.RPT_SALES_INCENTIVE_QOUTLET.ToList();

            forDeleteOutlet.ForEach(r =>
            {
                db.Entry(r).State = EntityState.Deleted;
            });

            var forDeleteArea = db.RPT_SALES_INCENTIVE_QAREA.ToList();

            forDeleteArea.ForEach(r =>
            {
                db.Entry(r).State = EntityState.Deleted;
            });

            db.SaveChanges();

            _QualifiedOutlet.ForEach(r =>
            {
                RPT_SALES_INCENTIVE_QOUTLET outlet = new RPT_SALES_INCENTIVE_QOUTLET
                {
                    AREA_MANAGER = r.EmployeeName,
                    OUTLET_NO = r.OutletNo.ToString(),
                    OUTLET_NAME = r.OutletName,
                    TARGET_NET = r.NetTarget.ToString(),
                    TARGET_ACTUAL = r.TargetSales.ToString(),
                    INCREMENTAL = r.Incremental.ToString(),
                    CLUSTER_INCENTIVE = r.ClusterManagerAmount.ToString(),
                    CREW_INCENTIVE = r.CrewAmount.ToString(),
                    CREW_SPECIAL = r.SpecialAmountForCrew.ToString(),
                    CLUSTER_SPECIAL = r.SpecialAmountForCluster.ToString(),
                    DAYEND_50 = r.DayEnd50.ToString(),
                    DAYEND_20 = r.DayEnd20.ToString(),
                    VARIANCE = r.Variance.ToString(),
                    SPOILAGE = r.Spoilage.ToString(),
                    COMPLAIN = r.Complain,
                    QUALIFIED = r.RPTQualified
                };

                db.Entry(outlet).State = EntityState.Added;
            });

            _QualifiedArea.ForEach(r =>
            {
                RPT_SALES_INCENTIVE_QAREA area = new RPT_SALES_INCENTIVE_QAREA
                {
                    AREA_MANAGER = r.EmployeeName,
                    TARGET_NET = r.NetTarget.ToString(),
                    ACTUAL_NET = r.NetSales.ToString(),
                    INCREMENTAL = r.Incremental.ToString(),
                    DAYEND = r.DayEnd.ToString(),
                    VARIANCE = r.Variance.ToString(),
                    VARIANCE_PERCENT = r.VariancePercent.ToString(),
                    SPOILAGE = r.Spoilage.ToString(),
                    SPOILAGE_PERCENT = r.SpoilagePercent.ToString(),
                    QUALIFIED = r.RPTQualified
                };

                db.Entry(area).State = EntityState.Added;
            });

           db.SaveChanges();
        }
    }
}
