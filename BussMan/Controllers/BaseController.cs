using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BussMan.Controllers
{
    public class BaseController<T> : Controller where T : class, new()
    {
        public T pageModel = new T();
        public Model.t_site _site = new Model.t_site();

        public BaseController(bool isMain= true)
        {
            pageInit(isMain);
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="isMain">分部试图 为 false， 防止分部视图重复执行</param>
        private void pageInit(bool isMain)
        {
            BussMan.BLL.BSite _siteBLL = new BussMan.BLL.BSite();
            _site = _siteBLL.GetSite();
            System.Reflection.PropertyInfo psite = pageModel.GetType().GetProperty("SiteInfo");
            if (psite != null)
            {
                psite.SetValue(pageModel, _site);
            }
            if (isMain)
            {//只有主视图才会执行的操作，比如判断登录信息，设置TDK等等

            }
        }

        /// <summary>
        /// 设置TDK
        /// </summary>
        /// <param name="title"></param>
        /// <param name="key"></param>
        /// <param name="desc"></param>
        private void SetTDK(string title, string key, string desc)
        {

        }

        /// <summary>
        /// 跳转404
        /// </summary>
        public void Go404()
        {

            HandleErrorInfo errorModel;
            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = "Error404";
            errorModel = new HandleErrorInfo
                    (
                        new Exception(string.Format("No page Found", Request.UrlReferrer), null),
                        "Error",
                        "Error404"
                    );

            Response.Clear();
            Response.ContentType = "text/html";
            Response.StatusCode = 404;
            Response.BufferOutput = true;
            var controller = new ErrorController();
            controller.ViewData.Model = errorModel; //通过代码路由到指定的路径  
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), routeData));

        }
    }
}