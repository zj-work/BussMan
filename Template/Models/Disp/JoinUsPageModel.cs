using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Model;

namespace Template.Models
{
    public class JoinUsPageModel:Disp_BaseModel
    {
        public t_page condition { get; set; }
        public t_page task { get; set; }
        public t_page exit { get; set; }
    }
}