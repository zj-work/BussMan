using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.BLL;
using Template.Model;
using Template.Common;

namespace Template.Controllers
{
    public class UserController : Controller
    {
        private UserBLL _user = new UserBLL();
        public ActionResult Login(string url = "")
        {
            ViewBag.Url = url;
            return View();
        }

        [HttpPost]
        public JsonResult Login(string name, string pwd,string url)
        {
            ResultHandler res = _user.Login(name, pwd);
            if (res.state)
            {
                if (!CommonFun.IsEmpty(Session["UserInfo"]))
                {
                    Session.Remove("UserInfo");
                }
                Session.Add("UserInfo", res.data);
                t_user item = res.data as t_user;
                if (CommonFun.IsEmpty(url))
                {
                    if ("General".Equals(item.Type))
                    {
                        res.url = "sys/MyQR";
                    }
                    else
                    {
                        res.url = "sys/index";
                    }
                }
                else
                {
                    if ("General".Equals(item.Type))
                    {
                        if(url.Contains("MyQR") || url.Contains("Client"))
                        {
                            res.url = url;
                        }
                        else
                        {
                            res.url = "sys/MyQR";
                        }
                    }
                    else
                    {
                        res.url = url;
                    }
                    
                }
            }
            return Json(res);
        }
    }
}