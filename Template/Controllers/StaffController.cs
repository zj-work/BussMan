using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;

namespace Template.Controllers
{
    public class StaffController : BaseController<StaffModel>
    {
        public ActionResult StaffManage()
        {
            Init();
            pageModel.currentMenu = 3;
            return View(pageModel);
        }
    }
}