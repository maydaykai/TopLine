using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using LitJson;

namespace WebUI.API
{
    /// <summary>
    /// upload 的摘要说明
    /// </summary>
    public class Upload : IHttpHandler
    {
        private HttpContext context;
        public void ProcessRequest(HttpContext context)
        {
            //文件保存目录路径
            String savePath = Common.ConfigHelper.ImgPhysicallPath;

            //文件保存目录URL
            String saveUrl = Common.ConfigHelper.ImgVirtualPath;

            //定义允许上传的文件扩展名
            var extTable = new Hashtable { { "image", "gif,jpg,jpeg,png,bmp" } };

            //最大文件大小
            const int maxSize = 1000000 * 5;
            this.context = context;
            String dirPath = savePath;
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            const string dirName = "image";
            if (!extTable.ContainsKey(dirName))
            {
                showError("目录名不正确。");
            }

            var ret = new result<string>();
            var fileName = new List<string> {" Count : " + context.Request.Files.Count};

            if (context.Request.Files.Count > 0)
            {
                try
                {
                    for (int i = 0; i < context.Request.Files.Count; i++)
                    {
                        var imgFile = context.Request.Files[i];
                        var fileExt = Path.GetExtension(imgFile.FileName).ToLower();
                        if (imgFile.InputStream.Length > maxSize)
                        {
                            showError("上传文件大小超过限制。");
                        }

                        if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
                        {
                            showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
                        }
                        string saveName = Guid.NewGuid() + fileExt;
                        imgFile.SaveAs(dirPath + saveName);
                        fileName.Add(saveUrl + saveName);
                    }
                    ret.code = "200";
                }
                catch
                {
                    ret.code = "500";
                }
            }
            ret.data = fileName;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(JsonMapper.ToJson(ret));
            context.Response.End();
        }
        private void showError(string message)
        {
            var ret = new result<string> {code = "404"};
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(JsonMapper.ToJson(ret));
            context.Response.End();
        }
        public class result<T>
        {
            public string code { get; set; }
            public string des
            {
                get
                {
                    return "200 : 上传成功 , 404 : 上传文件未找到 , 500 : 上传文件失败";
                }
            }
            public List<T> data { get; set; }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}