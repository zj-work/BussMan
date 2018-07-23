using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template.Models
{
    public class BaseModel
    {
        public Dictionary<MenuItem,List<MenuItem>> menu_List { get; set; }
        
        public int currentMenu { get; set; }
    }

}