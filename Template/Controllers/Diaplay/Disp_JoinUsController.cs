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
    public class Disp_JoinUsController : Disp_BaseController<JoinUsPageModel>
    {
        private PageBLL _bll = new PageBLL();

        public ActionResult Index()
        {
            Init();
            pageModel.currentMenu = 4;
            List<t_page> list = _bll.GetJoinUs();
            List<t_page> t1 = list.Where(s => s.title.Equals("condition")).ToList();
            pageModel.condition = t1.Count > 0 ? t1.FirstOrDefault() : null;
            List<t_page> t2 = list.Where(s => s.title.Equals("task")).ToList();
            pageModel.task = t2.Count > 0 ? t2.FirstOrDefault() : null;
            List<t_page> t3 = list.Where(s => s.title.Equals("exit")).ToList();
            pageModel.exit = t3.Count > 0 ? t3.FirstOrDefault() : null;

            SetTDK
            (
                pageModel._com.ComName + "-" + "加入我们",
                pageModel._com.ComName + "," + "加入我们",
                pageModel._com.ComName + "。"
            );

            return View(pageModel);
        }
    }
}