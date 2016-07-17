using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APICloud;
using APICloud.Rest;
using Bll;
using Common;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using Model;
using Newtonsoft.Json.Linq;

namespace WebUI.ArticleManage
{
    public partial class UserArticleEdit : BasePage
    {
        private string _id;
        readonly Factory _model = DataConstructor.Factory("userArticle");
        protected void Page_Load(object sender, EventArgs e)
        {
            _id = ConvertHelper.QueryString(Request, "id", "");
            if (!string.IsNullOrEmpty(_id))
            {
                var resultData = _model.Get(_id);
                var jObj = JObject.Parse(resultData);
                if (jObj != null)
                {
                    txtTitle.Value = jObj["title"].ToString();
                    txtContent.Value = jObj["content"].ToString();
                    //if (ConvertHelper.ToInt(jObj["status"].ToString()) == 1)
                    //    rdStatusY.Checked = true;
                    //if (ConvertHelper.ToInt(jObj["status"].ToString()) == 2)
                    //    rdStatusN.Checked = true;
                }
            }
        }
        protected void Btn_Click(object sender, EventArgs e)
        {
            //var title = txtTitle.Value.Trim();
            //var content = txtContent.Value.Trim();

            //if (string.IsNullOrEmpty(title))
            //{
            //    ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入文章标题','warning', '');", true);
            //    return;
            //}
            //if (string.IsNullOrEmpty(content))
            //{
            //    ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入文章正文','warning', '');", true);
            //    return;
            //}
            //if (!string.IsNullOrEmpty(_id))
            //{
            //    var pushData = new
            //    {
            //        id = _id,
            //        title,
            //        content,
            //        status = rdStatusY.Checked ? 1 : 2,
            //        updatedAt = DateTime.UtcNow
            //    };
            //    if (!rdStatusY.Checked && !rdStatusN.Checked)
            //    {
            //        ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请审核该文章','warning', '');",
            //            true);
            //        return;
            //    }
            //    var resultData = _model.Edit(_id, pushData);
            //    var jObj = JObject.Parse(resultData);
            //    ClientScript.RegisterClientScriptBlock(GetType(), "",
            //        jObj["id"] != null
            //            ? "MessageAlert('审核成功','success', '/ArticleManage/UserArticleManage.aspx?columnId=" + ColumnId +
            //              "');"
            //            : "MessageAlert('审核失败','error', '');", true);
            //}
        }
    }
}