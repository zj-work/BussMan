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
    public class ClientController : BaseController<CustomerModel>
    {
        private CustomBLL _bll = new CustomBLL();
        private UserBLL _user = new UserBLL();

        public ActionResult MyQR()
        {
            Init();
            pageModel.currentMenu = 1;
            return View(pageModel);
        }

        public ActionResult MineCustom(int pid = 1)
        {
            Init();
            pageModel.currentMenu = 2;

            List<t_customer> list = _bll.GetFriends(pageModel.loginRealName, pid);
            pageModel.currentIndex = pid;
            pageModel.list = list;
            pageModel.pageCount = _bll.GetFriendsCount(pageModel.loginRealName);
            string url = "/sys/Client";
            pageModel.PageUI = CreatePageUI(url, pageModel.currentIndex, pageModel.pageCount);

            return View(pageModel);
        }

        public ActionResult MineCustomerSearch(string kind, string first, string end, string owner, string custom, int pid = 1)
        {

            //好友列表
            Init();
            pageModel.currentMenu = 2;

            List<t_customer> list = _bll.GetCustomsByCondition(first, end, owner, custom, pid);
            pageModel.currentIndex = pid;
            pageModel.list = list;
            pageModel.pageCount = _bll.GetPageCountByCondition(first, end, owner, custom);
            string url = "/sys/Client";
            pageModel.PageUI = CreatePageUI(url, pageModel.currentIndex, pageModel.pageCount);

            if (first == "1990-01-01")
            {
                pageModel.search_time = "";
            }
            else
            {
                pageModel.search_time = first + " - " + end;
            }

            if (custom != "0")
            {
                t_customer ml = _bll.GetCustomsById(custom);
                if (ml != null)
                {
                    pageModel.search_custom = ml.Name;
                }
            }

            return View("FriendManage", pageModel);

        }

        public JsonResult Save(t_customer model)
        {
            object obj = new { };
            try
            {
                model.time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                model.state = "0";
                model.Content = Common.CommonFun.IsEmpty(model.Content) ? "" : model.Content;
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

        public JsonResult QueryUrl(string first, string end, string owner, string custom, string kind)
        {
            object obj = new { };
            string res = string.Empty;
            res = "/sys/Client/";
            if (Common.CommonFun.IsEmpty(first))
            {
                first = "1990-01-01";
            }
            if (Common.CommonFun.IsEmpty(end))
            {
                end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            }

            if (!Common.CommonFun.IsEmpty(owner))
            {
                t_user model = _user.GetUserByRealName(owner);
                if (model == null)
                {
                    return Json(new { state = 0, data = "", message = "该负责人不存在" });
                }
                else
                {
                    owner = model.ID;
                }
            }
            else
            {
                owner = "0";
            }

            if (!Common.CommonFun.IsEmpty(custom))
            {
                t_customer model = _bll.GetCustomByRealName(custom);
                if (model == null)
                {
                    return Json(new { state = 0, data = "", message = "该客户不存在" });
                }
                else
                {
                    custom = model.ID;
                }
            }
            else
            {
                custom = "0";
            }
            res += "f" + first + "t" + end + "n" + owner + "p" + custom;
            obj = new { state = 1, data = res, message = "" };
            return Json(obj);
        }
    }
}