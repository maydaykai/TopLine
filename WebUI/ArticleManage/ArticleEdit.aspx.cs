using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APICloud;
using Bll;
using Common;
using Model;
using Newtonsoft.Json;

namespace WebUI.ArticleManage
{
    public partial class ArticleEdit : BasePage
    {
        private int _id;
        private int _columnId;
        protected void Page_Load(object sender, EventArgs e)
        {
            _id = ConvertHelper.QueryString(Request, "id", 0);
            _columnId = ConvertHelper.QueryString(Request, "columnId", 0);
            if (!IsPostBack)
            {
                InitChannel();
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
            StringBuilder strxml = new StringBuilder();
            var title = txtTitle.Value.Trim();
            var content = txtContent.Value.Trim();
            var channels = ckbChannelList.SelectedValue;
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
                Imgs = "",
                IsHot = ckbHot.Checked,
                IsBot = ckbBot.Checked,
                Type = selArticleType.Value
            };
            var id = new ArticleBll().Add(model);
            if (id > 0)
            {
                var pushData = new
                {
                    title,
                    content = Server.HtmlEncode(content),
                    imgs = "",
                    rela_chan = channels,
                    is_hot = ckbHot.Checked ? "1" : "0",
                    is_bot = ckbBot.Checked ? "1" : "0",
                };
                var articleModel = DataConstructor.Factory("article");
                var resultData = articleModel.Create(pushData);

            }
//            if (_columnId == 138)
//            {
//                //Convert.ToInt32(SelectMediaType.Value) <= 0
//                if (string.IsNullOrEmpty(SelectMediaType.Value))
//                {
//
//                    ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请先选择标题小类类别','warning', '');", true);
//                    return;
//                }
//                //上传图片
//                if (hiNewsImg_logo.Value.Length < 1)
//                {
//                    ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请上传媒体报道新闻的logo','warning', '');", true);
//                    return;
//                }
//                if (txt_Author.Value.Length < 1)
//                {
//                    ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入作者','warning', '');", true);
//                    return;
//                }
//                if (txt_Source.Value.Length < 1)
//                {
//                    ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请输入来源连接地址','warning', '');", true);
//                    return;
//                }
//                //作者跟来源
//
//
//                strxml.Append("<MediaTypeList><List");
//                strxml.Append(" SourceUrl=\"" + txt_Source.Value + "\" Author=\"" + txt_Author.Value + "\"  Source=\"" + hie_source.Value + "\">");
//                strxml.Append("</List> </MediaTypeList>");
//
//
//            }
//            //_columnId=媒体报道显示小类标题跟logo
//
//            var informationBll = new InformationBll();
//
//            //如果设为推荐
//            if (cbRecommend.Checked && _columnId == 138)
//            {
//                informationBll.UpdateAllStatus(_columnId);
//            }
//
//            if (_id > 0)
//            {
//
//                if (!rdStatusY.Checked && !rdStatusN.Checked)
//                {
//                    ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请审核该资讯','warning', '');", true);
//                    return;
//                }
//                var informationModel = informationBll.GetModel(_id);
//
//                //资讯图片
//                if (hiNewsImg.Value.Trim().Length > 0)
//                {
//                    informationModel.NewsImage = hiNewsImg.Value.Trim();
//
//                }
//                //
//                informationModel.url = "";
//                informationModel.ExtendedContent = strxml.ToString();
//                informationModel.PubTime = DateTime.Parse(txtPubTime.Value.Trim());
//                informationModel.Recommend = cbRecommend.Checked;
//                informationModel.SectionID = int.Parse(selSections.Value.Trim());
//                informationModel.Title = txtTitle.Value.Trim();
//                informationModel.Content = Server.HtmlEncode(txtContent.Value);
//                informationModel.UpdateTime = DateTime.Now;
//
//                informationModel.Image_value = Convert.ToInt32(hie_Image_value.Value.Length > 0 ? hie_Image_value.Value : "0");
//                informationModel.SummaryCount = txt_SummaryCount.Value;
//                if (!string.IsNullOrEmpty(SelectMediaType.Value))
//                {
//                    informationModel.MediaTypeId = Convert.ToInt32(SelectMediaType.Value);
//                }
//                else
//                {
//                    informationModel.MediaTypeId = 0;
//                }
//                int relust = 0;
//                if (int.TryParse(txt_ShowDesc.Value, out relust))
//                {
//                    informationModel.ShowDesc = Convert.ToInt32(txt_ShowDesc.Value);
//                }
//                else
//                {
//                    informationModel.ShowDesc = 0;
//                }
//
//                int status = 0;
//                if (rdStatusY.Checked) status = 1;
//                else if (rdStatusN.Checked) status = 2;
//                else status = 0;
//                informationModel.Status = status;
//                ClientScript.RegisterClientScriptBlock(GetType(), "",
//                                     informationBll.Update(informationModel)
//                                         ? "MessageAlert('修改成功','success', '/Information/InformationManage.aspx?columnId=" + ColumnId + "');"
//                                         : "MessageAlert('修改失败','error', '');", true);
//                // 数据推送
//                if (informationModel.Status == 1 && informationModel.SectionID == 32)
//                {
//                    var content = HtmlHelper.DeleteHtml(txtContent.Value);
//                    new MobilePushBll().Add(new MobilePushModel { CreateTime = informationModel.PubTime, EventID = informationModel.ID, MessageType = 1, PushContent = content.Length >= 50 ? content.Substring(0, 51) : content, PushStatus = false, PushTitle = informationModel.Title, UpdateTime = DateTime.Now });
//                }
//            }
//            else
//            {
//                int relust = 0;
//                if (int.TryParse(txt_ShowDesc.Value, out relust))
//                {
//                    relust = Convert.ToInt32(txt_ShowDesc.Value);
//                }
//
//                int SelectMediaTypeId = 0;
//                int Image_value = 0;
//                if (!string.IsNullOrEmpty(SelectMediaType.Value))
//                {
//                    SelectMediaTypeId = Convert.ToInt32(SelectMediaType.Value);
//                }
//                if (!string.IsNullOrEmpty(hie_Image_value.Value))
//                {
//                    Image_value = Convert.ToInt32(hie_Image_value.Value);
//                }
//
//                var informationModel = new InformationModel
//                {
//                    Content = HtmlHelper.ReplaceHtml(txtContent.Value.Trim()),
//                    SummaryCount = txt_SummaryCount.Value,
//                    NewsImage = hiNewsImg.Value.Trim(),
//                    PubTime = DateTime.Parse(txtPubTime.Value.Trim()),
//                    Recommend = cbRecommend.Checked,
//                    SectionID = int.Parse(selSections.Value),
//                    Status = 0,
//                    ShowDesc = relust,
//                    Title = txtTitle.Value.Trim(),
//                    MediaTypeId = SelectMediaTypeId,
//                    Image_value = Image_value,
//                    UpdateTime = DateTime.Now,
//                    url = "",
//                    ExtendedContent = strxml.ToString()
//                };
//                ClientScript.RegisterClientScriptBlock(GetType(), "",
//                                      informationBll.Add(informationModel) > 0
//                                          ? "MessageAlert('添加成功','success', '/Information/InformationManage.aspx?columnId=" + ColumnId + "');"
//                                          : "MessageAlert('添加失败','error', '');", true);
//            }
        }
    }
}