using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussMan.Model
{
    public class t_menu
    {
        public int id { get; set; }
        public string content { get; set; }
        public string url { get; set; }
        public int pid { get; set; }
        public string target { get; set; }
    }
}
