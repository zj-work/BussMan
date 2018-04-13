using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussMan.Model;
using System.Data;

namespace BussMan.DAL
{
    public class DSite
    {
        public t_site GetSite()
        {
            string sql = @"select top 1 * from t_site;";
            DataTable table = DBSql.GetTable(sql);
            t_site res = Common.ConvertFun<t_site>.TableToItem(table);
            return res;
        }
    }
}
