using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;

namespace Template.Controllers
{
    public class JoinUsController : BaseController<JoinUsModel>
    {
        public ActionResult JoinUsManage()
        {
            Init();
            pageModel.currentMenu = 7;
            return View(pageModel);
        }
    }
}