using System;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace Template.Common
{
    public class CommonFun
    {

        /// <summary>
        /// 序列化数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(object obj)
        {
            string res = string.Empty;
            try
            {
                JavaScriptSerializer serialize = new JavaScriptSerializer();
                res = serialize.Serialize(obj);
            }
            catch { res = null; }
            return res;
        }

        /// <summary>
        /// 根据数据库中的图片路径获取img2上的按照一定比例的缩略图的路径
        /// </summary>
        /// <param name="with"></param>
        /// <param name="height"></param>
        /// <param name="sourceUrl"></param>
        /// <returns></returns>
        public static string GetThumUrl(string with = "0", string height = "0", string sourceUrl="")
        {
            if (sourceUrl != null)
            {
                string[] str_url = sourceUrl.Split('.');
                if (str_url.Length == 2)
                {
                    if (with == "0" && height == "0")
                    {
                        return "http://img2.chinawutong.com" + sourceUrl;
                    }
                    else
                    {
                        return "http://img2.chinawutong.com" + str_url[0] + "_" + with + "x" + height + "." + str_url[1];
                    }
                }
                else
                {
                    return "http://www.chinawutong.com/Images/nopiclogo.jpg";
                }
            }
            else
            {
                return "http://www.chinawutong.com/Images/nopiclogo.jpg";
            }
        }

        /// <summary>
        /// 去除地域信息中的敏感词汇 省、市、区、县等等
        /// </summary>
        /// <param name="areaName"></param>
        /// <returns></returns>
        public static string TrimArea(string areaName)
        {
            if (areaName != null)
            {
                if (areaName.Length > 2)
                {
                    if (areaName == "市辖区")
                    {
                        areaName = "";
                    }
                    else
                    {
                        areaName = areaName.Replace("省", "").Replace("市", "").Replace("地区", "").Replace("自治州", "").Replace("区", "").Replace("盟", "").Replace("县", "").Replace("直辖", "");
                        areaName = areaName.Length > 4 && areaName.EndsWith("州") ? areaName.Replace("州", "") : areaName;
                    }
                }
            }
            return areaName;
        }

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
        /// 处理车牌号
        /// </summary>
        /// <param name="chehao"></param>
        /// <returns></returns>
        public static string DealLicense(string license)
        {
            string result = string.Empty;
            if (IsEmpty(license))
            {
                result = "不详";
            }
            else if (license.Length < 5)
            {
                result = "不详";
            }
            else
            {
                result = license.Replace(license.Substring(2, 3), "***");
            }
            return result;
        }

        /// <summary>
        /// 获取重货价单位
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static string GetUnit(string unit)
        {
            string result = string.Empty;
            if (IsEmpty(unit))
            {
                result = "";
            }
            else
            {
                string[] units = unit.Split('-');
                if (units.Length == 4)
                {
                    result = "元/" + units[1];
                }
                else
                {
                    result = "";
                }
            }
            return result;
        }

        /// <summary>
        /// 货源显示时间处理
        /// </summary>
        /// <param name="olderTime"></param>
        /// <returns></returns>
        public static string GetTimeShow(DateTime olderTime)
        {
            /*
             *货源时间显示规则：
             *  time<2min 显示为：刚刚 
             *  2min < time < 60min 显示为：**分钟前
             *  当天 显示为：**小时前
             *  else 显示为 MM-dd
             */
            string res = string.Empty;
            TimeSpan ts = DateTime.Now - olderTime;
            if (ts.TotalMinutes <= 2)
            {
                res = "刚刚";
            }
            else if (ts.TotalMinutes < 60)
            {
                res = (int)ts.TotalMinutes + "分钟前";
            }
            else if (olderTime.Month == DateTime.Now.Month && olderTime.Day == DateTime.Now.Day)
            {
                res = (int)ts.TotalHours + "小时前";
            }
            else
            {
                res = olderTime.ToString("MM-dd");
            }
            return res;
        }

        /// <summary>
        /// 从json文件中读取json字符串
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetFileJson(string filepath)
        {
            string json = string.Empty;
            try
            {
                using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("UTF-8")))
                    {
                        json = sr.ReadToEnd().ToString();
                    }
                }
            }
            catch (Exception ex) { }
            return json;
        }

        /// <summary>
        /// 跟据诚信指数，获取诚信年限
        /// </summary>
        /// <param name="ChengXinState"></param>
        /// <param name="vyear"></param>
        /// <returns></returns>
        public static int GetSincerityYear(int ChengXinState, int vyear)
        {
            int result = 0;
            if (ChengXinState == 1)
            {
                result = vyear;
            }
            else if (ChengXinState < 0)
            {
                result = vyear + ChengXinState;
            }
            return result;
        }

        /// <summary>
        /// 处理 省-市-区县 类型数据，获取 省 信息
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public static string GetPro(string area)
        {
            try
            {
                return area.Split(new string[] { "-" }, 0)[0].ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 处理 省-市-区县 类型数据，获取 市 信息
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public static string GetCity(string area)
        {
            try
            {
                return area.Split(new string[] { "-" }, 0)[1].ToString();
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 处理 省-市-区县 类型数据，获取 区县 信息
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public static string GetArea(string area)
        {
            try
            {
                return area.Split(new string[] { "-" }, 0)[2].ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        ///SQL注入过滤
        ///董玉超 2012-2-17
        /// </summary>
        /// <param name="InText">要过滤的字符串</param>
        /// <returns>如果参数存在不安全字符，则返回true</returns>
        public static string SqlFilter(string InText)
        {
            string word = "exec|insert|select|delete|update|master|truncate|declare|join|'|:|\"|*|$|;|(|)|,|count|%|user|=";
            foreach (string str_t in word.Split('|'))
            {
                if (InText.ToLower().IndexOf(str_t) > -1)
                {
                    InText = InText.ToLower().Replace(str_t, "");
                }
            }
            return InText;
        }
    }
}
