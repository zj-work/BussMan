using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Model;

namespace Template.Models
{
    public class StaffModel:BaseModel
    {
        public List<t_user> staffs { get; set; }
        public int currentIndex { get; set; }
        public string PageUI { get; set; }
        public int pageCount { get; set; }

        public string search_time { get; set; }
        public string search_name { get; set; }
        public string search_phone { get; set; }

    }
}