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
            routes.MapRoute("员工搜索", "sys/Staff/f{first}t{end}n{name}p{phone}", new { controller = "Staff", action = "StaffSearch",first = UrlParameter.Optional, end = UrlParameter.Optional, name = UrlParameter.Optional, phone = UrlParameter.Optional });

            routes.MapRoute("客户管理", "sys/Customer", new { controller = "Customer", action = "CustomerManage",kind="all" });
            routes.MapRoute("客户搜索", "sys/Customer/f{first}t{end}n{owner}p{custom}", new { controller = "Customer", action = "CustomerSearch", kind = "all", first = UrlParameter.Optional, end = UrlParameter.Optional, owner = UrlParameter.Optional, custom = UrlParameter.Optional });

            routes.MapRoute("好友管理", "sys/Friend", new { controller = "Customer", action = "CustomerManage", kind = "friend" });
            routes.MapRoute("好友搜索", "sys/Friend/f{first}t{end}n{owner}p{custom}", new { controller = "Customer", action = "CustomerSearch", kind = "friend", first = UrlParameter.Optional, end = UrlParameter.Optional, owner = UrlParameter.Optional, custom = UrlParameter.Optional });

            routes.MapRoute("加入我们", "sys/Join", new { controller = "JoinUs", action = "JoinUsManage" });
            routes.MapRoute("商务合作", "sys/Affair", new { controller = "Cooperate", action = "CooperManage" });

            routes.MapRoute("图片上传", "upload", new { controller = "Util", action = "Upload" });

            routes.MapRoute("前台首页S", "index", new { controller = "Index", action = "Index" });
            routes.MapRoute("项目简介S", "project", new { controller = "Dis_Peoject", action = "ProjInfo" });
            routes.MapRoute("创业梦工厂S", "proj/coin", new { controller = "Dis_Peoject", action = "Proj_Detail",kind="coin" });
            routes.MapRoute("央视广告S", "proj/advert", new { controller = "Dis_Peoject", action = "Proj_Detail", kind = "advert" });
            routes.MapRoute("主流媒体宣传S", "proj/media", new { controller = "Dis_Peoject", action = "Proj_Detail", kind = "media" });
            routes.MapRoute("中央观众赠票S", "proj/center", new { controller = "Dis_Peoject", action = "Proj_Detail", kind = "center" });
            routes.MapRoute("高端会议S", "proj/meeting", new { controller = "Dis_Peoject", action = "Proj_Detail", kind = "meeting" });
            routes.MapRoute("商务合作企业S", "affair", new { controller = "Disp_Coop", action = "Index", pageIndex = 1 });
            routes.MapRoute("商务合作企业搜索S", "affair/p{pageIndex}", new { controller = "Disp_Coop", action = "Index",pageIndex = UrlParameter.Optional });
            routes.MapRoute("公司简介S", "info", new { controller = "Disp_Home", action = "Info" });
            routes.MapRoute("加入我们S", "joinus", new { controller = "Disp_JoinUs", action = "Index" });
            routes.MapRoute("联系我们S", "contact", new { controller = "Disp_Home", action = "Message" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
