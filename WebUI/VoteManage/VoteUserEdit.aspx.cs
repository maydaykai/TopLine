using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APICloud;
using APICloud.Rest;
using Common;
using Newtonsoft.Json.Linq;

namespace WebUI.VoteManage
{
    public partial class VoteUserEdit : BasePage
    {
        private string _id;
        readonly Factory _voteModel = DataConstructor.Factory("voteUser");
        protected void Page_Load(object sender, EventArgs e)
        {
            _id = ConvertHelper.QueryString(Request, "id", "");
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(_id))
                {
                    var resultData = _voteModel.Get(_id);
                    var jObj = JObject.Parse(resultData);
                    if (jObj != null)
                    {
                        txtNickName.Value = jObj["nickName"].ToString();
                        hiCoverImg.Value = jObj["imgs"].ToString();
                        var imgs = jObj["imgs"].ToString().Split(',');
                        var ht = imgs.Aggregate("", (current, img) => current + ("<img class=\"fl imgS\" src=\"" + img + "\" style=\"margin: 3px 3px 6px 0px; display: inline-block;\" />"));
                        imgCoverImg.InnerHtml = ht;
                        txtContent.Value = jObj["desc"].ToString();
                        selCurrStatus.Value = jObj["status"].ToString();
                        if (Convert.ToInt32(jObj["status"]) == 0)
                        {
                            AuditStatus_TR.Visible = true;
                        }
                    }
                }
            }
        }
        protected void Btn_Click(object sender, EventArgs e)
        {
            var nickName = txtNickName.Value.Trim();
            var desc = txtContent.Value.Trim();
            var imgs = hiCoverImg.Value;
            string auditStatus = Request.Form["AuditStatus"];
            if (string.IsNullOrEmpty(nickName))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入报名名称','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(imgs))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请选择封面图片','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(desc))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入报名描述','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(auditStatus))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请选择审核状态。','warning', '');", true);
                return;
            }
            if (!string.IsNullOrEmpty(_id))
            {
                var pushData = new
                {
                    nickName,
                    imgs,
                    desc,
                    status = auditStatus,
                    updatedAt = DateTime.UtcNow
                };
                var resultData = _voteModel.Edit(_id, pushData);
                var jObj = JObject.Parse(resultData);
                ClientScript.RegisterClientScriptBlock(GetType(), "",
                    jObj != null
                        ? "MessageAlert('修改成功','success', '/VoteManage/VoteUserManage.aspx?columnId=" + ColumnId +
                          "');"
                        : "MessageAlert('修改失败','error', '');", true);

            }
        }
    }
}