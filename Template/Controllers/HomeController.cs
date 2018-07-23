using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.BLL;
using Template.Models;

namespace Template.Controllers
{
    public class HomeController : BaseController
    {
        
        public HomeController()
        {
            model = new IndexModel();
        }
        /// <summary>
        /// 管理系统后台-首页
        /// </summary>
        /// <returns></returns>
        public ActionResult MIndex()
        {
            ReadMenu();
            model.currentMenu = 1;
            return View(model);
        }
    }
}