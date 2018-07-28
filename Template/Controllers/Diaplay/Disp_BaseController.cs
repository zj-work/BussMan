using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Template.BLL;
using Template.Model;

namespace Template.Controllers.Diaplay
{
    public class Disp_BaseController<T> : Controller where T : class, new()
    {
        public T pageModel = new T();

        protected void Init()
        {
            #region 获取公司基本信息

            ComBLL _bll = new ComBLL();
            t_com item = _bll.GetComModel();
            PropertyInfo pinfo = pageModel.GetType().GetProperty("_com");
            if (pinfo != null)
            {
                pinfo.SetValue(pageModel, item);
            }

            #endregion
        }

        protected void SetTDK(string title, string key, string desc)
        {
            ViewBag.Title = title;
            ViewBag.Desc = desc;
            ViewBag.Key = key;
        }
    }
}