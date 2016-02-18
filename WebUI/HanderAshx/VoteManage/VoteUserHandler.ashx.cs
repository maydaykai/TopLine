using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APICloud;
using Common;
using Model;
using Newtonsoft.Json;

namespace WebUI.HanderAshx.VoteManage
{
    /// <summary>
    /// VoteUserHandler 的摘要说明
    /// </summary>
    public class VoteUserHandler : IHttpHandler
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
                filter += ",\"skip\":" + _currentPage * _pageSize;
            if (!string.IsNullOrEmpty(_uName) && _uName != "undefined")
            {
                //filter += " and UserName like '%" + _uName + "%'";
            }
            filter += "}";
            context.Response.Write(GetDataList(filter));
        }

        //获取数据
        public Object GetDataList(string filter)
        {
            var model = DataConstructor.Factory("voteUser");
            var data = model.Query(filter);
            var list = JsonConvert.DeserializeObject<List<VoteUserModel>>(data);
            if (list.Count == 0) return JsonConvert.SerializeObject(new { TotalRows = 0, Rows = new string[] { } });
            var modelData = (from voteUserModel in list
                             select new
                             {
                                 ID = voteUserModel.id,
                                 UserName = voteUserModel.username,
                                 CreateTime = voteUserModel.createdAt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")
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