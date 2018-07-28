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
    public class IndexController : Disp_BaseController<IndexPageModel>
    {
        private CooperBLL _bll = new CooperBLL();
        private PicBLL _pic = new PicBLL();

        // GET: Index
        public ActionResult Index()
        {
            Init();
            pageModel.currentMenu = 1;

            #region ==banners==
            {
                pageModel.banners = GetBanners();
            }
            #endregion

            #region ==合作企业==
            {
                List<t_cooperation> list = GetCoopers();
                pageModel.coopers = list;
            }
            #endregion

            #region 公司简介
            {
                string str = Common.CommonFun.ClearHtml(pageModel._com.ComInfo);
                if(str.Length > 300)
                {
                    str = str.Substring(0, 300) +"...";
                }
                pageModel.ComInfo = str;
            }
            #endregion

            #region ==设置TDK==
            {
                SetTDK
                (
                    pageModel._com.ComName + "-首页",
                    pageModel._com.ComName + ",艾雪文化",
                    pageModel._com.ComName + "。" + Common.CommonFun.ClearHtml(pageModel._com.ComInfo)
                );
            }
            #endregion

            return View(pageModel);
        }

        private List<t_cooperation> GetCoopers()
        {
            List<t_cooperation> list = _bll.GetAllCooper();
            return list;
        }
        private List<string> GetBanners()
        {
            List<string> list = _pic.GetBanner();
            return list;
        }
    }
}