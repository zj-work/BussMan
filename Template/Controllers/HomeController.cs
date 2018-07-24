using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.BLL;
using Template.Models;

namespace Template.Controllers
{
    public class HomeController : BaseController<IndexModel>
    {
        private ComBLL _bll = new ComBLL();
        /// <summary>
        /// 管理系统后台-首页
        /// </summary>
        /// <returns></returns>
        public ActionResult MIndex()
        {
            Init();
            pageModel.currentMenu = 1;

            //获取公司基本信息
            pageModel.comModel = _bll.GetComModel();
            //获取公司banner
            List<string> banners = new PicBLL().GetBanner();
            try
            {
                pageModel.banner_01 = banners[0];
                pageModel.banner_02 = banners[1];
                pageModel.banner_03 = banners[2];
            }
            catch { }
            return View(pageModel);
        }

        [ValidateInput(false)]
        public JsonResult MIndex_Handle(IndexModel model)
        {
            bool res = false;
            try
            {
                //保存公司信息
                res = _bll.SaveCom(model.comModel);
                //保存banner信息
                if (res)
                {
                    List<string> list = new List<string>()
                    {
                        model.banner_01,
                        model.banner_02,
                        model.banner_03
                    };
                    res = new PicBLL().SaveBanner(list);
                }
            }
            catch { res = false; }
            object obj = new { };
            if (res)
            {
                obj = new
                {
                    state = 1,
                    model = "",
                    message = "保存公司信息成功"
                };
            }
            else
            {
                obj = new
                {
                    state = 0,
                    model = "",
                    message = "保存公司信息失败"
                };
            }
            return Json(obj);
        }
    }
}