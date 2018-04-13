using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussMan.Model;

namespace BussMan.Controllers
{
    public class SHomeController : SBaseController<SIndexViewModel>
    {
        // GET: SHome
        public ActionResult Index()
        {
            if (pageModel.Menu.Count == 0)
            {
                return Redirect("/sys/menuconfig");
            }
            return View();
        }

        /// <summary>
        /// 菜单设置--只有管理员才能打开
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuConfig()
        {
            return View();
        }
    }
}