using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            if (list.Count == 0) return JsonConvert.SerializeObject(new { TotalRows = 0, Rows = new string[] { } });
            var channelModel = DataConstructor.Factory("channel");
            var channelData = channelModel.Query();
            var channelList = JsonConvert.DeserializeObject<List<ChannelModel>>(channelData);
            var modelData = (from advertModel in list
                             select new
                                 {
                                     ID = advertModel.id,
                                     Title = advertModel.title,
                                     Img = advertModel.img,
                                     LinkUrl = advertModel.linkUrl,
                                     ChannelName = GetChannelsName(channelList, advertModel.channels),
                                     StatusStr = advertModel.statusStr
                                 });
            var jsonData = new
                {
                    TotalRows = list.Count, //记录数
                    Rows = modelData //实体列表
                };
            return JsonConvert.SerializeObject(jsonData);
        }
        private string GetChannelsName(List<ChannelModel> channelList, string channels)
        {
            var str = new StringBuilder();
            if (string.IsNullOrEmpty(channels)) return "";
            foreach (var model in channelList)
            {
                if (channels.IndexOf(model.id) != -1)
                {
                    str.Append(model.title + ",");
                }
            }
            return str.Remove(str.Length - 1, 1).ToString();
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