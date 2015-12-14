using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Bll;
using Common;

namespace WebUI.HanderAshx.Basic
{
    /// <summary>
    /// LoginMenuHandler 的摘要说明
    /// </summary>
    public class LoginMenuHandler : IHttpHandler, IRequiresSessionState
    {
        private string _role=string.Empty;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            context.Response.AddHeader("Pragma", "No-Cache");
            context.Response.ContentType = "text/plain";
            if (SessionHelper.Exists("Role"))
            {
                _role = SessionHelper.Get("Role").ToString();
            }

            context.Response.Write(!SessionHelper.Exists("UserId") ? "" : GetJsonStr());
        }

        //获取json字符串
        private string GetJsonStr()
        {
            var menuJosn = string.Empty;
            var dtMenu = new ColumnBll().GetDataTables(_role);
            if (dtMenu != null && dtMenu.Rows.Count > 0)
            {
                menuJosn = "{\"menus\": [" + GetTasksString(0, dtMenu) + "]}";
            }
            return menuJosn;
        }

        //DataTable转换Json字符串 
        private static string GetTasksString(int taskId, DataTable dt)
        {
            var rows = dt.Select("ParentID=" + taskId.ToString(CultureInfo.InvariantCulture));
            if (rows.Length == 0)
                return string.Empty;
            var str = new StringBuilder();
            var rowCount = 0;
            foreach (var row in rows)
            {
                rowCount++;
                str.Append("{");
                for (var i = 0; i < row.Table.Columns.Count; i++)
                {
                    if (i != 0) str.Append(",");
                    str.Append("\"" + row.Table.Columns[i].ColumnName + "\"");
                    str.Append(":\"");
                    str.Append(row[i]);
                    str.Append("\"");
                }
                str.Append(",\"menus\":[");
                str.Append(GetTasksString((int)row["menuid"], dt));
                str.Append("]");
                str.Append(rowCount == rows.Count() ? "}" : "},");
            }
            return str.ToString();
        }

        
        public DataRow[] SelectRows(DataTable dt, int pid)
        {
            return dt.Select(string.Format("ParentID = {0}", pid));
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