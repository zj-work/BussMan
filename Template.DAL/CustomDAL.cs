using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model;

namespace Template.DAL
{
    public class CustomDAL:BaseDAL
    {
        public List<t_customer> GetAll(int firstIndex,int endIndex)
        {
            string sql = @"select t_customer.* from t_customer 
    join (select id,ROW_NUMBER() over(order by time desc) as orderId from t_customer) dt
    on t_customer.ID = dt.ID
    where dt.orderId between @firstIndex and @endIndex";
            List<t_customer> list = Query<t_customer>(sql, new { firstIndex = firstIndex, endIndex = endIndex });
            return list;
        }

        public int GetInfoNum()
        {
            string sql = @"select id from t_customer";
            List<t_cooperation> dt = Query<t_cooperation>(sql, null);
            int res = dt.Count;
            return res;
        }

        public List<t_customer> GetAllByOwner(string owner, int firstIndex, int endIndex)
        {
            string sql = @"select t_customer.* from t_customer 
    join (select id,ROW_NUMBER() over(order by time desc) as orderId from t_customer where Owner = @owner) dt
    on t_customer.ID = dt.ID
    where dt.orderId between @firstIndex and @endIndex";
            List<t_customer> list = Query<t_customer>(sql, new { owner = owner, firstIndex = firstIndex, endIndex = endIndex });
            return list;
        }

        public int GetInfoNumByOwner(string owner)
        {
            string sql = @"select id from t_customer where owner = @owner";
            List<t_cooperation> dt = Query<t_cooperation>(sql, new { owner = owner });
            int res = dt.Count;
            return res;
        }

        public bool Add(t_customer model)
        {
            bool res = Insert<t_customer>(model);
            return res;
        }

        public bool Alter(t_customer model)
        {
            bool res = Alter<t_customer>(model);
            return res;
        }

        public bool RemoveModel(int id)
        {
            t_customer temp = new t_customer();
            temp.ID = id.ToString();
            bool res = Delete<t_customer>(temp);
            return res;
        }
    }
}
