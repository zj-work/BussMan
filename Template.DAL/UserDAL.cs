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
    public class UserDAL : BaseDAL
    {

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="cust_name"></param>
        public t_user GetUserByName(string cust_name)
        {
            t_user res = null;
            string sql = "select * from t_user where Cust_Name=@Cust_Name";
            List<t_user> users = Query<t_user>(sql, new { Cust_Name = cust_name });
            if (users.Count > 0)
            {
                res = users.First();
            }
            return res;
        }

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="cust_name"></param>
        public t_user GetUserByRealName(string realName)
        {
            t_user res = null;
            string sql = "select * from t_user where RealName=@Cust_Name";
            List<t_user> users = Query<t_user>(sql, new { Cust_Name = realName });
            if (users.Count > 0)
            {
                res = users.First();
            }
            return res;
        }

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="cust_name"></param>
        public t_user GetUserById(string Id)
        {
            t_user res = null;
            string sql = "select * from t_user where id=@id";
            List<t_user> users = Query<t_user>(sql, new { id = Id });
            if (users.Count > 0)
            {
                res = users.First();
            }
            return res;
        }



        public List<t_user> GetUsersByCondition(string first, string end, string name, string phone, int firstIndex, int endIndex)
        {
            string sql = @"SELECT t_user.*
                            FROM t_user
                                 JOIN
                            (
                                SELECT id,
                                       ROW_NUMBER() OVER(ORDER BY time DESC) AS orderId
                                FROM t_user
                                WHERE time BETWEEN @first AND @end ";
            if (name != "")
            {
                sql += " AND RealName = @name ";
            }
            if (phone != "")
            {
                sql += " AND Phone = @phone ";
            }
            sql += @") dt ON t_user.ID = dt.ID
                            WHERE dt.orderId BETWEEN @firstIndex AND @endIndex;";
            List<t_user> list = Query<t_user>(sql, new { first = first, end = end, name = name, phone = phone, firstIndex = firstIndex, endIndex = endIndex });
            return list;
        }
        public List<t_user> GetAll(int firstIndex, int endIndex)
        {
            string sql = @"select t_user.* from t_user 
    join (select id,ROW_NUMBER() over(order by time desc) as orderId from t_user) dt
    on t_user.ID = dt.ID
    where dt.orderId between @firstIndex and @endIndex";
            List<t_user> list = Query<t_user>(sql, new { firstIndex = firstIndex, endIndex = endIndex });
            return list;
        }

        public int GetInfoNum()
        {
            string sql = @"select id from t_user";
            List<t_user> dt = Query<t_user>(sql, null);
            int res = dt.Count;
            return res;
        }

        public int GetPageCountByCondition(string first, string end, string name, string phone)
        {
            string sql = @"SELECT id
                        FROM t_user
                        WHERE time BETWEEN @first AND @end";
            if (name != "")
            {
                sql += " AND RealName = @name ";
            }
            if (phone != "")
            {
                sql += " AND Phone = @phone ";
            }
            List<t_user> dt = Query<t_user>(sql, new { first = first, end = end, name = name, phone = phone });
            int res = dt.Count;
            return res;
        }
        public bool Add(t_user model)
        {
            bool res = Insert<t_user>(model);
            return res;
        }

        public bool Alter(t_user model)
        {
            bool res = Alter<t_user>(model);
            return res;
        }

        public bool RemoveModel(int id)
        {
            t_user temp = new t_user();
            temp.ID = id.ToString();
            bool res = Delete<t_user>(temp);
            return res;
        }


    }
}
