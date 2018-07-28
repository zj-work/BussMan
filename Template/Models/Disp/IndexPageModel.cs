using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Model;

namespace Template.Models
{
    public class IndexPageModel:Disp_BaseModel
    {
        public List<string> banners { get; set; }
        public List<t_cooperation> coopers { get; set; }
        public string ComInfo { get; set; }
    }
}