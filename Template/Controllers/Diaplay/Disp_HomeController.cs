using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.BLL;
using Template.Model;
using Template.Models;

namespace Template.Controllers.Diaplay
{
    public class Disp_HomeController : Disp_BaseController<ComPageModel>
    {
        private CustomBLL _bll = new CustomBLL();

        public ActionResult Info()
        {
            Init();
            pageModel.currentMenu = 4;

            SetTDK
            (
                pageModel._com.ComName + "-" + "公司简介",
                pageModel._com.ComName + "," + "公司简介",
                pageModel._com.ComName + "。"
            );
            return View(pageModel);
        }

        public ActionResult Message(string inviter = "")
        {
            Init();
            pageModel.currentMenu = 4;

            SetTDK
            (
                pageModel._com.ComName + "-" + "联系我们",
                pageModel._com.ComName,
                pageModel._com.ComName + "。"
            );
            ViewBag.inviter = inviter;
            return View(pageModel);
        }

        [HttpPost]
        public JsonResult Save(t_customer model)
        {
            object obj = new { };
            try
            {
                model.time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                model.state = "0";
                model.Content = Common.CommonFun.IsEmpty(model.Content) ? "" : model.Content;
                model.Owner = Common.CommonFun.IsEmpty(model.Owner) ? "" : model.Owner;
                bool res = _bll.SaveModel(model);
                if (res)
                {
                    obj = new { state = 1, data = "", message = "保存信息成功" };
                }
                else
                {
                    obj = new { state = 0, data = "", message = "保存信息失败" };
                }
            }
            catch { obj = new { state = 0, data = "", message = "保存信息失败" }; }
            return Json(obj);
        }
    }
}