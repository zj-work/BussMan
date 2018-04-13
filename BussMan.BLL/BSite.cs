using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussMan.Model;
using BussMan.DAL;

namespace BussMan.BLL
{
    public class BSite
    {
        private DSite _siteDAL = new DSite();
        public t_site GetSite()
        {
            return _siteDAL.GetSite();
        }
    }
}
