using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Common;

namespace Template.Controllers
{
    public class UtilController : BaseController
    {
        [HttpPost]
        public JsonResult Upload()
        {
            object obj = new { };
            try
            {

                if (Request["REQUEST_METHOD"] == "OPTIONS")
                {
                    Response.End();
                }

                string name = string.Empty;
                #region 获取文件名称

                HttpFileCollectionBase files = Request.Files;

                var suffix = files[0].ContentType.Split('/');
                var _suffix = suffix[1].Equals("jpeg", StringComparison.CurrentCultureIgnoreCase) ? "" : suffix[1];
                var _temp = Request["name"];

                if (!string.IsNullOrEmpty(_temp))
                {
                    name = _temp;
                }
                else
                {
                    Random rand = new Random(24 * (int)DateTime.Now.Ticks);
                    name = rand.Next() + "." + _suffix;
                } 

                #endregion

                #region 创建文件夹以及设置路径

                string basePath = GetFilePath();
                string serverBasePath = (basePath.IndexOf("..") > -1) ? basePath.Replace("..", "~") : basePath;
                string full = Server.MapPath(serverBasePath);
                if (!Directory.Exists(full))
                {
                    Directory.CreateDirectory(full);
                }
                full += name; 

                #endregion

                #region 保存文件

                Stream streame = files[0].InputStream;
                byte[] data = new byte[streame.Length];
                streame.Read(data, 0, data.Length);
                streame.Seek(0, SeekOrigin.Begin);
                FileStream fs = new FileStream(full, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(data);
                bw.Close();
                fs.Close();

                #endregion

                obj = new
                {
                    state = 1,
                    path = basePath + name,
                    name = name
                };
            }
            catch
            {
                obj = new
                {
                    state = 0,
                    path = "",
                    name = ""
                };
            }
            return Json(obj);
        }
    }
}