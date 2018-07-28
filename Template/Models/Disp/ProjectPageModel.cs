using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Template.Model;

namespace Template.Models
{
    public class ProjectPageModel:Disp_BaseModel
    {
        public string coinContent { get; set; }
        public string advertContent { get; set; }
        public string mediaContent { get; set; }
        public string centerContent { get; set; }
        public string meetingContent { get; set; }

        public t_page PageModel { get; set; }
    }
}