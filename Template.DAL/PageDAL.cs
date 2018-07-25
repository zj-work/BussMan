using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model;

namespace Template.DAL
{
    public class PageDAL : BaseDAL
    {
        public List<t_page> GetPageByKind(string kind)
        {
            string sql = "select * from t_page where kind = @kind";
            List<t_page> list = new List<t_page>();
            list = Query<t_page>(sql, new { kind = kind });
            if(list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<t_page>();
            }
        }

        public bool AddPage(t_page model)
        {
            return Insert<t_page>(model);
        }

        public bool AlterPage(t_page model)
        {
            return Alter<t_page>(model);
        }
    }
}
