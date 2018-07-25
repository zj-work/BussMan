using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Model;

namespace Template.Models
{
    public class CooperModel:BaseModel
    {
        public List<t_cooperation> list { get; set; }
        public int currentIndex { get; set; }
        public string PageUI { get; set; }
        public int pageCount { get; set; }
    }
}