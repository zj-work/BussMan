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
    public class CooperateController : BaseController<CooperModel>
    {

        private CooperBLL _bll = new CooperBLL();

        // GET: Cooperate
        public ActionResult CooperManage(int pid = 1)
        {
            Init();
            pageModel.currentMenu = 6;
            List<t_cooperation> list = _bll.GetCooperByIndex(pid);
            pageModel.currentIndex = pid;
            pageModel.list = list;
            pageModel.pageCount = _bll.GetPageCount();
            string url = "/sys/Affair";
            pageModel.PageUI = CreatePageUI(url, pageModel.currentIndex, pageModel.pageCount);
            return View(pageModel);
        }

        public JsonResult SaveCooper(t_cooperation model)
        {
            object obj = new { };
            try
            {
                model.time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                model.state = "0";
                model.url = "";
                model.note = "";
                bool res = _bll.SaveModel(model);
                if (res)
                {
                    //获取用户ID，并返回
                    t_cooperation temp = _bll.GetModelByName(model.name);
                    obj = new { state = 1, data = temp.ID, message = "保存合作伙伴成功" };
                }
                else
                {
                    obj = new { state = 0, data = "", message = "保存合作伙伴失败" };
                }
            }
            catch { obj = new { state = 0, data = "", message = "保存合作伙伴失败" }; }
            return Json(obj);
        }

        public JsonResult RemoveCooper(int id)
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

        public JsonResult RemoveManyCooper(List<int> list)
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

        public ActionResult Index()
        {
            return View();
        }

    }
}