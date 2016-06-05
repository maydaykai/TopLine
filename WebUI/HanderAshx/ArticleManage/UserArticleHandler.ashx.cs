using APICloud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Bll;
using Common;
using Model;
using Newtonsoft.Json;

namespace WebUI.HanderAshx.ArticleManage
{
    /// <summary>
    /// UserArticleHandler 的摘要说明
    /// </summary>
    public class UserArticleHandler : IHttpHandler
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
            var sortColumn = _sortField + " " + _sort;
            var filter = "{\"limit\": " + _pageSize + ", \"order\": \"" + sortColumn + "\"";
            if (_currentPage > 0)
                filter += ",\"skip\":" + _currentPage;
            filter += "}";
            context.Response.Write(GetDataList(filter));
        }

        //获取数据
        public Object GetDataList(string filter)
        {
            var factory = DataConstructor.Factory("userArticle");
            var data = factory.Query(filter);
            var count = factory.Count();
            var list = JsonConvert.DeserializeObject<List<UserArticleModel>>(data);
            var modelData = (from model in list
                             select new
                             {
                                 ID = model.id,
                                 Title = model.title,
                                 Content =
                        HtmlHelper.DeleteHtml(HttpContext.Current.Server.HtmlDecode(model.content))
                            .GetSubString(0, 36),
                                 Status = model.status,
                                 CreateTime = model.createdAt
                             });
            var jsonData = new
            {
                TotalRows = JsonConvert.DeserializeObject<Dictionary<string, int>>(count)["count"],//记录数
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