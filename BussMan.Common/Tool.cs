using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussMan.Common
{
    public class Tool
    {
        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsEmpty(object obj)
        {
            bool res = false;
            if (obj == null)
            {
                res = true;
            }else
            {
                string temp = obj.ToString();
                if (string.IsNullOrEmpty(temp))
                {
                    res = true;
                }else if(temp.Trim() == "")
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
