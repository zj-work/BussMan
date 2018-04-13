using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussMan.DAL
{
    public class DBSql
    {
        private static string connString = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString();

        public static DataTable GetTable(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        DataSet ds = new DataSet();
                        SqlDataAdapter sda = new SqlDataAdapter(comm);
                        sda.Fill(ds);
                        if (ds.Tables.Count > 0)
                        {
                            table = ds.Tables[0];
                        }
                    }
                    conn.Close();
                }
            }catch { }
            return table;
        }

        public static DataTable GetTable(string sql, SqlParameter[] para)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        comm.Parameters.AddRange(para);
                        DataSet ds = new DataSet();
                        SqlDataAdapter sda = new SqlDataAdapter(comm);
                        sda.Fill(ds);
                        if (ds.Tables.Count > 0)
                        {
                            table = ds.Tables[0];
                        }
                    }
                    conn.Close();
                }
            }
            catch { }
            return table;
        }

        public static string ExecSalarString(string sql)
        {
            string res = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        object obj = comm.ExecuteScalar();
                        if (obj != null) { res = obj.ToString(); }
                    }
                    conn.Close();
                }
            }
            catch { }
            return res;
        }

        public static string ExecSalarString(string sql, SqlParameter[] para)
        {
            string res = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        comm.Parameters.AddRange(para);
                        object obj = comm.ExecuteScalar();
                        if (obj != null) { res = obj.ToString(); }
                    }
                    conn.Close();
                }
            }
            catch { }
            return res;
        }

        public static int ExecSalarInt(string sql)
        {
            int res = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        object obj = comm.ExecuteScalar();
                        if (obj != null) { Int32.TryParse(obj.ToString(),out res); }
                    }
                    conn.Close();
                }
            }
            catch { }
            return res;
        }

        public static int ExecSalarInt(string sql,SqlParameter[] para)
        {
            int res = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        comm.Parameters.AddRange(para);
                        object obj = comm.ExecuteScalar();
                        if (obj != null) { Int32.TryParse(obj.ToString(), out res); }
                    }
                    conn.Close();
                }
            }
            catch { }
            return res;
        }

        public static bool ExecNoneQuery(string sql)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        int n = comm.ExecuteNonQuery();
                        if (n > 0)
                        {
                            res = true;
                        }
                    }
                    conn.Close();
                }
            }
            catch { }
            return res;
        }

        public static bool ExecNoneQuery(string sql, SqlParameter[] para)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(sql, conn))
                    {
                        comm.Parameters.AddRange(para);
                        int n = comm.ExecuteNonQuery();
                        if (n > 0)
                        {
                            res = true;
                        }
                    }
                    conn.Close();
                }
            }
            catch { }
            return res;
        }

    }
}
