using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APICloud;
using Model;
using Newtonsoft.Json;

namespace WebUI.HanderAshx.VoteManage
{
    /// <summary>
    /// VoteHandler 的摘要说明
    /// </summary>
    public class VoteHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            context.Response.AddHeader("Pragma", "No-Cache");
            context.Response.ContentType = "text/json";
            context.Response.Write(GetDataList());
        }

        //获取数据
        public Object GetDataList()
        {
            var model = DataConstructor.Factory("vote");
            var data = model.Query();
            var list = JsonConvert.DeserializeObject<List<VoteModel>>(data);
            var modelData = (from voteModel in list
                             select new
                             {
                                 ID = voteModel.id,
                                 Title = voteModel.title
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