using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Reflection;


/****************************************************************
*   作者：Eric
*   CLR版本：4.0.30319.42000
*   创建时间：2018/7/4 15:23:54
*   描述说明：
*
*   修改历史：
*
*****************************************************************/

namespace Template.DAL
{
    public class BaseDAL
    {
        protected static string ConnString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        
        protected List<T> Query<T>(string sql,object model)
        {
            List<T> res = new List<T>();
            using(IDbConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    res = conn.Query<T>(sql,model).ToList();
                }
                catch (Exception ex) { }
            }
            return res;
        }

        protected bool Insert<T>(T model)
        {
            bool res = false;
            string sql = GetSQL<T>(model, SQLType.Insert);
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();
                    int n = conn.Execute(sql, model);
                    if (n > 0)
                    {
                        res = true;
                    }
                    conn.Close();
                }
                catch (Exception ex) { }
            }
            return res;
        }

        protected bool Alter<T>(T model)
        {
            bool res = false;
            string sql = GetSQL<T>(model, SQLType.Alter);
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();
                    int n = conn.Execute(sql, model);
                    if (n > 0)
                    {
                        res = true;
                    }
                    conn.Close();
                }
                catch (Exception ex) { }
            }
            return res;
        }

        protected bool Delete<T>(T model)
        {
            bool res = false;
            string sql = GetSQL<T>(model, SQLType.Delete);
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                try
                {
                    conn.Open();
                    int n = conn.Execute(sql, model);
                    if (n > 0)
                    {
                        res = true;
                    }
                    conn.Close();
                }
                catch (Exception ex) { }
            }
            return res;
        }

        private string GetSQL<T>(T model, SQLType type)
        {
            string res = string.Empty;
            switch (type)
            {
                case SQLType.Insert:
                    #region Insert
                    {
                        PropertyInfo[] properties = model.GetType().GetProperties();
                        string className = model.GetType().Name;
                        StringBuilder sb = new StringBuilder();
                        sb.Append("insert into " + className + "(");
                        foreach (PropertyInfo item in properties)
                        {
                            string pname = item.Name;
                            if (!pname.ToLower().Equals("id"))
                            {
                                sb.Append(pname + ",");
                            }
                        }
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append(") values (");
                        foreach (PropertyInfo item in properties)
                        {
                            string pname = item.Name;
                            if (!pname.ToLower().Equals("id"))
                            {
                                sb.Append("@" + pname + ",");
                            }
                        }
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append(")");
                        res = sb.ToString();
                    }
                    #endregion
                    break;
                case SQLType.Alter:
                    #region Alter
                    {
                        PropertyInfo[] properties = model.GetType().GetProperties();
                        string className = model.GetType().Name;
                        StringBuilder sb = new StringBuilder();
                        sb.Append("update " + className + " set ");
                        foreach (PropertyInfo item in properties)
                        {
                            string pname = item.Name;
                            if (!pname.ToLower().Equals("id"))
                            {
                                sb.Append(pname + "=@"+pname+",");
                            }
                        }
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append(" where ID=@ID");
                        res = sb.ToString();
                    }
                    #endregion
                    break;
                case SQLType.Delete:
                    #region Delete
                    {
                        PropertyInfo[] properties = model.GetType().GetProperties();
                        string className = model.GetType().Name;
                        StringBuilder sb = new StringBuilder();
                        sb.Append("delete from " + className + " where ID=@ID");
                        res = sb.ToString();
                    }
                    #endregion
                    break;
            }
            return res;
        }

        private enum SQLType
        {
            Insert = 0,
            Alter = 1,
            Delete = 2
        }
    }
}
