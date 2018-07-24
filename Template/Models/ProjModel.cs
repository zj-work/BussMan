using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template.Models
{
    public class ProjModel:BaseModel
    {
        public string pageTitle { get; set; }
        public string projTitle { get; set; }
        public string projContent { get; set; }
    }
}