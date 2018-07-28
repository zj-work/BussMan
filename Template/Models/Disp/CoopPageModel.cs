using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Model;

namespace Template.Models
{
    public class CoopPageModel:Disp_BaseModel
    {
        public List<t_cooperation> list { get; set; }
        public int pageCount { get; set; }
        public string pageUI { get; set; }
        public int pageIndex { get; set; }
    }
}