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
    public class ProjectController : BaseController<ProjModel>
    {
        private PageBLL _bll = new PageBLL();
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
            //获取项目详细信息
            t_page item = _bll.GetPageByKind(kind);
            pageModel.projTitle = Common.CommonFun.IsEmpty(item) ? "" : item.title;
            pageModel.projContent = Common.CommonFun.IsEmpty(item) ? "" : item.content;
            pageModel.kind = kind;
            pageModel.id = Common.CommonFun.IsEmpty(item) ? "-1" : item.ID;
            pageModel.viewnum = Common.CommonFun.IsEmpty(item) ? "0" : item.viewnum;
            return View(pageModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SavePage(t_page model)
        {
            object res = new { };
            if (_bll.SavePage(model))
            {
                res = new { state = 1, data = "", message = "保存项目信息成功" };
            }
            else
            {
                res = new { state = 0, data = "", message = "保存项目信息失败" };
            }
            return Json(res);
        }

    }
}