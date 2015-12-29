using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using APICloud;
using Common;
using Model;
using Newtonsoft.Json;

namespace WebUI.HanderAshx.ArticleManage
{
    /// <summary>
    /// ChannelHandler 的摘要说明
    /// </summary>
    public class ChannelHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            context.Response.AddHeader("Pragma", "No-Cache");
            context.Response.ContentType = "text/json";
            context.Response.Write(GetFcmsUserList());
        }

        //获取数据
        public Object GetFcmsUserList()
        {
            var model = DataConstructor.Factory("channel");
            var data = model.Query();
            var list = JsonConvert.DeserializeObject<List<ChannelModel>>(data);
            var modelData = (from memberModel in list
                             select new
                             {
                                 ID = memberModel.id,
                                 Title = memberModel.title
                             });
            var jsonData = new
            {
                TotalRows = list.Count,//记录数
                Rows = modelData//实体列表
            };
            return JsonConvert.SerializeObject(jsonData);
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