using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using APICloud;
using Common;
using Bll;
using Model;
using System.Web.Security;
using Newtonsoft.Json;

namespace WebUI.UserManage
{
    public partial class UserEdit : BasePage
    {
        private RoleBll _roleBll;
        private int _id;
        protected void Page_Load(object sender, EventArgs e)
        {
            _roleBll = new RoleBll();
            _id = ConvertHelper.QueryString(Request, "ID", 0);
            if (!IsPostBack)
            {
                BindRoleList();
                InitChannel();
                if (_id > 0)
                {
                    txtUserName.Disabled = true;
                    var userBll = new UserBll();
                    var userModel = userBll.GetModel(_id);
                    txtUserName.Value = userModel.UserName;
                    txtRealName.Value = userModel.RealName;
                    txtAnotherName.Value = userModel.AnotherName;
                    txtPhone.Value = userModel.Phone;
                    txtMobile.Value = userModel.Mobile;
                    txtEmail.Value = userModel.Email;
                    txtQQ.Value = userModel.QQ;
                    chkLock.Checked = userModel.IsLock;
                    userModel.LastIP = Request.UserHostAddress;
                    userModel.LastLoginTime = DateTime.Now;
                    userModel.RegTime = DateTime.Now;
                    userModel.UpdateTime = DateTime.Now;
                    ControlHelper.SetChecked(ckbRoleList, userModel.RoleId, ",");
                    ControlHelper.SetChecked(ckbChannelList, userModel.Channels, ",");
                    rblSex.SelectedValue = userModel.Sex.ToString();
                    litRegTime.Text = userModel.RegTime.ToString("yyyy-MM-dd HH:mm:ss");
                    litLastLoginTime.Text = userModel.LastLoginTime.ToString("yyyy-MM-dd HH:mm:ss");
                    litLastLoginIP.Text = userModel.LastIP;
                    litTimes.Text = userModel.Times.ToString();
                }
                else
                {
                    txtUserName.Attributes["class"] = "input_text";
                    imgUserNameLeft.Src = "../images/input_left.png";
                    imgUserNameRight.Src = "../images/input_right.png";
                }

            }
        }

        //绑定角色列表
        private void BindRoleList()
        {
            var ds = _roleBll.GetRoleList();
            if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0) return;
            ckbRoleList.DataSource = ds;
            ckbRoleList.DataValueField = "ID";
            ckbRoleList.DataTextField = "Name";
            ckbRoleList.DataBind();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            var userBll = new UserBll();
            if (string.IsNullOrEmpty(txtUserName.Value.Trim()))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('用户名不能为空','warning', '');", true); return;
            }
            if (!RegexHelper.IsUserName(txtUserName.Value.Trim()) || txtUserName.Value.Trim().Length < 5 || txtUserName.Value.Trim().Length > 12)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('用户名长度为5-12位且由26个英文字母或数字组成','warning', '');", true); return;
            }

            if (!txtPwd.Value.Trim().Equals(txtPwdConfirm.Value.Trim()))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('密码确认错误','warning', '');", true); return;
            }
            var pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(string.IsNullOrEmpty(txtPwd.Value.Trim()) ? "123456" : txtPwd.Value.Trim(), "md5");
            if (_id > 0)
            {
                UserModel userModel = userBll.GetModel(_id);
                if (!string.IsNullOrEmpty(txtPwd.Value.Trim()))
                {
                    userModel.PassWord = pwd;
                }
                userModel.RealName = txtRealName.Value.Trim();
                userModel.AnotherName = txtAnotherName.Value.Trim();
                userModel.Phone = txtPhone.Value.Trim();
                userModel.Mobile = txtMobile.Value.Trim();
                userModel.Email = txtEmail.Value.Trim();
                userModel.QQ = txtQQ.Value.Trim();
                userModel.IsLock = chkLock.Checked;
                userModel.UpdateTime = DateTime.Now;
                userModel.RoleId = ControlHelper.GetCheckBoxList(ckbRoleList, ",");
                userModel.Channels = ControlHelper.GetCheckBoxList(ckbChannelList, ",");
                userModel.ParentID = 0;
                userModel.Sex = ConvertHelper.ToInt(rblSex.SelectedValue.Trim());
                ClientScript.RegisterClientScriptBlock(GetType(), "",
                                                       userBll.Update(userModel)
                                                           ? "MessageAlert('修改成功。','success', '/UserManage/UserManage.aspx?columnId=" +
                                                             ColumnId + "');"
                                                           : "MessageAlert('修改失败。','error', '');", true);
            }
            else
            {
                if (userBll.Exists(txtUserName.Value.Trim()))
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "", "MessageAlert('用户名已存在，请换一个','warning', '');", true); return;
                }
                var userModel = new UserModel
                    {
                        UserName = txtUserName.Value.Trim(),
                        PassWord = pwd,
                        RealName = txtRealName.Value.Trim(),
                        AnotherName = txtAnotherName.Value.Trim(),
                        Phone = txtPhone.Value.Trim(),
                        Mobile = txtMobile.Value.Trim(),
                        Email = txtEmail.Value.Trim(),
                        QQ = txtQQ.Value.Trim(),
                        IsLock = chkLock.Checked,
                        LastLoginTime = DateTime.Now,
                        RegTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        RoleId = ControlHelper.GetCheckBoxList(ckbRoleList, ","),
                        Channels = ControlHelper.GetCheckBoxList(ckbChannelList, ","),
                        ParentID = 0,
                        Sex = ConvertHelper.ToInt(rblSex.SelectedValue.Trim()),
                        Times = 0
                    };
                ClientScript.RegisterClientScriptBlock(GetType(), "",
                                                       userBll.Add(userModel)
                                                           ? "MessageAlert('添加成功。','success', '/UserManage/UserManage.aspx?columnId=" +
                                                             ColumnId + "');"
                                                           : "MessageAlert('添加失败。','error', '');", true);
            }
        }
    }


}