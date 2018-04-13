using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussMan.Model;

namespace BussMan.BLL
{
    public class BMenu
    {
        private BussMan.DAL.DMenu _menu = new DAL.DMenu();
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="model"></param>
        public bool AddMenu(t_menu model)
        {
            return _menu.AddMenu(model);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public bool AlterMenu(t_menu model, string[] para)
        {
            return _menu.AlterMenu(model, para);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteMenu(int id)
        {
            return _menu.DeleteMenu(id);
        }

        /// <summary>
        /// 获取等级菜单
        /// </summary>
        /// <param name="pid">父级菜单编号 默认-1:获取一级菜单</param>
        /// <param name="target">标志 sys:后台菜单 dis:前台菜单</param>
        /// <returns></returns>
        public List<t_menu> GetMenuByRank(int pid = -1, string target = "disp")
        {
            return _menu.GetMenuByRank(pid, target);
        }
    }
}
