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
    public class CustomerController : BaseController<CustomerModel>
    {

        private CustomBLL _bll = new CustomBLL();
        
        public ActionResult CustomerManage(string kind,int pid = 1)
        {
            if(kind == "all")
            {
                //客户管理
                Init();
                pageModel.currentMenu = 4;

                List<t_customer> list = _bll.GetALL(pid);
                pageModel.currentIndex = pid;
                pageModel.list = list;
                pageModel.pageCount = _bll.GetPageCount();
                string url = "/sys/Customer";
                pageModel.PageUI = CreatePageUI(url, pageModel.currentIndex, pageModel.pageCount);
                return View("CustomerManage",pageModel);
            }
            else
            {
                //好友列表
                Init();
                pageModel.currentMenu = 5;

                List<t_customer> list = _bll.GetFriends(pageModel.loginName, pid);
                pageModel.currentIndex = pid;
                pageModel.list = list;
                pageModel.pageCount = _bll.GetFriendsCount(pageModel.loginName);
                string url = "/sys/Friend";
                pageModel.PageUI = CreatePageUI(url, pageModel.currentIndex, pageModel.pageCount);

                return View("FriendManage", pageModel);
            }
        }

        public JsonResult Save(t_customer model)
        {
            object obj = new { };
            try
            {
                model.time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                model.state = "0";
                model.Content = "";
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
    }
}