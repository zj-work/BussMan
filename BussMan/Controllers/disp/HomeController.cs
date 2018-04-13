using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussMan.Model;

namespace BussMan.Controllers
{
    public class HomeController : BaseController<IndexViewModel>
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}