using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DAL;
using Template.Model;

namespace Template.BLL
{
    public class PicBLL
    {
        private PicDAL _dal = new PicDAL();

        /// <summary>
        /// 获取公司banner
        /// </summary>
        public List<string> GetBanner()
        {
            List<t_pic> pics = _dal.GetPicsByKind("banner");
            List<string> res = new List<string>();
            if (pics.Count > 0)
            {
                foreach (var item in pics)
                {
                    res.Add(item.Path);
                }
            }
            return res;
        }
        /// <summary>
        /// 保存公司banner
        /// </summary>
        /// <param name="banners"></param>
        public bool SaveBanner(List<string> banners)
        {
            bool res = false;
            try
            {
                //获取banner
                List<t_pic> pics = _dal.GetPicsByKind("banner");
                //删除banner
                foreach (var item in pics)
                {
                    _dal.DeletePics(item);
                }
                //添加banner
                foreach (var item in banners)
                {
                    t_pic temp = new t_pic()
                    {
                        kind = "banner",
                        title = "banner",
                        note = "",
                        Path = item
                    };
                    _dal.SavePics(temp);
                }
                res = true;
            }
            catch { }
            return res;
        }
    }
}
