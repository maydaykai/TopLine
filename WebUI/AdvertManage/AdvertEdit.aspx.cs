using System;
using System.Collections.Generic;
using APICloud;
using APICloud.Rest;
using Common;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebUI.AdvertManage
{
    public partial class AdvertEdit : BasePage
    {
        private string _id;
        readonly Factory _model = DataConstructor.Factory("advert");
        protected void Page_Load(object sender, EventArgs e)
        {
            _id = ConvertHelper.QueryString(Request, "id", "");
            if (!IsPostBack)
            {
                InitChannel();
                if (!string.IsNullOrEmpty(_id))
                {
                    var resultData = _model.Get(_id);
                    var jObj = JObject.Parse(resultData);
                    if (jObj != null)
                    {
                        txtTitle.Value = jObj["title"].ToString();
                        txtLinkUrl.Value = jObj["linkUrl"].ToString();
                        imgAdvertImg.Attributes["src"] = ConfigHelper.ImgVirtualPath + jObj["img"];
                        hiAdvertImg.Value = jObj["img"].ToString();
                        ControlHelper.SetChecked(ckbChannelList, string.Join(",",jObj["channels"]), ",");
                        txtLineNumber.Value = jObj["lineNumber"].ToString();
                        ckbEnable.Checked = Convert.ToBoolean(jObj["status"]);
                    }
                }
            }
        }
        private void InitChannel()
        {
            var model = DataConstructor.Factory("channel");
            var data = model.Query();
            var list = JsonConvert.DeserializeObject<List<ChannelModel>>(data);
            ckbChannelList.DataSource = list;
            ckbChannelList.DataValueField = "id";
            ckbChannelList.DataTextField = "title";
            ckbChannelList.DataBind();
        }
        protected void Btn_Click(object sender, EventArgs e)
        {
            var title = txtTitle.Value.Trim();
            var img = hiAdvertImg.Value.Trim();
            var linkUrl = txtLinkUrl.Value.Trim();
            var channels = ControlHelper.GetCheckBoxList(ckbChannelList,",");
            var lineNumber = txtLineNumber.Value.Trim();
            var status = ckbEnable.Checked;
            if (string.IsNullOrEmpty(title))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入标题','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(img))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请上传图片','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(linkUrl))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入链接','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(channels))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请选择频道','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(lineNumber))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入队列序号','warning', '');", true);
                return;
            }

            if (!string.IsNullOrEmpty(_id))
            {
                var pushData = new
                {
                    title,
                    img,
                    linkUrl,
                    channels = channels.Split(','),
                    lineNumber,
                    status,
                    updatedAt = DateTime.UtcNow
                };
                var resultData = _model.Edit(_id, pushData);
                var jObj = JObject.Parse(resultData);
                ClientScript.RegisterClientScriptBlock(GetType(), "",
                    jObj != null && jObj["id"] != null
                        ? "MessageAlert('修改成功','success', '/AdvertManage/AdvertManage.aspx?columnId=" + ColumnId +
                          "');"
                        : "MessageAlert('修改失败','error', '');", true);

            }
            else
            {
                var pushData = new
                {
                    title,
                    img,
                    linkUrl,
                    channels = channels.Split(','),
                    lineNumber,
                    status
                };
                var resultData = _model.Create(pushData);
                var jObj = JObject.Parse(resultData);
                ClientScript.RegisterClientScriptBlock(GetType(), "",
                                       jObj != null && jObj["id"] != null
                                           ? "MessageAlert('添加成功','success', '/AdvertManage/AdvertManage.aspx?columnId=" + ColumnId + "');"
                                           : "MessageAlert('添加失败','error', '');", true);
            }
        }
    }
}