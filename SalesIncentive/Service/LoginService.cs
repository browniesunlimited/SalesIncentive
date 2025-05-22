using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesIncentive.Model;

namespace SalesIncentive.Service
{
    public class LoginService
    {
        public bool TryLogin(string _username, string _password)
        {
            try
            {
                int empID = int.Parse(_username);

                string password = DecryptPassword(_password);

                var db = new KHAS_BO_BUEntities();

                var query = from i in db.M_EMPLOYEE
                            where i.EMPID == empID && i.PASSWORD == password
                            select new EmployeeModel
                            {
                                EmployeeID = i.EMPID,
                                Password = i.PASSWORD,
                                PassKey = i.PASSKEY
                            };


                if (query.ToList().Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        private string DecryptPassword(string _password)
        {
            try
            {
                var password = new KHAS_BO_BUEntities().PasswordByRam(_password);

                return password.FirstOrDefault().ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}
