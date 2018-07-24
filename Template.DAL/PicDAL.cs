using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model;

namespace Template.DAL
{
    public class PicDAL:BaseDAL
    {
        public List<t_pic> GetPicsByKind(string kind)
        {
            string sql = "select * from t_pic where kind=@kind";
            List<t_pic> pics = Query<t_pic>(sql, new { kind = kind });
            return pics;
        }

        public bool SavePics(t_pic model)
        {
            return Insert<t_pic>(model);
        }

        public bool DeletePics(t_pic model)
        {
            return Delete<t_pic>(model);
        }
    }
}
