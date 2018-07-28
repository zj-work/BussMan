using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Template.BLL;
using Template.Model;
using Template.Models;

namespace Template.Controllers.Diaplay
{
    public class Disp_CoopController : Disp_BaseController<CoopPageModel>
    {

        private int pageSize = 9;
        private CooperBLL _bll = new CooperBLL();
        // GET: Disp_Coop
        public ActionResult Index(int pageIndex = 1)
        {
            Init();
            pageModel.currentMenu = 3;
            pageModel.pageIndex = pageIndex;
            pageModel.pageCount = GetPageCount();
            pageModel.pageUI = CreatePageUI("/affair", pageIndex, pageModel.pageCount);
            pageModel.list = GetList(pageIndex);
            SetTDK
            (
                pageModel._com.ComName + "-" + "商务合作企业",
                pageModel._com.ComName + "," + "商务合作企业",
                pageModel._com.ComName + "。"
            );
            return View(pageModel);
        }

        private int GetPageCount()
        {
            int n = _bll.GetPageCount(pageSize);
            return n;
        }
        public string CreatePageUI(string url, int currentIndex, int pageCount)
        {
            /**
             * <ul class="fl subPaging">
                <li><a href="#">1</a></li>
                <li><a href="#" class="pagingActive">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">5</a></li>
                <li><a href="#">下一页</a></li>
                <li>共13页&nbsp;&nbsp;到第</li>
                <li>
                  <input type="text" class="grayInput pageNumInput">
                </li>
                <li>页</li>
                <li><a class="pageBtn" href="#">确定</a></li>
              </ul>
             * 
             * 
             * */
            StringBuilder sb = new StringBuilder();
            if (pageCount >= 1) //超过一页才显示
            {
                sb.Append("<ul class=\"fl subPaging\">");
                int start = 1, end = 1;
                start = currentIndex > 5 ? (currentIndex - 5) : 1;//起始页
                end = (start + (currentIndex > 99 ? 4 : 9)) > pageCount ? pageCount : (start + (currentIndex > 99 ? 4 : 9));//结束页
                if (end == pageCount && pageCount > 10) //如果是最后一页显示页码向前13个页面
                {
                    start = pageCount - (currentIndex > 99 ? 4 : 9);
                }
                url += "/p";
                if(currentIndex > 1)
                {
                    sb.Append(" <li><a href=\"" + url  + (currentIndex - 1) + "\">上一页</a></li>");
                }
                while (start <= end)
                {
                    string u = url;
                    u += start;
                    if (start == currentIndex)
                    {
                        sb.Append("<li><a class=\"pagingActive\">" + currentIndex + "</a></li>");
                    }
                    else
                    {
                        sb.Append(" <li><a href=\"" + u + "\">" + start + "</a></li>");
                    }
                    start++;
                }
                if(currentIndex < pageCount)
                {
                    sb.Append(" <li><a href=\"" + url + currentIndex+1 + "\">下一页</a></li>");
                }
                sb.Append("<li>共" + pageCount + "页&nbsp;&nbsp;到第</li>");
                sb.Append("<li><input type =\"text\" class=\"grayInput pageNumInput\" id=\"searchIndex\"></li>");
                sb.Append("<li>页</li>");
                sb.Append("<li><a class=\"pageBtn\" onclick=\"searchPage()\">确定</a></li>");
                sb.Append("</ul>");
            }

            return sb.ToString();
        }


        private List<t_cooperation> GetList(int pageIndex)
        {
            List<t_cooperation> res = new List<t_cooperation>();
            res = _bll.GetCooperByIndex(pageIndex, pageSize);
            return res;
        }
    }
}