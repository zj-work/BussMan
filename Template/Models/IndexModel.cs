using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Model;

namespace Template.Models
{
    public class IndexModel:BaseModel
    {
        public t_com comModel { get; set; }

        public string banner_01 { get; set; }

        public string banner_02 { get; set; }

        public string banner_03 { get; set; }

    }
}