using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussMan.Model
{
    /// <summary>
    /// 网站基本信息
    /// </summary>
    public class t_site
    {
        public int id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public string sitelogo { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public string phone { get; set; }
        public string qq { get; set; }
        public string postcode { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string wx { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
        public string icp { get; set; }
        public string gwba { get; set; }

    }
}
