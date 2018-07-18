using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Template
{
    public class MemberAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["UserInfo"] == null)
            {
                string host = HttpContext.Current.Request.Url.Authority;
                string refer = HttpContext.Current.Request.Url.AbsoluteUri;
                string url = "http://" + host + "/login?url=" + refer;
                HttpContext.Current.Response.Write("<script>window.location.href='" + url + "'</script>");
            }
        }
    }
}