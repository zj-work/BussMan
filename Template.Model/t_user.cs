using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Model
{
    public class t_user
    {
        public string ID { get; set; }
        public string Cust_Name { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string RealName { get; set; }
        public string Pwd { get; set; }
        public string Type { get; set; }
        /// <summary>
        /// 二维码保存路径-绝对路径
        /// </summary>
        public string ImageUrl { get; set; }
        public string time { get; set; }
    }
}
