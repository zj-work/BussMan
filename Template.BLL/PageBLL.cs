using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DAL;
using Template.Model;

namespace Template.BLL
{
    public class PageBLL
    {
        private PageDAL _dal = new PageDAL();
        public t_page GetPageByKind(string kind)
        {
            List<t_page> list =  _dal.GetPageByKind(kind);
            if(list.Count > 0)
            {
                return list.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public List<t_page> GetJoinUs()
        {
            List<t_page> list = _dal.GetPageByKind("join");
            return list;
        }

        public bool SavePage(t_page model)
        {
            model.time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            bool res = false;
            if(Int32.Parse(model.ID) > 0)
            {
                //修改
                res = _dal.AlterPage(model);
            }
            else
            {
                //添加
                res = _dal.AddPage(model);
            }
            return res;
        }
    }
}
