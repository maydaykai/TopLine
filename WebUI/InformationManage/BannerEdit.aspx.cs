using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Common;
using Model;

namespace WebUI.InformationManage
{
    public partial class BannerEdit : BasePage
    {
        public int _id,_type;
        protected void Page_Load(object sender, EventArgs e)
        {
            _id = ConvertHelper.QueryString(Request, "id", 0);
            _type = ConvertHelper.QueryString(Request, "type", 0);
            //XmlHelper xmlHelper = new XmlHelper(Server.MapPath("~/Config/upload.xml"));
            //string remoteDomain = xmlHelper.GetText("upload/remoteDomain");
            //string secLevelDomain = xmlHelper.GetText("upload/secLevelDomain");
            //string imgFullDir = EndUrlDir(remoteDomain);
            //imgFullDir += EndUrlDir(secLevelDomain);
            //imgFullDir += "image/";

            string imgFullDir = ConfigHelper.ImgVirtualPath;

            if (!IsPostBack)
            {
                if (_id > 0)
                {
                    var bannerBll = new BannerBll();
                    var focusFigureModel = bannerBll.GetModel(_id);
                    if (!string.IsNullOrEmpty(focusFigureModel.LargePicture))
                    {
                        imgLargePic.Src = imgFullDir + focusFigureModel.LargePicture;
                        hiLargePic.Value = focusFigureModel.LargePicture;
                    }
                    else
                    {
                        imgLargePic.Src = "../images/nonepic_l.jpg";
                    }
                    if (!string.IsNullOrEmpty(focusFigureModel.SmallPicture))
                    {
                        imgSmallPic.Src = imgFullDir + focusFigureModel.SmallPicture;
                        hiSmallPic.Value = focusFigureModel.SmallPicture;
                    }
                    else
                    {
                        imgSmallPic.Src = "../images/nonepic_s.jpg";
                    }
                    if (!string.IsNullOrEmpty(focusFigureModel.Url))
                    {
                        txtUrl.Value = focusFigureModel.Url;
                    }
                    switch (focusFigureModel.Status)
                    {
                        case 0: rdStatusN.Checked = true; break;
                        case 1: rdStatusY.Checked = true; break;
                    }
                    trAudit.Style["display"] = "table-row";
                    if (!string.IsNullOrEmpty(focusFigureModel.Title))
                    {
                        txtTitle.Value = focusFigureModel.Title;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(hiSmallPic.Value))
                {
                    imgSmallPic.Src = imgFullDir + hiSmallPic.Value;
                }
                if (!string.IsNullOrEmpty(hiLargePic.Value))
                {
                    imgLargePic.Src = imgFullDir + hiLargePic.Value;
                }
            }
        }

        protected void btnSave1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hiLargePic.Value.Trim()))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请上传网页端焦点图','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(hiSmallPic.Value.Trim()))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请上传手机端焦点图','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(txtUrl.Value.Trim()))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请填写链接地址','warning', '');", true);
                return;
            }
            if (string.IsNullOrEmpty(txtTitle.Value.Trim()))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请填写焦点图标题','warning', '');", true);
                return;
            }

            var bannerBll = new BannerBll();
            if (_id > 0)
            {
                if (!rdStatusY.Checked && !rdStatusN.Checked)
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('请选择焦点图状态','warning', '');", true);
                    return;
                }
                var focusFigureModel = bannerBll.GetModel(_id);
                focusFigureModel.LargePicture = hiLargePic.Value.Trim();
                focusFigureModel.SmallPicture = hiSmallPic.Value.Trim();
                focusFigureModel.Url = txtUrl.Value.Trim();
                focusFigureModel.UpdateTime = DateTime.Now;
                focusFigureModel.Title = txtTitle.Value.Trim();
                int status = 0;
                if (rdStatusY.Checked)
                {
                    status = 1;
                }
                focusFigureModel.Status = status;
                ClientScript.RegisterClientScriptBlock(GetType(), "",
                                     bannerBll.Update(focusFigureModel)
                                         ? "MessageAlert('修改成功','success', '/InformationManage/BannerManage.aspx?columnId=" + ColumnId + "&type="+ _type + "');"
                                         : "MessageAlert('修改失败','error', '');", true);
            }
            else
            {
                var focusFigureModel = new BannerModel
                {
                    CreateTime = DateTime.Now,
                    LargePicture = hiLargePic.Value.Trim(),
                    SmallPicture = hiSmallPic.Value.Trim(),
                    Status = 1,
                    UpdateTime = DateTime.Now,
                    Url = txtUrl.Value.Trim(),
                    Title = txtTitle.Value.Trim()
                };
                ClientScript.RegisterClientScriptBlock(GetType(), "",
                                     bannerBll.Add(focusFigureModel) > 0
                                         ? "MessageAlert('添加成功','success', '/InformationManage/BannerManage.aspx?columnId=" + ColumnId + "&type=" + _type + "');"
                                         : "MessageAlert('添加失败','error', '');", true);
            }
        }

        private string EndUrlDir(string url)
        {
            if (!url.EndsWith("/"))
            {
                url += "/";
            }
            return url;
        }
    }
}