using System;
using Bll;
using Common;

namespace WebUI
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected int MemberId;
        protected int ColumnId;

        protected string RightArray
        {
            get
            {
                var roleRightBll = new RoleRightBll();
                return "|" + roleRightBll.GetRightListByRoleIdAndCid(SessionHelper.Get("Role").ToString(), ColumnId) +"|";
            }
        }
        public bool RightSearch//查询、查看权限
        {
            get
            {
                return RightArray.IndexOf("|1|", StringComparison.Ordinal) >= 0;
            }
        }
        public bool RightAdd//添加权限
        {
            get
            {
                return RightArray.IndexOf("|2|", StringComparison.Ordinal) >= 0;
            }
        }
        public bool RightEdit//修改权限
        {
            get
            {
                return RightArray.IndexOf("|3|", StringComparison.Ordinal) >= 0;
            }
        }
        public bool RightDelete//删除权限
        {
            get
            {
                return RightArray.IndexOf("|4|", StringComparison.Ordinal) >= 0;
            }
        }
        public bool RightAudit//审核权限
        {
            get
            {
                return RightArray.IndexOf("|7|", StringComparison.Ordinal) >= 0;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            ColumnId = ConvertHelper.QueryString(Request, "columnId", 0);
            if (SessionHelper.Exists("UserId"))
            {
                MemberId = ConvertHelper.ToInt(SessionHelper.Get("UserId").ToString());

                if (MemberId > 0)
                {
                    if (ColumnId == -1)
                    {
                    }
                    else
                    {
                        if (SessionHelper.Exists("Role"))
                        {
                            if (!RightSearch)//查看
                            {
                                Response.Write("没有查看权限！");
                                Response.End();
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">top.window.location='/ManageLogin.aspx'</script>");
                    Response.End();
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">top.window.location='/ManageLogin.aspx'</script>");
                Response.End();
            }


            base.OnLoad(e);
        }
    }
}