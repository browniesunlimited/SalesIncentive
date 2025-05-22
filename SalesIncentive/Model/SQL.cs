using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIncentive.Model
{
    public class SQL
    {
        private const string connStringProd = @"Data Source=10.103.70.38;
                                        Initial Catalog=KHAS_BO_BU;
                                        Persist Security Info=True;
                                        User ID=sa;
                                        Password=@dpa$$123";

        private const string connStringDEV = @"Data Source=.\KHAS;
                                            Initial Catalog=KHAS_BO_BU;
                                            Persist Security Info=True;
                                            User ID=sa;
                                            Password=Admin123$$";

        public static SqlDataReader ExecuteSQLDataReader(string query, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connStringDEV);
            SqlCommand cmd = new SqlCommand(query, conn);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            conn.Open();

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStringDEV))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
