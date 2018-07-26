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
        private int pageCount = 5;

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

        public List<t_user> GetUsersByCondition(string first, string end, string nid, string phone, int pageIndex)
        {
            int firstIndex = (pageIndex - 1) * pageCount + 1;
            int endIndex = pageIndex * pageCount;
            string name = string.Empty;
            if (nid != "0")
            {
                t_user model = _dal.GetUserById(nid);
                if (model != null)
                {
                    name = model.RealName;
                }
                else
                {
                    name = "";
                }
            }
            else
            {
                name = "";
            }
            if (phone == "0")
            {
                phone = "";
            }
            return _dal.GetUsersByCondition(first, end, name, phone, firstIndex, endIndex);
        }

        public int GetPageCountByCondition(string first, string end, string nid, string phone)
        {
            string name = string.Empty;
            if (nid != "0")
            {
                t_user model = _dal.GetUserById(nid);
                if (model != null)
                {
                    name = model.RealName;
                }
                else
                {
                    name = "";
                }
            }
            if (phone == "0")
            {
                phone = "";
            }
            int num = _dal.GetPageCountByCondition(first, end, name, phone);
            if (num % pageCount == 0)
            {
                return num / pageCount;
            }
            else
            {
                return (num / pageCount) + 1;
            }
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<t_user> GetALL(int pageIndex)
        {
            int firstIndex = (pageIndex - 1) * pageCount + 1;
            int endIndex = pageIndex * pageCount;
            List<t_user> model = _dal.GetAll(firstIndex, endIndex);
            return model;
        }
        public int GetPageCount()
        {
            int num = _dal.GetInfoNum();
            if (num % pageCount == 0)
            {
                return num / pageCount;
            }
            else
            {
                return (num / pageCount) + 1;
            }
        }

        public bool SaveModel(t_user model)
        {
            bool res = false;
            if (Int32.Parse(model.ID) > 0)
            {
                //修改
                res = _dal.Alter(model);
            }
            else
            {
                //添加
                res = _dal.Add(model);
            }
            return res;
        }

        public bool RemoveModel(int id)
        {
            return _dal.RemoveModel(id);
        }

        public t_user GetUserByRealName(string realName)
        {
            t_user model = _dal.GetUserByRealName(realName);
            return model;
        }

        public t_user GetUserById(string id)
        {
            t_user model = _dal.GetUserById(id);
            return model;
        }
        public t_user GetUserByCustName(string cust_name)
        {
            t_user model = _dal.GetUserByName(cust_name);
            return model;
        }
    }
}
