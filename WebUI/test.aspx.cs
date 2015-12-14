using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APICloud.Analytics;
using APICloud.Push;
using APICloud.Rest;
using Newtonsoft.Json.Linq;

namespace WebUI
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var model = Factory("user");
            var ret = model.Query();
        }
        static Factory Factory(string modelName)
        {
            var resouce = new Resource("A6994668718085", "664D29B1-760E-1B76-5871-CEB71FB2D993");
            return resouce.Factory(modelName);
        }
        static Resource Resource()
        {
            return new Resource("A6994668718085", "664D29B1-760E-1B76-5871-CEB71FB2D993");
        }
        static void testFile()
        {
            var file = Factory("file");
            using (var fs = new FileStream("G:\\xampp\\htdocs\\favicon.ico", FileMode.Open))
            {
                var ret = file.Upload(fs);

                Console.WriteLine(ret);
                Console.WriteLine("------------------------------");
            }


            var r = Factory("testr");
            string id = "";
            using (var fs1 = new FileStream("G:\\xampp\\htdocs\\favicon.ico", FileMode.Open))
            {
                using (var fs2 = new FileStream("G:\\xampp\\htdocs\\apache_pb.png", FileMode.Open))
                {
                    var ret = r.Create(new
                    {
                        file1 = fs1,
                        file2 = fs2
                    });
                    Console.WriteLine(ret);
                    Console.WriteLine("------------------------------");
                    var j = JObject.Parse(ret);
                    if (j["id"] != null)
                    {
                        id = j["id"].ToString();
                    }
                }

            }

            using (var fs = new FileStream("G:\\xampp\\htdocs\\favicon.ico", FileMode.Open))
            {
                var relation = r.Upload(id, "f", fs);
                Console.WriteLine(relation);
                Console.WriteLine("------------------------------");
            }


        }
        static void testRest()
        {
            var t = Factory("test");
            var id = string.Empty;

            Console.WriteLine("==========create==========");
            var ret = t.Create(new
            {
                str = "APICloud-rest"
            });
            var create = JObject.Parse(ret);
            if (create["id"] != null)
            {
                id = create["id"].ToString();
            }
            Console.WriteLine(create.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("===========get===========");
            ret = t.Get(id);
            var get = JObject.Parse(ret);
            Console.WriteLine(get.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("==========count ==========");
            ret = t.Count();
            var count = JObject.Parse(ret);
            Console.WriteLine(count.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("==========exists ==========");
            ret = t.Exists(id);
            var exists = JObject.Parse(ret);
            Console.WriteLine(exists.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("==========findOne=========");
            ret = t.FindOne();
            var findone = JObject.Parse(ret);
            Console.WriteLine(findone.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("==========update =========");
            ret = t.Edit(id, new
            {
                str = "APICloud"
            });
            var update = JObject.Parse(ret);
            Console.WriteLine(update.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("========== query  =========");
            ret = t.Query();
            var query = JArray.Parse(ret);
            Console.WriteLine(query.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("========== delete =========");
            ret = t.Delete(id);
            var delete = JObject.Parse(ret);
            Console.WriteLine(delete.ToString());
            Console.WriteLine("========================");
        }
        static void testUser()
        {
            var r = Resource();
            var u = r.Factory("user");
            var id = string.Empty;

            Console.WriteLine("==========create==========");
            var ret = u.Create(new
            {
                username = "beiluo",
                password = "111111"
            });
            var create = JObject.Parse(ret);
            if (create["id"] != null)
            {
                id = create["id"].ToString();
            }
            Console.WriteLine(create.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("========== login ==========");
            var authorization = string.Empty;
            ret = u.Login("beiluo", "111111");
            var login = JObject.Parse(ret);
            if (login["id"] != null)
            {
                authorization = login["id"].ToString();
                r.SetHeader("Authorization", authorization);
            }
            Console.WriteLine(login.ToString());
            Console.WriteLine("========================");
            Console.WriteLine("==========update==========");
            ret = u.Edit(id, new
            {
                password = "222222"
            });
            var update = JObject.Parse(ret);
            Console.WriteLine(update.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("==========delete==========");
            ret = u.Delete(id);
            var delete = JObject.Parse(ret);
            Console.WriteLine(delete.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("==========logout==========");
            ret = u.Logout(authorization);
            var logout = JObject.Parse(ret);
            Console.WriteLine(logout.ToString());
            Console.WriteLine("========================");
        }
        static void testRelation()
        {
            var t = Factory("test");
            var id = string.Empty;

            Console.WriteLine("==========create==========");
            var ret = t.Create(new
            {
                str = "APICloud-rest"
            });
            var create = JObject.Parse(ret);
            if (create["id"] != null)
            {
                id = create["id"].ToString();
            }
            Console.WriteLine(create.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("==========createRelation==========");
            ret = t.Create(id, "r", new
            {
                other = "beiluo"
            });
            var createRelation = JObject.Parse(ret);
            Console.WriteLine(createRelation.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("==========getRelation==========");
            ret = t.Get(id, "r");
            var getRelation = JArray.Parse(ret);
            Console.WriteLine(getRelation.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("==========countRelation==========");
            ret = t.Count(id, "r");
            var countRelation = JObject.Parse(ret);
            Console.WriteLine(countRelation.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("==========deleteRelation==========");
            ret = t.Delete(id, "r");
            var deleteRelation = JObject.Parse(ret);
            Console.WriteLine(deleteRelation.ToString());
            Console.WriteLine("========================");

            Console.WriteLine("==========delete==========");
            ret = t.Delete(id);
            var delete = JObject.Parse(ret);
            Console.WriteLine(delete.ToString());
            Console.WriteLine("========================");
        }
        static void testBatch()
        {
            var r = Resource();
            var list = new List<Object>();
            list.Add(new
            {
                method = "GET",
                path = "/mcm/api/file"
            });
            list.Add(new
            {
                method = "GET",
                path = "/mcm/api/file/count"
            });
            var ret = r.Batch(list);
            Console.WriteLine(JArray.Parse(ret).ToString());

            var arr = JArray.FromObject(list);
            ret = r.Batch(arr.ToString());
            Console.WriteLine(JArray.Parse(ret).ToString());
        }

        static void testPush()
        {
            var push = new Push("A6985431369648", "DEE7DB7E-CB5F-63D3-962E-C0F40107028B");
            var obj = new JObject();
            obj["title"] = "test";
            obj["content"] = "没有什么能够阻挡";
            obj["type"] = 1;
            obj["platform"] = 0;
            var ret = push.Message(obj.ToString());
            Console.WriteLine(JObject.Parse(ret).ToString());

            var pararm = new
            {
                title = "test",
                content = "没有什么能够阻挡",
                type = 1,
                platform = 0
            };
            ret = push.Message(pararm);
            Console.WriteLine(JObject.Parse(ret).ToString());
        }
        static void testAnalytics()
        {
            var Analytics = new Analytics("A6985431369648", "DEE7DB7E-CB5F-63D3-962E-C0F40107028B");

            var ret = Analytics.getAppStatisticDataById("2015-05-22", "2015-05-28");
            Console.WriteLine("==:1");
            Console.WriteLine(JObject.Parse(ret).ToString());

            ret = Analytics.getVersionsStatisticDataById("2015-05-22", "2015-05-28");
            Console.WriteLine("==:2");
            Console.WriteLine(JObject.Parse(ret).ToString());

            ret = Analytics.getGeoStatisticDataById("2015-05-22", "2015-05-28", null);
            Console.WriteLine("==:3");
            Console.WriteLine(JObject.Parse(ret).ToString());

            ret = Analytics.getDeviceStatisticDataById("2015-05-22", "2015-05-28");
            Console.WriteLine("==:4");
            Console.WriteLine(JObject.Parse(ret).ToString());

            ret = Analytics.getExceptionsStatisticDataById("2015-05-22", "2015-05-28");
            Console.WriteLine("==:5");
            Console.WriteLine(JObject.Parse(ret).ToString());

            ret = Analytics.getExceptionsDetailByTitle("NullPointerException[com.uzmap.pkg.uzmodules.uzScanner.Zxing.CaptureActivity.java,onActivityResult,180]");
            Console.WriteLine("==:6");
            Console.WriteLine(JObject.Parse(ret).ToString());
        }
        
    }
}