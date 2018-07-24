using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model;

namespace Template.DAL
{
    public class ComDAL:BaseDAL
    {
        public t_com GetComModel()
        {
            t_com res = null;
            string sql = @"select top (1) * from t_com";
            List<t_com> coms = Query<t_com>(sql, null);
            if(coms.Count > 0)
            {
                res = coms.FirstOrDefault();
            }
            return res;
        }

        public bool SaveCom(t_com model)
        {
            t_com temp = GetComModel();
            bool res = false;
            if(temp == null)
            {
                //插入公司信息
                res = Insert<t_com>(model);
            }
            else
            {
                //修改公司信息
                res = Alter<t_com>(model);
            }
            return res;
        }
    }
}
