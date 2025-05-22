using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesIncentive.Model;

namespace SalesIncentive.Service
{
    public class BankFileService
    {

        public string SaveBankFile(List<SalesIncentiveCrewModel> _crewList, List<SalesIncentiveAreaModel> _areaList, int _month, int _year,
            int _username)
        {
            string message = "";

            long g1, g2, g3, g4, g5, g6, g7, g8;

            long totalHash = 0;

            try
            {                
                var db = new KHAS_BO_BUEntities();

                db.SP_DELETE_BANK_FILE(_month, _year);

                _crewList.ForEach(r =>
                {

                    decimal total = Decimal.Parse(r.GrandTotal.ToString());

                    db.SP_INSERT_BANK_FILE(_month, _year, r.EmpID, r.EmployeeName, total, r.BankAccountNo, _username, DateTime.Now.ToShortDateString(), "CREW INCENTIVE");
                });

                _areaList.ForEach(r =>
                {
                    decimal total = decimal.Parse(r.TotalAmount.ToString());

                    db.SP_INSERT_BANK_FILE(_month, _year, r.EmpID, r.EmployeeName, total, r.BankAccount, _username, DateTime.Now.ToShortDateString(), "AREA INCENTIVE");
                });

                var query = db.T_SALES_INCENTIVE_NEW_BANK_FILE.Where(r => r.MONTH_DATE == _month && r.YEAR_DATE == _year).ToList();

                query.ForEach(x =>
                {
                    g1 = long.Parse(x.GROUP1) * 1;

                    g2 = long.Parse(x.GROUP2) * 3;

                    if (long.Parse(x.GROUP2.Substring(x.GROUP2.Length - 1)) != 0)
                        g2 = g2 * long.Parse(x.GROUP2.Substring(x.GROUP2.Length - 1));

                    g3 = long.Parse(x.GROUP3) * 7;

                    if (long.Parse(x.GROUP3.Substring(x.GROUP3.Length - 1)) != 0)
                        g3 = g3 * long.Parse(x.GROUP3.Substring(x.GROUP3.Length - 1));

                    g4 = long.Parse(x.GROUP4) * 1;

                    if (long.Parse(x.GROUP4.Substring(x.GROUP4.Length - 1)) != 0)
                        g4 = g4 * long.Parse(x.GROUP4.Substring(x.GROUP4.Length - 1));

                    g5 = long.Parse(x.GROUP5) * 3;

                    if (long.Parse(x.GROUP5.Substring(x.GROUP5.Length - 1)) != 0)
                        g5 = g5 * long.Parse(x.GROUP5.Substring(x.GROUP5.Length - 1));

                    g6 = long.Parse(x.GROUP6) * 7;

                    if (long.Parse(x.GROUP6.Substring(x.GROUP6.Length - 1)) != 0)
                        g6 = g6 * long.Parse(x.GROUP6.Substring(x.GROUP6.Length - 1));

                    g7 = long.Parse(x.GROUP7) * 1;

                    if (long.Parse(x.GROUP7.Substring(x.GROUP7.Length - 1)) != 0)
                        g7 = g7 * long.Parse(x.GROUP7.Substring(x.GROUP7.Length - 1));

                    g8 = long.Parse(x.GROUP8) * 3;

                    if (long.Parse(x.GROUP8.Substring(x.GROUP8.Length - 1)) != 0)
                        g8 = g8 * long.Parse(x.GROUP8.Substring(x.GROUP8.Length - 1));


                    totalHash = g1 + g2 + g3 + g4 + g5 + g6 + g7 + g8;

                    totalHash = long.Parse(totalHash.ToString().Substring(totalHash.ToString().Length - 12));

                    db.SP_UPDATE_FINAL_PRODUCT_BANKFILE(x.ID, totalHash);
                });


            }
            catch(Exception e)
            {
                message = e.Message;
            }

            return message;
        }

        private List<BankFileModel> GetBankData(int _month, int _year)
        {
            var db = new KHAS_BO_BUEntities();

            var query = from i in db.T_SALES_INCENTIVE_NEW_BANK_FILE
                        where i.MONTH_DATE == _month && i.YEAR_DATE == _year
                        select new BankFileModel
                        {
                            ID = i.ID,
                            EmployeeID = i.EMPID,
                            EmployeeName = i.EMP_NAME,
                            BankAccount = i.BANK_ACCOUNT,
                            Column1 = i.COLUMN1,
                            Column2 = i.COLUMN2,
                            Column3 = i.COLUMN3,
                            Column4 = i.COLUMN4,
                            Column5 = i.COLUMN5,
                            PCName = i.PC_NAME,
                            FinalProduct = i.FINAL_PRODUCT,
                            GeneratedBy = i.GENERATED_BY,
                            GeneratedDate = i.GENERATED_DATE,
                            Group1 = i.GROUP1,
                            Group2 = i.GROUP2,
                            Group3 = i.GROUP3,
                            Group4 = i.GROUP4,
                            Group5 = i.GROUP5,
                            Group6 = i.GROUP6,
                            Group7 = i.GROUP7,
                            Group8 = i.GROUP8,
                            Incentive = i.INCENTIVE,
                            Month = i.MONTH_DATE,
                            Particulars = i.PARTICULARS,
                            Year = i.YEAR_DATE
                        };

            return query.ToList();
        }

        private string ConvertNumericDate(int _date)
        {
            if (_date == 1)
                return "JANUARY";
            else if (_date == 2)
                return "FEBRUARY";
            else if (_date == 3)
                return "MARCH";
            else if (_date == 4)
                return "APRIL";
            else if (_date == 5)
                return "MAY";
            else if (_date == 6)
                return "JUNE";
            else if (_date == 7)
                return "JULY";
            else if (_date == 8)
                return "AUGUST";
            else if (_date == 9)
                return "SEPTEMBER";
            else if (_date == 10)
                return "OCTOBER";
            else if (_date == 11)
                return "NOVEMBER";
            else if (_date == 12)
                return "DECEMBER";
            else
                return "";
        }
        public string GenerateBankFile(string _path, int _month, int _year)
        {
            try
            {
                var list = GetBankData(_month, _year);

                string fileName = _path + @"\SalesIncentive_" + ConvertNumericDate(_month) + "_" + _year.ToString() + ".txt";

                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);

                if(File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (StreamWriter sw = File.CreateText(fileName))
                {
                    //list.ForEach(r =>
                    //{
                    //    sw.WriteLine("DTL|" + r.BankAccount + "|-|-|-|" + r.Incentive.ToString() + "|||" + r.FinalProduct);
                    //});

                    list.ForEach(r =>
                    {
                        sw.WriteLine(r.BankAccount + "\t" + r.Incentive.ToString());
                    });

                    decimal? total = list.Sum(r => r.Incentive);

                    sw.WriteLine("T\t" + total.ToString());
                }

                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
