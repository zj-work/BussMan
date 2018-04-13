using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BussMan.Model
{
    public class BaseModel
    {
        public BussMan.Model.t_site SiteInfo { get; set; }

        public Dictionary<Model.t_menu, List<Model.t_menu>> Menu { get; set; }
    }
}