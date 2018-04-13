using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussMan.Model;
using System.Data.SqlClient;
using System.Data;

namespace BussMan.DAL
{
    public class DMenu
    {
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="model"></param>
        public bool AddMenu(t_menu model)
        {
            string sql = @"insert into t_menu(content,url,pid,target) values(@content,@url,@pid,@target)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@content",model.content),
                new SqlParameter("@url",model.url),
                new SqlParameter("@pid",model.pid),
                new SqlParameter("@target",model.target)
            };
            return DBSql.ExecNoneQuery(sql, para);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public bool AlterMenu(t_menu model, string[] para)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"update t_menu set ");
                for (int i = 0; i < para.Length; i++)
                {
                    if (i != 0)
                    {
                        sb.Append(" and ");
                    }
                    sb.Append(" " + para[i] + "=");
                    System.Reflection.PropertyInfo info = model.GetType().GetProperty(para[i]);
                    object obj = info.GetValue(model);
                    sb.Append(obj.ToString() + " ");
                }
                sb.Append(" where id=" + model.id);
                return DBSql.ExecNoneQuery(sb.ToString());
            }catch { return false; }
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteMenu(int id)
        {
            string sql = string.Format(@"delete from t_menu where id={0}",id);
            return DBSql.ExecNoneQuery(sql);
        }

        /// <summary>
        /// 获取等级菜单
        /// </summary>
        /// <param name="pid">父级菜单编号 默认-1:获取一级菜单</param>
        /// <param name="target">标志 sys:后台菜单 dis:前台菜单</param>
        /// <returns></returns>
        public List<t_menu> GetMenuByRank(int pid = -1,string target="disp")
        {
            string sql = string.Format(@"select * from t_menu where pid='{0}' and target='{1}'", pid, target);
            DataTable table = DBSql.GetTable(sql);
            List<t_menu> res = new List<t_menu>();
            if (table.Rows.Count > 0)
            {
                res = Common.ConvertFun<t_menu>.TableToList(table);
            }
            return res;
        }

    }
}
