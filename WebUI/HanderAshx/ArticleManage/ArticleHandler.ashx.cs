using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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
            var filter = " 1=1";
            if (!string.IsNullOrEmpty(_uName) && _uName != "undefined")
            {
                filter += " and UserName like '%" + _uName + "%'";
            }
            var sortColumn = _sortField + " " + _sort;
            context.Response.Write(GetFcmsUserList(_currentPage, _pageSize, sortColumn, filter));

        }

        //获取数据
        public Object GetFcmsUserList(int pagenum, int pagesize, string sortField, string filter)
        {
            pagenum += 1;

            int pageCount = 0;
            var dt = new ArticleBll().GetList("", sortField, pagenum, pagesize, ref pageCount);
            var modelData = (from DataRow dr in dt.Rows
                             select new
                              {
                                  ID=dr["ID"],
                                  Title = dr["Title"],
                                  Content = HtmlHelper.DeleteHtml(HttpContext.Current.Server.HtmlDecode(dr["Content"].ToString())).GetSubString(0,36),
                                  IsHot = dr["IsHot"],
                                  IsBot = dr["ID"],
                                  Type = dr["Type"]
                              });
            var jsonData = new
            {
                TotalRows = pageCount,//记录数
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