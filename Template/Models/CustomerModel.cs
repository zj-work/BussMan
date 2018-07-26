using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Model;

namespace Template.Models
{
    public class CustomerModel:BaseModel
    {
        public List<t_customer> list { get; set; }
        public int currentIndex { get; set; }
        public string PageUI { get; set; }
        public int pageCount { get; set; }

        public string search_time { get; set; }
        public string search_owner { get; set; }
        public string search_custom { get; set; }

    }
}