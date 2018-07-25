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
    }
}