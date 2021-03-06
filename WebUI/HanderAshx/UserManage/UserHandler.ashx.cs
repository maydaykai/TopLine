﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using Bll;
using Model;
using System.Data;
using System.Text;
using Newtonsoft.Json;

namespace WebUI.HanderAshx.UserManage
{
    /// <summary>
    /// HandlerTest 的摘要说明
    /// </summary>
    public class HandlerTest : IHttpHandler
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
            pagenum = pagenum + 1;

            int pageCount = 0;
            var userbll = new UserBll();
            DataSet dsRoles = new RoleBll().GetRoleList();
            IList<UserModel> fcmsUserModelList = userbll.GetUserList(filter, sortField, pagenum, pagesize, ref pageCount);
            var orders = (from fcmsUserModel in fcmsUserModelList
                          select new
                          {
                              ID=fcmsUserModel.ID,
                              UserName=fcmsUserModel.UserName,
                              RealName=fcmsUserModel.RealName,
                              AnotherName=fcmsUserModel.AnotherName,
                              Mobile=fcmsUserModel.Mobile,
                              RegTime=fcmsUserModel.RegTime,
                              LastLoginTime=fcmsUserModel.LastLoginTime,
                              IsLock=fcmsUserModel.IsLock,
                              UpdateTime=fcmsUserModel.UpdateTime,
                              RoleId=GetRoleName(dsRoles,fcmsUserModel.RoleId)
                          });
            var jsonData = new
            {
                TotalRows = pageCount,//记录数
                Rows = orders//实体列表
            };
            var s = JsonHelper.ObjectToJson(jsonData);
            return JsonConvert.SerializeObject(jsonData); ;
        }

        private string GetRoleName(DataSet dsRoles, string roleId)
        {
            string[] tempArray = roleId.Split(',');
            StringBuilder sb = new StringBuilder();
            foreach (var temp in tempArray)
            {
                foreach (DataRow dr in dsRoles.Tables[0].Rows)
                {
                    if (dr["ID"].ToString() == temp)
                    {
                        sb.Append(dr["Name"].ToString()).Append(",");
                        break;
                    }
                }
            }
            return sb.ToString().TrimEnd(',');
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