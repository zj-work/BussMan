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
    public class JoinUsController : BaseController<JoinUsModel>
    {

        private PageBLL _bll = new PageBLL();
        public ActionResult JoinUsManage()
        {
            Init();
            pageModel.currentMenu = 7;
            //获取数据
            List<t_page> list = _bll.GetJoinUs();
            List<t_page> t1 = list.Where(s => s.title.Equals("condition")).ToList();
            pageModel.condition = t1.Count > 0 ? t1.FirstOrDefault() : null;
            List<t_page> t2 = list.Where(s => s.title.Equals("task")).ToList();
            pageModel.task = t2.Count > 0 ? t2.FirstOrDefault() : null;
            List<t_page> t3 = list.Where(s => s.title.Equals("exit")).ToList();
            pageModel.exit = t3.Count > 0 ? t3.FirstOrDefault() : null;
            return View(pageModel);
        }
        [ValidateInput(false)]
        public JsonResult Save(JoinUsModel model)
        {
            bool res = false;
            try
            {
                t_page condition = model.condition;
                t_page task = model.task;
                t_page exit = model.exit;
                condition.kind = "join";
                condition.time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                condition.title = "condition";
                task.kind = "join";
                task.time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                task.title = "task";
                exit.kind = "join";
                exit.time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                exit.title = "exit";
                _bll.SavePage(condition);
                _bll.SavePage(task);
                _bll.SavePage(exit);
                res = true;
            }
            catch { res = false; }
            if (res)
            {
                return Json(new { state = 1, data = "", message = "保存成功" });
            }
            else
            {
                return Json(new { state = 0, data = "", message = "保存失败" });
            }
        }
    }
}