using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BussMan
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            string url = Context.Request.Url.ToString();
            string template = GetTemplate(url);
            if (Common.Tool.IsEmpty(template))
            {
                //跳转404页面
                Go404();
            }else
            {
                SetViewEngine(template);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            if (exception == null)
                return;
            var httpException = exception as HttpException ?? new HttpException(500, "服务器内部错误", exception);
            int errorCode = httpException.GetHttpCode();
            var shouldHandleException = true;
            HandleErrorInfo errorModel;
            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";
            int status = 500;
            switch (errorCode)
            {
                case 404:
                    status = 404;
                    routeData.Values["action"] = "Error404";
                    errorModel = new HandleErrorInfo
                        (
                            new Exception(string.Format("No page Found", HttpContext.Current.Request.UrlReferrer), exception),
                            "Error",
                            "Error404"
                        );
                    break;
                case 500:
                    routeData.Values["action"] = "Error500";
                    errorModel = new HandleErrorInfo
                        (
                            new Exception(string.Format("No page Found", HttpContext.Current.Request.UrlReferrer), exception),
                            "Error",
                            "Error500"
                        );
                    break;
                default:
                    routeData.Values["action"] = "Error500";
                    errorModel = new HandleErrorInfo
                        (
                            new Exception(string.Format("No page Found", HttpContext.Current.Request.UrlReferrer), exception),
                            "Error",
                            "Error500"
                        );
                    break;
            }
            Server.ClearError();
            if (shouldHandleException)
            {

                Response.Clear();
                Response.ContentType = "text/html";
                Response.StatusCode = status;
                Response.BufferOutput = true;
                var controller = new Controllers.ErrorController();
                controller.ViewData.Model = errorModel; 
                ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(HttpContext.Current), routeData));
            }
        }


        private void Go404()
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
            var controller = new Controllers.ErrorController();
            controller.ViewData.Model = errorModel; //通过代码路由到指定的路径  
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), routeData));

        }


        /// <summary>
        /// 设置模板
        /// </summary>
        /// <param name="template"></param>
        private void SetViewEngine(string template)
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new BussManViewEngine(template));
        }

        /// <summary>
        /// 根据url链接，获取模板
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetTemplate(string url)
        {
            string res = string.Empty;
            if (!Common.Tool.IsEmpty(url))
            {
                if (url.Contains("sys"))
                {
                    res = "System";
                }
                else
                {
                    res = "Display";
                }
            }
            return res;
        }
    }
}
