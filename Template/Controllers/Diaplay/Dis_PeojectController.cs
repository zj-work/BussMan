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
    public class Dis_PeojectController : Disp_BaseController<ProjectPageModel>
    {
        private PageBLL _bll = new PageBLL();
        /// <summary>
        /// 项目首页
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjInfo()
        {
            Init();
            pageModel.currentMenu = 2;
            SetTDK
            (
                pageModel._com.ComName + "-项目简介",
                pageModel._com.ComName + ",创业梦工场,央视广告,主流媒体宣传,中央观众赠票,高端会议",
                pageModel._com.ComName
            );
            //获取页面数据并显示
            string[] kinds = new string[]
            {
                "coin","advert","media","center","meeting"
            };
            foreach (var item in kinds)
            {
                t_page pageItem = _bll.GetPageByKind(item);
                switch (item)
                {
                    case "coin":
                        pageModel.coinContent = Common.CommonFun.IsEmpty(pageItem) ? "" : GetShowContent(pageItem.content);
                        break;
                    case "advert":
                        pageModel.advertContent = Common.CommonFun.IsEmpty(pageItem) ? "" : GetShowContent(pageItem.content);
                        break;
                    case "media":
                        pageModel.mediaContent = Common.CommonFun.IsEmpty(pageItem) ? "" : GetShowContent(pageItem.content);
                        break;
                    case "center":
                        pageModel.centerContent = Common.CommonFun.IsEmpty(pageItem) ? "" : GetShowContent(pageItem.content);
                        break;
                    case "meeting":
                        pageModel.meetingContent = Common.CommonFun.IsEmpty(pageItem) ? "" : GetShowContent(pageItem.content);
                        break;
                }
            }

            return View(pageModel);
        }

        private string GetShowContent(string content)
        {
            string res = string.Empty;
            content = Common.CommonFun.ClearHtml(content);
            if (content.Length > 300)
            {
                res = content.Substring(0, 300) + "...";
            }
            else
            {
                res = content;
            }
            return res;
        }

        /// <summary>
        /// 5中不同类型的项目
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        public ActionResult Proj_Detail(string kind)
        {
            Init();
            pageModel.currentMenu = 2;
            pageModel.PageModel = _bll.GetPageByKind(kind);
            string res = string.Empty;
            switch (kind)
            {
                case "coin":
                    res = "创业梦工场";
                    break;
                case "advert":
                    res = "央视广告";
                    break;
                case "media":
                    res = "主流媒体宣传";
                    break;
                case "center":
                    res = "中央观众赠票";
                    break;
                case "meeting":
                    res = "高端会议";
                    break;
            }
            SetTDK
            (
                pageModel._com.ComName + "-" + res,
                pageModel._com.ComName + "," + res,
                pageModel._com.ComName + "。" + (Common.CommonFun.IsEmpty(pageModel.PageModel) ? "" : GetShowContent(pageModel.PageModel.content))
            );
            return View(pageModel);
        }
    }
}