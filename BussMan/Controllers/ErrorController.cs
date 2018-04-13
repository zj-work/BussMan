using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BussMan.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// 404错误
        /// </summary>
        /// <returns></returns>
        public ActionResult Error404()
        {
            return View();
        }

        /// <summary>
        /// 500错误
        /// </summary>
        /// <returns></returns>
        public ActionResult Error500()
        {
            return View();
        }
    }
}