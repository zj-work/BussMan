using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model;

namespace Template.DAL
{
    public class CooperDAL : BaseDAL
    {
        public List<t_cooperation> GetCooperWithoutCondition(int firstIndex, int endIndex)
        {
            string sql = @"select t_cooperation.* from t_cooperation 
    join (select id,ROW_NUMBER() over(order by time desc) as orderId from t_cooperation) dt
    on t_cooperation.ID = dt.ID
    where dt.orderId between @firstIndex and @endIndex";
            List<t_cooperation> res = Query<t_cooperation>(sql, new { firstIndex = firstIndex, endIndex = endIndex });
            return res;
        }
        public List<t_cooperation> GetALLCooper()
        {
            string sql = @"select * from t_cooperation";
            List<t_cooperation> res = Query<t_cooperation>(sql, null);
            return res;
        }

        public int GetInfoNum()
        {
            string sql = @"select id from t_cooperation";
            List<t_cooperation> dt = Query<t_cooperation>(sql, null);
            int res = dt.Count;
            return res;
        }

        public bool Add(t_cooperation model)
        {
            bool res = Insert<t_cooperation>(model);
            return res;
        }

        public bool Alter(t_cooperation model)
        {
            bool res = Alter<t_cooperation>(model);
            return res;
        }

        public t_cooperation GetCooperByName(string name)
        {
            string sql = @"select * from t_cooperation where name=@name";
            List<t_cooperation> list = Query<t_cooperation>(sql, new { name = name });
            if(list.Count > 0)
            {
                return list.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public bool RemoveModel(int id)
        {
            t_cooperation temp = new t_cooperation();
            temp.ID = id.ToString();
            bool res = Delete<t_cooperation>(temp);
            return res;
        }
    }
}
