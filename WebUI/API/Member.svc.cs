using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using APICloud;

namespace WebUI.API
{
    [ServiceContract(Namespace = "WebUI.API")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Member
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

        // 在此处添加更多操作并使用 [OperationContract] 标记它们
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, Method = "GET")]
        public string GetList(string sidx, string sord, int page, int rows, int memberID, string startDate, string endDate, string title)
        {
            var model = DataConstructor.Factory("user");
            return model.Query();
        }
    }
}
