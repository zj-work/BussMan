using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template.Models
{
    public class MenuItem
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public bool IsOpen { get; set; }
        public string Url { get; set; }
    }
}