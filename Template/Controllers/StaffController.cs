using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.BLL;
using Template.Model;
using Template.Models;

namespace Template.Controllers
{
    public class StaffController : BaseController<StaffModel>
    {

        private UserBLL _bll = new UserBLL();
        public ActionResult StaffManage(int pid = 1)
        {
            Init();
            pageModel.currentMenu = 3;
            //获取显示数据
            List<t_user> list = _bll.GetALL(pid);
            pageModel.currentIndex = pid;
            pageModel.staffs = list;
            pageModel.pageCount = _bll.GetPageCount();
            string url = "/sys/Staff";
            pageModel.PageUI = CreatePageUI(url, pageModel.currentIndex, pageModel.pageCount);
            return View(pageModel);
        }

        public ActionResult StaffSearch(string first, string end, string name, string phone, int pid = 1)
        {
            Init();
            pageModel.currentMenu = 3;
            //获取显示数据
            List<t_user> list = _bll.GetUsersByCondition(first, end, name, phone, pid);
            pageModel.currentIndex = pid;
            pageModel.staffs = list;
            pageModel.pageCount = _bll.GetPageCountByCondition(first, end, name, phone);
            string url = "/sys/Staff/f" + first + "t" + end + "n" + name + "p" + phone;
            pageModel.PageUI = CreatePageUI(url, pageModel.currentIndex, pageModel.pageCount);
            if (first == "1990-01-01")
            {
                pageModel.search_time = "";
            }
            else
            {
                pageModel.search_time = first + " - " + end;
            }

            if (name != "0")
            {
                t_user ml = _bll.GetUserById(name);
                if (ml != null)
                {
                    pageModel.search_name = ml.RealName;
                }
            }
            if (phone != "0")
            {
                pageModel.search_phone = phone;
            }
            else { pageModel.search_phone = ""; }

            return View("StaffManage", pageModel);
        }

        public JsonResult Save(t_user model)
        {
            object obj = new { };
            try
            {
                model.time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                model.Type = "General";
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

        public JsonResult Remove(int id)
        {
            object obj = new { };
            try
            {
                bool res = _bll.RemoveModel(id);
                if (res)
                {
                    obj = new { state = 1, data = "", message = "删除成功" };
                }
                else
                {
                    obj = new { state = 0, data = "", message = "删除失败" };
                }
            }
            catch { obj = new { state = 0, data = "", message = "删除失败" }; }
            return Json(obj);
        }

        public JsonResult RemoveMany(List<int> list)
        {
            object obj = new { };
            try
            {
                bool res = false;
                try
                {
                    foreach (var item in list)
                    {
                        _bll.RemoveModel(item);
                    }
                    res = true;
                }
                catch { res = false; }
                if (res)
                {
                    obj = new { state = 1, data = "", message = "删除成功" };
                }
                else
                {
                    obj = new { state = 0, data = "", message = "删除失败" };
                }
            }
            catch { obj = new { state = 0, data = "", message = "删除失败" }; }
            return Json(obj);
        }

        public JsonResult QueryUrl(string first, string end, string name, string phone)
        {
            object obj = new { };
            if (!Common.CommonFun.IsEmpty(name))
            {
                t_user model = _bll.GetUserByRealName(name);
                if (model == null)
                {
                    obj = new { state = 0, data = "", message = "该用户不存在" };
                }
                else
                {
                    if (Common.CommonFun.IsEmpty(first))
                    {
                        first = "1990-01-01";
                    }
                    if (Common.CommonFun.IsEmpty(end))
                    {
                        end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                    }
                    if (Common.CommonFun.IsEmpty(phone))
                    {
                        phone = "0";
                    }
                    string res = "/sys/Staff/f" + first + "t" + end + "n" + model.ID + "p" + phone;
                    obj = new { state = 1, data = res, message = "" };
                }
            }
            else
            {
                if (Common.CommonFun.IsEmpty(first))
                {
                    first = "1990-01-01";
                }
                if (Common.CommonFun.IsEmpty(end))
                {
                    end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                }
                if (Common.CommonFun.IsEmpty(name))
                {
                    name = "0";
                }
                if (Common.CommonFun.IsEmpty(phone))
                {
                    phone = "0";
                }
                string res = "/sys/Staff/f" + first + "t" + end + "n" + name + "p" + phone;
                obj = new { state = 1, data = res, message = "" };
            }
            return Json(obj);
        }
    }
}