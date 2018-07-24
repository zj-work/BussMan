using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Template
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("登录", "login", new { controller = "User", action = "Login" });
            routes.MapRoute("首页", "sys/index", new { controller = "Home", action = "MIndex" });
            routes.MapRoute("基本信息", "sys/info", new { controller = "Home", action = "MIndex" });
            routes.MapRoute("创业梦工场", "sys/Coin", new { controller = "Project", action = "Index", kind="coin" });
            routes.MapRoute("央视广告", "sys/Advert", new { controller = "Project", action = "Index", kind = "advert" });
            routes.MapRoute("主流媒体宣传", "sys/Media", new { controller = "Project", action = "Index", kind = "media" });
            routes.MapRoute("中央观众赠票", "sys/Center", new { controller = "Project", action = "Index", kind = "center" });
            routes.MapRoute("高端会议", "sys/Meeting", new { controller = "Project", action = "Index", kind = "meeting" });
            routes.MapRoute("员工管理", "sys/Staff", new { controller = "Staff", action = "StaffManage" });
            routes.MapRoute("客户管理", "sys/Customer", new { controller = "Customer", action = "CustomerManage",kind="all" });
            routes.MapRoute("好友管理", "sys/Friend", new { controller = "Customer", action = "CustomerManage", kind = "friend" });
            routes.MapRoute("加入我们", "sys/Join", new { controller = "JoinUs", action = "JoinUsManage" });
            routes.MapRoute("商务合作", "sys/Affair", new { controller = "Cooperate", action = "CooperManage" });

            routes.MapRoute("图片上传", "upload", new { controller = "Util", action = "Upload" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "MIndex", id = UrlParameter.Optional }
            );
        }
    }
}
