using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;

namespace Template.Controllers
{
    public class CooperateController : BaseController<CooperModel>
    {
        // GET: Cooperate
        public ActionResult CooperManage()
        {
            Init();
            pageModel.currentMenu = 6;
            return View(pageModel);
        }
    }
}