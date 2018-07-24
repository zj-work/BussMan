using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;

namespace Template.Controllers
{
    public class CustomerController : BaseController<CustomerModel>
    {
        // GET: Customer
        public ActionResult CustomerManage(string kind)
        {
            if(kind == "all")
            {
                //客户管理
                Init();
                pageModel.currentMenu = 4;
                return View("CustomerManage",pageModel);
            }
            else
            {
                //好友列表
                Init();
                pageModel.currentMenu = 5;
                return View("FriendManage", pageModel);
            }
        }
    }
}