﻿using System;
using System.Data;
using System.Web;
using Bll;
using Common;

namespace WebUI.HanderAshx.Basic
{
    /// <summary>
    /// ColumnHander 的摘要说明
    /// </summary>
    public class ColumnHander : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            context.Response.AddHeader("Pragma", "No-Cache");
            context.Response.ContentType = "text/json";
            context.Response.Write(GetJson());
        }


        private Object GetJson()
        {
            var s = JsonHelper.DataTableToJson(DataSetProcess());
            return s;
        }


        private DataTable DataSetProcess()
        {
            var columnBll = new ColumnBll();
            var dataSet = columnBll.GetColumnlList("ID,Name,ParentID",0);
            var dt = dataSet.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                dt = Modfiy(dt);
            }
            return dt;
        }


        private static DataTable GetTree(DataTable sdt, DataTable pdt, int id, int level)
        {
            const string @join = "<img src=\"../images/join.gif\" border=\"0\" style=\"float:left;\"/>";
            const string joinBottom = "<img src=\"../images/joinbottom.gif\"  style=\"float:left;\" border=\"0\"/>";
            string prefix = join;
            string prefixend = joinBottom;//最后一个
            for (int i = 0; i < level - 1; i++)
            {
                prefix = join + prefix;
                prefixend = joinBottom + prefixend;
            }

            DataRow[] rows = sdt.Select("ParentID = " + id.ToString());
            int countnum = 1;
            foreach (DataRow erow in rows)
            {
                DataRow nrow = pdt.NewRow();
                nrow.ItemArray = erow.ItemArray;
                int i;
                Int32.TryParse(erow["ID"].ToString(), out i);
                if (countnum == rows.Length)
                {
                    DataRow[] lastrows = sdt.Select("ParentID = " + erow["ID"].ToString());
                    if (lastrows.Length <= 0)
                    {
                        nrow["Name"] = prefixend + nrow["Name"];
                    }
                    else
                    {
                        nrow["Name"] = prefix + nrow["Name"];
                    }
                }
                else
                {
                    nrow["Name"] = prefix + nrow["Name"];
                }
                pdt.Rows.Add(nrow);
                countnum++;
                GetTree(sdt, pdt, i, level + 1);
            }
            return pdt;
        }


        private DataTable Modfiy(DataTable dt)
        {
            if ((dt == null) || (dt.Rows.Count < 1))
                return dt;
            DataTable dtn = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                if (row["ParentID"].ToString().Equals("0"))
                {
                    row["Name"] = "<img src=\"../images/plus.gif\" style=\"float:left;\" border=\"0\"/><strong>" + row["Name"] + "</strong>";
                    DataRow nrow = dtn.NewRow();
                    nrow.ItemArray = row.ItemArray;
                    dtn.Rows.Add(nrow);
                    int i = -1;
                    Int32.TryParse(row["ID"].ToString(), out i);
                    GetTree(dt, dtn, i, 1);
                }
            }
            dtn.Columns.Add("imgStr", Type.GetType("System.String"));
            foreach (DataRow row in dtn.Rows)
            {
                int i = -1;
                Int32.TryParse(row["ID"].ToString(), out i);
                DataRow[] rows = dt.Select("ParentID = " + i.ToString());
                if (rows.Length > 0)
                {
                    row["imgStr"] = "<img src=\"../images/plus.gif\"  style=\"float:left;\" border=\"0\"/>";
                }
                else
                {
                    row["imgStr"] = "";
                }
            }
            return dtn;
        }

        public bool IsReusable
        {
            get { return false; }
        }

    }
}