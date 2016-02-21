using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using APICloud;
using Bll;
using Common;
using Model;
using Newtonsoft.Json;

namespace WebUI.HanderAshx.ArticleManage
{
    /// <summary>
    /// ArticleHandler 的摘要说明
    /// </summary>
    public class ArticleHandler : IHttpHandler
    {
        private int _currentPage = 1;
        private int _pageSize;
        private string _sort = "asc";
        private string _sortField = "ID";
        private string _uName = "";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            context.Response.AddHeader("Pragma", "No-Cache");
            context.Response.ContentType = "text/json";
            _currentPage = ConvertHelper.QueryString(context.Request, "pagenum", 1);
            _pageSize = ConvertHelper.QueryString(context.Request, "pagesize", 0);
            _sort = ConvertHelper.QueryString(context.Request, "sortOrder", "desc");
            _sortField = ConvertHelper.QueryString(context.Request, "sortdatafield", "id");
            _uName = ConvertHelper.QueryString(context.Request, "uname", "");
            var filter = " [Status]<4 ";
            if (!string.IsNullOrEmpty(_uName) && _uName != "undefined")
            {
                filter += " and UserName like '%" + _uName + "%'";
            }
            var sortColumn = _sortField + " " + _sort;
            context.Response.Write(GetDataList(_currentPage, _pageSize, sortColumn, filter));
        }

        //获取数据
        public Object GetDataList(int pagenum, int pagesize, string sortField, string filter)
        {
            pagenum += 1;

            var pageCount = 0;
            var dt = new ArticleBll().GetList(filter, sortField, pagenum, pagesize, ref pageCount);
            if (dt == null) return JsonConvert.SerializeObject(new { TotalRows = 0, Rows = new string[] { } });
            var channelModel = DataConstructor.Factory("channel");
            var channelData = channelModel.Query();
            var channelList = JsonConvert.DeserializeObject<List<ChannelModel>>(channelData);
            var modelData = (from DataRow dr in dt.Rows
                select new
                {
                    ID = dr["ID"],
                    OID = dr["OID"],
                    Title = dr["Title"],
                    Content =
                        HtmlHelper.DeleteHtml(HttpContext.Current.Server.HtmlDecode(dr["Content"].ToString()))
                            .GetSubString(0, 36),
                    ChannelName = GetChannelsName(channelList, dr["ChannelID"].ToString().Split(',')),
                    IsHot = dr["IsHot"],
                    IsBot = dr["IsBot"],
                    Type = dr["Type"]
                });
            var jsonData = new
            {
                TotalRows = pageCount,//记录数
                Rows = modelData//实体列表
            };
            return JsonConvert.SerializeObject(jsonData);
        }
        private string GetChannelsName(List<ChannelModel> channelList, string[] channels)
        {
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}