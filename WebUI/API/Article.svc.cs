using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using APICloud;
using Bll;
using Common;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebUI.API
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Article
    {
        // 要使用 HTTP GET，请添加 [WebGet] 特性。(默认 ResponseFormat 为 WebMessageFormat.Json)
        // 要创建返回 XML 的操作，
        //     请添加 [WebGet(ResponseFormat=WebMessageFormat.Xml)]，
        //     并在操作正文中包括以下行:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // 在此处添加操作实现
            return;
        }

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "GET")]
        public object GetList(string sortdatafield, string sortorder, int pagenum, int pagesize)
        {
            pagenum += 1;

            int pageCount = 0;
            var dt = new ArticleBll().GetList("", sortdatafield + " " + sortorder, pagenum, pagesize, ref pageCount);
            var modelData = (from DataRow dr in dt.Rows
                             select new
                             {
                                 ID = dr["ID"].ToString()
                             });
            var jsonData = new
            {
                TotalRows = pageCount,//记录数
                Rows = modelData//实体列表
            };
            return JsonConvert.SerializeObject(jsonData);
        }
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "POST")]
        public string DeleteChannel(string id)
        {
            var model = DataConstructor.Factory("channel");
            var resultData = model.Delete(id);
            var jObj = JObject.Parse(resultData);
            return jObj["Error"] == null ? JsonTipHelper.SuccessMessage("删除成功") : JsonTipHelper.ErrorMessage("删除失败");
        }
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "POST")]
        public object DeleteArticle(string id)
        {
            var model = DataConstructor.Factory("article");
            var resultData = model.Delete(id);
            var jObj = JObject.Parse(resultData);
            return (jObj["Error"] == null && new ArticleBll().Delete(id))
                ? JsonTipHelper.SuccessMessage("删除成功")
                : JsonTipHelper.ErrorMessage("删除失败");
        }
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "POST")]
        public object DeleteUserArticle(string id)
        {
            var model = DataConstructor.Factory("userArticle");
            var resultData = model.Edit(id, new
            {
                status = 2
            });
            var jObj = JObject.Parse(resultData);
            return jObj["Error"] == null ? JsonTipHelper.SuccessMessage("删除成功") : JsonTipHelper.ErrorMessage("删除失败");
        }
    }
}
