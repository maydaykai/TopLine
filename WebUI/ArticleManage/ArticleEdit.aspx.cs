using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APICloud;
using Bll;
using Common;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;

namespace WebUI.ArticleManage
{
    public partial class ArticleEdit : BasePage
    {
        private int _id;
        readonly ArticleBll _bll = new ArticleBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            _id = ConvertHelper.QueryString(Request, "id", 0);
            if (!IsPostBack)
            {
                InitChannel();
                trAudit.Visible = false;
                if (_id > 0)
                {
                    var model = _bll.GetModel(_id);
                    txtTitle.Value = model.Title;
                    selArticleType.Value = model.Type;
                    ControlHelper.SetChecked(ckbChannelList, model.ChannelID);
                    ckbChannelList.Enabled = false;
                    txtPubTime.Value = model.PubTime.ToString("yyyy-MM-dd HH:mm:ss");
                    txtContent.InnerHtml = model.Content;
                    ckbHot.Checked = model.IsHot;
                    ckbBot.Checked = model.IsBot;
                    trAudit.Visible = true;
                    switch (model.AuditStatus)
                    {
                        case 1: rdStatusY.Checked = true; break;
                        case 2: rdStatusN.Checked = true; break;
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
            try
            {
                var title = txtTitle.Value.Trim();
                var content = txtContent.Value.Trim();
                var channels = ControlHelper.GetCheckBoxList(ckbChannelList);
                if (string.IsNullOrEmpty(title))
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入文章标题','warning', '');", true);
                    return;
                }
                if (string.IsNullOrEmpty(txtPubTime.Value.Trim()))
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入发布时间','warning', '');", true);
                    return;
                }
                if (string.IsNullOrEmpty(txtContent.Value.Trim()))
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入文章正文','warning', '');", true);
                    return;
                }
                var model = new ArticleModel
                {
                    Title = title,
                    Content = Server.HtmlEncode(content),
                    ChannelID = channels,
                    Imgs = "",
                    IsHot = ckbHot.Checked,
                    IsBot = ckbBot.Checked,
                    Type = selArticleType.Value
                };
                if (_id > 0)
                {
                    model.ID = _id;
                    if (!rdStatusY.Checked && !rdStatusN.Checked)
                    {
                        ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请审核该文章','warning', '');",
                            true);
                        return;
                    }
                    var oldModel = _bll.GetModel(_id);

                    var srcPath = HtmlHelper.GetHtmlImageUrlList(content);
                    if (srcPath.Length > 0)
                    {
                        var uploadPath = DESStringHelper.EncryptString(_id.ToString());
                        var localPath = ImageHelper.GetSaveImgNames(srcPath, uploadPath, 2);
                        for (var i = 0; i < localPath.Length; i++)
                        {
                            model.Content = model.Content.Replace(srcPath[i], localPath[i]);
                            model.Imgs += localPath[i] + ",";
                        }
                        model.Imgs = model.Imgs.Substring(0, model.Imgs.Length - 1);
                    }


                    model.AuditRecord = oldModel.AuditRecord;
                    model.AuditStatus = rdStatusY.Checked ? 2 : 1;
                    if (!string.IsNullOrEmpty(model.AuditRecord))
                        model.AuditRecord += "|";
                    var userName = new UserBll().GetModel(MemberId).UserName;
                    var tipStr = new StringBuilder();
                    if (oldModel.AuditStatus == 0) //审核
                    {
                        model.AuditRecord += (rdStatusY.Checked ? "审核通过—" : "审核不通过") + userName + "—" +
                                             DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        if (!_bll.Update(model))
                        {
                            tipStr.Append("审核失败；");
                            ClientScript.RegisterClientScriptBlock(GetType(), "",
                                "MessageAlert('" + tipStr + "','error', '');", true);
                            return;
                        }
                        tipStr.Append("审核成功；");

                        var pushData = new
                        {
                            title,
                            content,
                            type = model.Type,
                            imgs = "",
                            rela_chan = channels,
                            is_hot = ckbHot.Checked ? "1" : "0",
                            is_bot = ckbBot.Checked ? "1" : "0",
                        };
                        var articleModel = DataConstructor.Factory("article");
                        var resultData = articleModel.Create(pushData);
                        var jObj = JObject.Parse(resultData);
                        if (jObj["id"] != null)
                        {
                            model.OID = jObj["id"].ToString();
                            model.Status = 3;
                            tipStr.Append("上传成功；");
                        }
                        else
                        {
                            model.OID = "";
                            model.Status = 2;
                            tipStr.Append("上传失败；");
                        }
                        _bll.Upload(model);
                        ClientScript.RegisterClientScriptBlock(GetType(), "",
                            jObj["id"] != null
                                ? "MessageAlert('" + tipStr +
                                  "','success', '/ArticleManage/ArticleManage.aspx?columnId=" +
                                  ColumnId + "');"
                                : "MessageAlert('" + tipStr + "','error', '');", true);
                        return;
                    }
                    model.AuditRecord += "修改成功—" + userName + "—" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "",
                        new ArticleBll().Add(model) > 0
                            ? "MessageAlert('添加成功','success', '/ArticleManage/ArticleManage.aspx?columnId=" + ColumnId +
                              "');"
                            : "MessageAlert('添加失败','error', '');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "",
                                "MessageAlert('服务器错误，请联系开发人员！','error', '');", true);
                Log4NetHelper.WriteError(ex);
            }
        }
    }
}