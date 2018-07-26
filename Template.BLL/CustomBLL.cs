using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DAL;
using Template.Model;

namespace Template.BLL
{
    public class CustomBLL
    {

        private CustomDAL _dal = new CustomDAL();
        private UserDAL _user = new UserDAL();

        private int pageCount = 5;
        /// <summary>
        /// 获取所有人的客户列表
        /// </summary>
        /// <returns></returns>
        public List<t_customer> GetALL(int pageIndex)
        {
            int firstIndex = (pageIndex - 1) * pageCount + 1;
            int endIndex = pageIndex * pageCount;
            List<t_customer> model = _dal.GetAll(firstIndex, endIndex);
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

        public List<t_customer> GetFriends(string owner, int pageIndex)
        {
            int firstIndex = (pageIndex - 1) * pageCount + 1;
            int endIndex = pageIndex * pageCount;
            List<t_customer> model = _dal.GetAllByOwner(owner,firstIndex, endIndex);
            return model;
        }
        public int GetFriendsCount(string owner)
        {
            int num = _dal.GetInfoNumByOwner(owner);
            if (num % pageCount == 0)
            {
                return num / pageCount;
            }
            else
            {
                return (num / pageCount) + 1;
            }
        }

        public List<t_customer> GetCustomsByCondition(string first, string end, string oid, string cid,int pageIndex)
        {
            int firstIndex = (pageIndex - 1) * pageCount + 1;
            int endIndex = pageIndex * pageCount;

            string owner = string.Empty;
            if (oid != "0")
            {
                t_user model = _user.GetUserById(oid);
                if (model != null)
                {
                    owner = model.RealName;
                }
                else
                {
                    owner = "";
                }
            }
            else { owner = ""; }

            string custom = string.Empty;
            if (cid != "0")
            {
                t_customer model = _dal.GetCustomById(cid);
                if (model != null)
                {
                    custom = model.Name;
                }
                else
                {
                    custom = "";
                }
            }
            else { custom = ""; }

            return _dal.GetCustomByCondition(first, end, owner, custom, firstIndex, endIndex);

        }

        public int GetPageCountByCondition(string first, string end, string oid, string cid)
        {
            string owner = string.Empty;
            if (oid != "0")
            {
                t_user model = _user.GetUserById(oid);
                if (model != null)
                {
                    owner = model.RealName;
                }
                else
                {
                    owner = "";
                }
            }
            else { owner = ""; }

            string custom = string.Empty;
            if (cid != "0")
            {
                t_customer model = _dal.GetCustomById(cid);
                if (model != null)
                {
                    custom = model.Owner;
                }
                else
                {
                    custom = "";
                }
            }
            else { custom = ""; }

            int num = _dal.GetPageCountByCondition(first, end, owner, custom);
            if (num % pageCount == 0)
            {
                return num / pageCount;
            }
            else
            {
                return (num / pageCount) + 1;
            }
        }

        public bool SaveModel(t_customer model)
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

        public t_customer GetCustomByRealName(string name)
        {
            t_customer model = _dal.GetCustomByRealName(name);
            return model;
        }

        public t_customer GetCustomsById(string id)
        {
            t_customer model = _dal.GetCustomById(id);
            return model;
        }

    }
}
