using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Template.BLL;
using Template.Model;
using Template.Models;

namespace Template.Controllers
{
    [MemberAuthorize]
    public class BaseController : Controller
    {
        private string Menu_Path = AppDomain.CurrentDomain.BaseDirectory + "Menu.xml";

        private UserBLL _user = new UserBLL();

        public BaseModel model;

        /// <summary>
        /// 根据登录用户的权限，加载菜单
        /// </summary>
        protected void ReadMenu()
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
                        model.menu_List = dic;
                    }
                }
            }
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
    }
}