using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesIncentive.Model;
using System.Data.Entity;

namespace SalesIncentive.Service
{
    public class VarianceService
    {
        public List<SalesIncentiveVarianceModel> GetVariancePerMonth(int _month, int _year)
        {
            var db = new KHAS_BO_BUEntities();

            List<SalesIncentiveVarianceModel> returnVal = new List<SalesIncentiveVarianceModel>();

            var query = from i in db.SalesIncentiveVariances
                        join b in db.M_OUTLET on i.OutletNo equals b.OUTLET_NO
                        where i.DateMonth == _month && i.DateYear == _year
                        select new SalesIncentiveVarianceModel
                        {
                            ID = i.ID,
                            Amount = i.Amount,
                            DateMonth = i.DateMonth,
                            DateYear = i.DateYear,
                            ModifiedDate = i.ModifiedDate,
                            ModifiedBy = i.ModifiedBy,
                            OutletName = b.OUTLET_NAME,
                            OutletNo = i.OutletNo, 
                            Spoilage = i.Spoilage
                        };

            returnVal = query.ToList();

            if(returnVal.Count == 0)
            {
               var query2 = from i in db.OutletListForVariance(_month, _year)
                        orderby i.OUTLET_NAME
                        select new SalesIncentiveVarianceModel
                        {
                            OutletNo = i.OUTLET_NO,
                            OutletName = i.OUTLET_NAME,
                            DateMonth = _month,
                            DateYear = _year
                        };

                returnVal = query2.ToList();
            }

            return returnVal;
        }


        public string SaveIncentiveVariance(List<SalesIncentiveVarianceModel> _variance)
        {
            try
            {
                var db = new KHAS_BO_BUEntities();

                _variance.ForEach(r =>
                {
                    if (r.ID == 0) //SAVE AS NEW RECORD
                {
                        SalesIncentiveVariance newItem = new SalesIncentiveVariance
                        {
                            Amount = r.Amount,
                            OutletNo = r.OutletNo,
                            DateMonth = r.DateMonth,
                            DateYear = r.DateYear,
                            ModifiedDate = r.ModifiedDate,
                            ModifiedBy = r.ModifiedBy,
                            Spoilage = r.Spoilage
                        };

                        db.Entry(newItem).State = EntityState.Added;
                    }
                    else //UPDATE EXISTING RECORD
                    {
                        var item = db.SalesIncentiveVariances.FirstOrDefault(x => x.ID == r.ID);

                        item.Amount = r.Amount;

                        item.Spoilage = r.Spoilage;

                        item.ModifiedBy = r.ModifiedBy;

                        item.ModifiedDate = r.ModifiedDate;

                        db.Entry(item).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                });

                return "";
            }
            catch (Exception e)
            {
                return "Error on Saving Sales Incentive Variance: - " + e.Message;
            }
        }
    }
}