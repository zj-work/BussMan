using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model;
using Template.DAL;

namespace Template.BLL
{
    public class ComBLL
    {
        private ComDAL _dal = new ComDAL();

        public t_com GetComModel()
        {
            return _dal.GetComModel();
        }

        public bool SaveCom(t_com model)
        {
            return _dal.SaveCom(model);
        }
    }
}
