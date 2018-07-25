﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DAL;
using Template.Model;

namespace Template.BLL
{
    public class CooperBLL
    {
        private CooperDAL _dal = new CooperDAL();
        private int pageCount = 5;
        /// <summary>
        /// 后台管理--合作客户列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<t_cooperation> GetCooperByIndex(int pageIndex)
        {
            int firstIndex = (pageIndex - 1) * pageCount + 1;
            int endIndex = pageIndex * pageCount;
            List<t_cooperation> model = _dal.GetCooperWithoutCondition(firstIndex, endIndex);
            return model;
        }

        public int GetPageCount()
        {
            int num = _dal.GetInfoNum();
            if(num % pageCount == 0)
            {
                return num / pageCount;
            }
            else
            {
                return (num / pageCount) + 1;
            }
        }

        public bool SaveModel(t_cooperation model)
        {
            bool res = false;
            if(Int32.Parse(model.ID) > 0)
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

        public t_cooperation GetModelByName(string name)
        {
            return _dal.GetCooperByName(name);
        }

        public bool RemoveModel(int id)
        {
            return _dal.RemoveModel(id);
        }
    }
}