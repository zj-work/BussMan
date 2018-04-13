using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BussMan.Controllers
{
    public class SBaseController<T> : Controller where T : class, new()
    {
        public T pageModel = new T();


        public SBaseController()
        {
            pageInit();
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="isMain">分部试图 为 false， 防止分部视图重复执行</param>
        private void pageInit()
        {
            Model.t_site _site = new Model.t_site();
            BussMan.BLL.BSite _siteBLL = new BussMan.BLL.BSite();
            _site = _siteBLL.GetSite();
            System.Reflection.PropertyInfo psite = pageModel.GetType().GetProperty("SiteInfo");
            if (psite != null)
            {
                psite.SetValue(pageModel, _site);
            }

            Dictionary<Model.t_menu, List<Model.t_menu>> _menus = new Dictionary<Model.t_menu, List<Model.t_menu>>();
            BussMan.BLL.BMenu _menuBLL = new BLL.BMenu();
            List<Model.t_menu> list = _menuBLL.GetMenuByRank(-1, "sys");
            foreach (var item in list)
            {
                List<Model.t_menu> temp = _menuBLL.GetMenuByRank(item.id, "sys");
                try
                {
                    _menus.Add(item, temp);
                }
                catch { }
            }
            System.Reflection.PropertyInfo pmenu = pageModel.GetType().GetProperty("Menu");
            if (pmenu != null)
            {
                pmenu.SetValue(pageModel, _menus);
            }
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