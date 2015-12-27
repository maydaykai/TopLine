using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ImageHelper
    {
        /// <summary>
        /// 上传图片至本地服务器 返回1：物理；2：网络路径
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="uploadPath"></param>
        /// <param name="pathType"></param>
        /// <returns></returns>
        public static string[] GetSaveImgNames(string[] srcPath,string uploadPath, int pathType)
        {
            var returnPhysicalPath = new string[srcPath.Length];
            var returnVirtualPath = new string[srcPath.Length];
            for (var i = 0; i < srcPath.Length; i++)
            {
                var wc = new WebClient();
                returnPhysicalPath[i] = ConfigHelper.ImgPhysicallPath + uploadPath + "/" + Path.GetFileName(srcPath[i]);
                returnVirtualPath[i] = ConfigHelper.ImgVirtualPath + uploadPath + "/" + Path.GetFileName(srcPath[i]);
                if (!Directory.Exists(ConfigHelper.ImgPhysicallPath + uploadPath))
                {
                    Directory.CreateDirectory(ConfigHelper.ImgPhysicallPath + uploadPath);
                }
                wc.DownloadFile(srcPath[i], returnPhysicalPath[i]);
            }
            return pathType == 1 ? returnPhysicalPath : returnVirtualPath;
        }
    }
}
