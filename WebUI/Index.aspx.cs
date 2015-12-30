using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace WebUI
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionHelper.Exists("UserName"))
            {
                string fcmsUserName = SessionHelper.Get("UserName").ToString();
                var timeGreet = "";
                timeGreet = DateTime.Now.Hour < 5 || DateTime.Now.Hour >= 9 ? (DateTime.Now.Hour < 9 || DateTime.Now.Hour >= 12 ? (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18 ? "下午好" : "晚上好") : "上午好") : "早上好";
                lblWelCome.Text = timeGreet + "〔<span style='color:#ff0000;font-weight: bold;'>" + fcmsUserName + "</span>〕，欢迎您进入新闻后台管理系统！";
            }
            else
            {
                lblWelCome.Text = "";
            }
        }
    }
}