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
    public partial class VoteEdit : BasePage
    {
        private string _id;
        readonly Factory _voteModel = DataConstructor.Factory("vote");
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
                        txtTitle.Value = jObj["title"].ToString();
                        txtContent.InnerHtml = jObj["desc"].ToString();
                        imgCoverImg.Attributes["src"] = hiCoverImg.Value = jObj["img"].ToString();
                        txtBeginDate.Value = jObj["beginDate"].ToString();
                        txtEndDate.Value = jObj["endDate"].ToString();
                        ckbDisable.Checked = Convert.ToBoolean(jObj["status"]);
                    }
                }
            }
        }

        //
        protected void Btn_Click(object sender, EventArgs e)
        {
            var title = txtTitle.Value.Trim();
            var desc = txtContent.Value.Trim();
            var img = hiCoverImg.Value;
            var beginDate = txtBeginDate.Value;
            var endDate = txtEndDate.Value;
            if (string.IsNullOrEmpty(title))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入投票名称','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(img))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请选择封面图片','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(beginDate) || string.IsNullOrEmpty(endDate))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请选择有效期','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(desc))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入投票描述','warning', '');", true);
                return;
            }
            if (!string.IsNullOrEmpty(_id))
            {
                var pushData = new
                {
                    title,
                    img,
                    beginDate,
                    endDate,
                    desc,
                    status=ckbDisable.Checked,
                    updatedAt = DateTime.UtcNow
                };
                var resultData = _voteModel.Edit(_id, pushData);
                var jObj = JObject.Parse(resultData);
                ClientScript.RegisterClientScriptBlock(GetType(), "",
                    jObj != null
                        ? "MessageAlert('修改成功','success', '/VoteManage/VoteManage.aspx?columnId=" + ColumnId +
                          "');"
                        : "MessageAlert('修改失败','error', '');", true);

            }
            else
            {
                var pushData = new
                {
                    title,
                    img,
                    beginDate,
                    endDate,
                    desc,
                    status=ckbDisable.Checked
                };
                var resultData = _voteModel.Create(pushData);
                var jObj = JObject.Parse(resultData);
                ClientScript.RegisterClientScriptBlock(GetType(), "",
                                       jObj != null
                                           ? "MessageAlert('添加成功','success', '/VoteManage/VoteManage.aspx?columnId=" + ColumnId + "');"
                                           : "MessageAlert('添加失败','error', '');", true);
            }
        }
    }
}