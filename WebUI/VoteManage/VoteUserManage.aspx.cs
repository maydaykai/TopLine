using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APICloud;
using Model;
using Newtonsoft.Json;

namespace WebUI.VoteManage
{
    public partial class VoteUserManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitChannel();
        }
        private void InitChannel()
        {
            var model = DataConstructor.Factory("vote");
            var data = model.Query();
            var list = JsonConvert.DeserializeObject<List<VoteModel>>(data);
            selVote.DataSource = list;
            selVote.DataValueField = "id";
            selVote.DataTextField = "title";
            selVote.DataBind();
        }
    }
}