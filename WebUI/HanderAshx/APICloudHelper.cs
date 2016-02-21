using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using APICloud;
using Model;
using Newtonsoft.Json;

namespace WebUI.HanderAshx
{
    public class APICloudHelper
    {
        public static string GetChannelsName(string[] channels)
        {
            var channelModel = DataConstructor.Factory("channel");
            var channelData = channelModel.Query();
            var channelList = JsonConvert.DeserializeObject<List<ChannelModel>>(channelData);
            var str = new StringBuilder();
            if (channels.Length == 0) return "";
            foreach (var model in channelList)
            {
                if (string.Join(",", channels).IndexOf(model.id) != -1)
                {
                    str.Append(model.title + ",");
                }
            }
            return str.Remove(str.Length - 1, 1).ToString();
        }
    }
}