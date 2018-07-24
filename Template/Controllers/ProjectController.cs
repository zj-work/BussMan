using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;

namespace Template.Controllers
{
    public class ProjectController : BaseController<ProjModel>
    {
        // GET: Project
        public ActionResult Index(string kind)
        {
            Init();
            pageModel.currentMenu = 2;
            switch(kind)
            {
                case "coin":
                    pageModel.pageTitle = "创业梦工厂";
                    break;
                case "advert":
                    pageModel.pageTitle = "央视广告";
                    break;
                case "media":
                    pageModel.pageTitle = "主流媒体宣传";
                    break;
                case "center":
                    pageModel.pageTitle = "中央观众赠票";
                    break;
                case "meeting":
                    pageModel.pageTitle = "高端会议";
                    break;
            }
            pageModel.projTitle = "测试标题";
            pageModel.projContent = "<p>测试内容文本</p>";
            return View(pageModel);
        }
    }
}