using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace Template.Common
{
    public class CommonFun
    {
        /// <summary>
        /// 判断字符串是否为空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(object str)
        {
            if (str != null)
            {
                if (string.IsNullOrEmpty(str.ToString()))
                {
                    return true;
                }
                else if (str.ToString() == "" || str.ToString().Trim() == "" || str.ToString() == "null")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }

        /// <summary>  
        /// 清除文本中Html的标签  
        /// </summary>  
        /// <param name="Content"></param>  
        /// <returns></returns>  
        public static string ClearHtml(string Content)
        {
            if (IsEmpty(Content))
            {
                return "";
            }
            else
            {
                Content = Zxj_ReplaceHtml("&#[^>]*;", "", Content);
                Content = Zxj_ReplaceHtml("</?marquee[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?object[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?param[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?embed[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?table[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml(" ", "", Content);
                Content = Zxj_ReplaceHtml("</?tr[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?th[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?p[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?a[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?img[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?tbody[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?li[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?span[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?div[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?th[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?td[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?script[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("(javascript|jscript|vbscript|vbs):", "", Content);
                Content = Zxj_ReplaceHtml("on(mouse|exit|error|click|key)", "", Content);
                Content = Zxj_ReplaceHtml("<\\?xml[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("<\\/?[a-z]+:[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?font[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?b[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?u[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?i[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml("</?strong[^>]*>", "", Content);
                Content = Zxj_ReplaceHtml(@"&nbsp;", "", Content);
                Content = Zxj_ReplaceHtml(@"\n", "", Content);
                Content = Zxj_ReplaceHtml(@"\t", "", Content);
                string clearHtml = Content;
                return clearHtml;
            }
        }

        /// <summary>  
        /// 清除文本中的Html标签  
        /// </summary>  
        /// <param name="patrn">要替换的标签正则表达式</param>  
        /// <param name="strRep">替换为的内容</param>  
        /// <param name="content">要替换的内容</param>  
        /// <returns></returns>  
        private static string Zxj_ReplaceHtml(string patrn, string strRep, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                content = "";
            }
            Regex rgEx = new Regex(patrn, RegexOptions.IgnoreCase);
            string strTxt = rgEx.Replace(content, strRep);
            return strTxt;
        }

        /// <summary>
        /// 获取文本中第一个img标签
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetImgFromString(string content)
        {
            string pattern = "</?img[^>]*?>";
            Regex reg = new Regex(pattern);
            Match result = reg.Match(content);
            return (result.Value == null ? "" : result.Value);
        }


    }
}
