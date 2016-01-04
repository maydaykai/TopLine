using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APICloud;
using Model;
using Newtonsoft.Json;

namespace WebUI.HanderAshx.AdvertManage
{
    /// <summary>
    /// AdvertHandler 的摘要说明
    /// </summary>
    public class AdvertHandler : IHttpHandler
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
            var model = DataConstructor.Factory("advert");
            var data = model.Query();
            var list = JsonConvert.DeserializeObject<List<AdvertModel>>(data);
            var modelData = (from advertModel in list
                             select new
                             {
                                 ID = advertModel.id,
                                 Title = advertModel.title,
                                 Img = advertModel.img,
                                 LinkUrl = advertModel.linkUrl,
                                 ChannelName = advertModel.channelModel.title,
                                 StatusStr = advertModel.statusStr
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