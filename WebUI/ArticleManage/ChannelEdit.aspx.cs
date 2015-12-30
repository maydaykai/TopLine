using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APICloud;
using APICloud.Rest;
using Bll;
using Common;
using Model;
using Newtonsoft.Json.Linq;

namespace WebUI.ArticleManage
{
    public partial class ChannelEdit : BasePage
    {
        private string _id;
        Factory channelModel = DataConstructor.Factory("channel");
        protected void Page_Load(object sender, EventArgs e)
        {
            _id = ConvertHelper.QueryString(Request, "id", "");
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(_id))
                {
                    var resultData = channelModel.Get(_id);
                    var jObj = JObject.Parse(resultData);
                    if (jObj != null)
                    {
                        txtChannelName.Value = jObj["title"].ToString();
                    }
                }
            }
        }

        //
        protected void Operate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChannelName.Value.Trim()))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlertChild('请输入频道名称','warning', '');", true);
                return;
            }

            if (!string.IsNullOrEmpty(_id))
            {
                var pushData = new
                {
                    title = txtChannelName.Value.Trim(),
                    updatedAt = DateTime.UtcNow
                };
                var resultData = channelModel.Edit(_id, pushData);
                var jObj = JObject.Parse(resultData);
                ClientScript.RegisterClientScriptBlock(GetType(), "",
                    jObj != null
                        ? "MessageAlertChild('修改成功','success', '/ArticleManage/ChannelManage.aspx?columnId=" + ColumnId +
                          "');"
                        : "MessageAlertChild('修改失败','error', '');", true);

            }
            else
            {
                var pushData = new
                {
                    title = txtChannelName.Value.Trim(),
                };
                var resultData = channelModel.Create(pushData);
                var jObj = JObject.Parse(resultData);
                ClientScript.RegisterClientScriptBlock(GetType(), "",
                                       jObj != null
                                           ? "MessageAlertChild('添加成功','success', '/ArticleManage/ChannelManage.aspx?columnId=" + ColumnId + "');"
                                           : "MessageAlertChild('添加失败','error', '');", true);
            }
        }
    }
}