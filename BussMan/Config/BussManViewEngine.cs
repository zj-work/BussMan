using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BussMan
{
    public class BussManViewEngine:RazorViewEngine
    {
        public BussManViewEngine(string template)
        {
            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/" + template + "/{1}/{0}.cshtml"
            };
        }
    }
}