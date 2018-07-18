using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/****************************************************************
*   作者：Eric
*   CLR版本：4.0.30319.42000
*   创建时间：2018/7/4 16:52:11
*   描述说明：
*
*   修改历史：
*
*****************************************************************/

namespace Template.Model
{
    public struct ResultHandler
    {
        public bool state { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
