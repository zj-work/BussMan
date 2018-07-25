using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Model;

namespace Template.Models
{
    public class JoinUsModel:BaseModel
    {
        public t_page condition { get; set; }
        public t_page task { get; set; }
        public t_page exit { get; set; }
    }
}