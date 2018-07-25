using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DAL;
using Template.Model;
using Template.Common;


/****************************************************************
*   作者：Eric
*   CLR版本：4.0.30319.42000
*   创建时间：2018/7/4 15:10:08
*   描述说明：
*
*   修改历史：
*
*****************************************************************/

namespace Template.BLL
{
    public class UserBLL : BaseBLL
    {
        private UserDAL _dal = new UserDAL();

        public string GetKindByName(string cust_name)
        {
            t_user model = _dal.GetUserByName(cust_name);
            if (CommonFun.IsEmpty(model))
            {
                return "";
            }
            else
            {
                return model.Type;
            }
        }

        public ResultHandler Login(string name, string pwd)
        {
            ResultHandler res = new ResultHandler();
            t_user model = _dal.GetUserByName(name);
            if (CommonFun.IsEmpty(model))
            {
                res.state = false;
                res.message = "该用户不存在";
            }
            else
            {
                if (!model.Pwd.Equals(pwd))
                {
                    res.state = false;
                    res.message = "用户名或密码错误";
                }
                else
                {
                    res.state = true;
                    res.message = "登录成功";
                    res.data = model;
                }
            }
            return res;
        }

        public List<t_user> GetUsersByCondition(string time, string name, string phone)
        {
            return _dal.GetUsersByCondition(DateTime.Parse(time), name, phone);
        }
    }
}
