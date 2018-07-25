using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Template.BLL;
using Template.Model;
using Template.Models;

namespace Template.Controllers
{
    [MemberAuthorize]
    public class BaseController<T> : Controller where T :class, new()
    {
        private string Menu_Path = AppDomain.CurrentDomain.BaseDirectory + "Menu.xml";

        private UserBLL _user = new UserBLL();

        public T pageModel = new T();

        /// <summary>
        /// 根据登录用户的权限，加载菜单
        /// </summary>
        protected void Init()
        {
            string cust_kind = string.Empty;
            #region 获取用户类型
            {
                try
                {
                    t_user user = Session["UserInfo"] as t_user;
                    string cust_name = user.Cust_Name;
                    cust_kind =  _user.GetKindByName(cust_name);
                }catch { }
            }
            #endregion

            #region 设置菜单
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Menu_Path);
                XmlNode root = doc.SelectSingleNode("Root");
                XmlNodeList menu = root.SelectNodes("Menu");
                foreach (XmlNode item in menu)
                {
                    if (item.Attributes["Type"].Value.Equals(cust_kind))
                    {
                        XmlNodeList childMenu = item.SelectNodes("ChildMenu");
                        Dictionary<MenuItem, List<MenuItem>> dic = new Dictionary<MenuItem, List<MenuItem>>();
                        foreach (XmlNode node in childMenu)
                        {
                            MenuItem child = new MenuItem();
                            string text = node.Attributes["Text"].Value.ToString();
                            string icon = node.Attributes["Icon"].Value.ToString();
                            bool isopen = Boolean.Parse(node.Attributes["IsOpen"].Value.ToString());
                            string url = node.Attributes["Url"].Value.ToString();
                            child.Text = text;
                            child.Icon = icon;
                            child.IsOpen = isopen;
                            child.Url = url;
                            List<MenuItem> items = new List<MenuItem>();
                            if (child.IsOpen)
                            {
                                XmlNodeList temps = node.SelectNodes("Item");
                                foreach (XmlNode temp in temps)
                                {
                                    MenuItem tempchild = new MenuItem();
                                    string temptext = temp.Attributes["Text"].Value.ToString();
                                    string tempicon = temp.Attributes["Icon"].Value.ToString();
                                    bool tempisopen = Boolean.Parse(temp.Attributes["IsOpen"].Value.ToString());
                                    string tempurl = temp.Attributes["Url"].Value.ToString();
                                    tempchild.Text = temptext;
                                    tempchild.Icon = tempicon;
                                    tempchild.IsOpen = tempisopen;
                                    tempchild.Url = tempurl;
                                    items.Add(tempchild);
                                }
                            }
                            dic.Add(child, items);
                        }

                        PropertyInfo pinfo = pageModel.GetType().GetProperty("menu_List");
                        if (pinfo != null)
                        {
                            pinfo.SetValue(pageModel, dic);
                        }
                    }
                }
            }
            #endregion

            #region 设置登录用户的信息

            try
            {
                t_user user = Session["UserInfo"] as t_user;
                PropertyInfo pinfo = pageModel.GetType().GetProperty("loginName");
                if (pinfo != null)
                {
                    pinfo.SetValue(pageModel, user.Cust_Name);
                }
            }
            catch { }

            #endregion

        }

        /// <summary>
        /// 获取图片路径
        /// </summary>
        /// <returns></returns>
        public string GetFilePath()
        {
            string path = string.Empty;
            try
            {
                path = ConfigurationManager.AppSettings["imgpath"].ToString();
            }
            catch
            {
                path = "";
            }
            return path;
        }

        public string CreatePageUI(string url, int currentIndex,int pageCount)
        {
            StringBuilder sb = new StringBuilder();
            if (pageCount >= 1) //超过一页才显示
            {
                sb.Append("<ul class=\"pagination clearfix\">");

                int start = 1, end = 1;
                start = currentIndex > 5 ? (currentIndex - 5) : 1;//起始页
                end = (start + (currentIndex > 99 ? 4 : 9)) > pageCount ? pageCount : (start + (currentIndex > 99 ? 4 : 9));//结束页
                if (end == pageCount && pageCount > 10) //如果是最后一页显示页码向前13个页面
                {
                    start = pageCount - (currentIndex > 99 ? 4 : 9);
                }
                if (!url.Contains('?'))
                {
                    url += "?";
                }
                else
                {
                    url += "&";
                }
                sb.Append(" <li class=\"paginate_button \"><a href=\"" + url+"pid=1" + "\" aria-controls=\"DataTables_Table_0\" data-dt-idx=\"3\" tabindex=\"0\">首页</a></li>");
                while (start <= end)
                {
                    string u = url;
                    u += "pid=" + start;
                    if (start == currentIndex)
                    {
                        sb.Append("<li class=\"paginate_button active\"><a aria-controls=\"DataTables_Table_0\" data-dt-idx=\"1\" tabindex=\"0\">" + currentIndex + "</a></li>");
                    }
                    else
                    {
                        sb.Append(" <li class=\"paginate_button \"><a href=\"" + u + "\" aria-controls=\"DataTables_Table_0\" data-dt-idx=\"3\" tabindex=\"0\">" + start + "</a></li>");
                    }
                    start++;
                }
                sb.Append(" <li class=\"paginate_button \"><a href=\"" + url + "pid="+pageCount + "\" aria-controls=\"DataTables_Table_0\" data-dt-idx=\"3\" tabindex=\"0\">尾页</a></li>");
                sb.Append("</ul>");
            }

            return sb.ToString();
        }
    }
}