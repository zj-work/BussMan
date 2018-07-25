using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model;
using Dapper;

/****************************************************************
*   作者：Eric
*   CLR版本：4.0.30319.42000
*   创建时间：2018/7/4 15:18:00
*   描述说明：
*
*   修改历史：
*
*****************************************************************/

namespace Template.DAL
{
    public class UserDAL:BaseDAL
    {
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="cust_name"></param>
        public t_user GetUserByName(string cust_name)
        {
            t_user res = null;
            string sql = "select * from t_user where Cust_Name=@Cust_Name";
            List<t_user> users =  Query<t_user>(sql, new { Cust_Name = cust_name });
            if (users.Count > 0)
            {
                res = users.First();
            }
            return res;
        }

        public List<t_user> GetUsersByCondition(DateTime time, string name, string phone)
        {
            string sql = @"";
            return null;
        }
    }
}
