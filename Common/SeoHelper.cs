using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SeoHelper
    {
        public static string PostUrl(string[] urls, string siteUrl= "http://data.zz.baidu.com/urls?site=www.aftop.cn&token=rZTlxNpiWaFj5YBB")
        {
            try
            {
                string formData = "";

                foreach (string url in urls)
                {
                    formData += url + "\n";
                }

                byte[] postData = System.Text.Encoding.UTF8.GetBytes(formData);

                // 设置提交的相关参数   
                System.Net.HttpWebRequest request = System.Net.WebRequest.Create(siteUrl) as System.Net.HttpWebRequest;
                System.Text.Encoding myEncoding = System.Text.Encoding.UTF8;
                request.Method = "POST";
                request.KeepAlive = false;
                request.AllowAutoRedirect = true;
                request.ContentType = "text/plain";
                request.UserAgent = "curl/7.12.1";
                request.ContentLength = postData.Length;

                // 提交请求数据   
                System.IO.Stream outputStream = request.GetRequestStream();
                outputStream.Write(postData, 0, postData.Length);
                outputStream.Close();

                System.Net.HttpWebResponse response;
                System.IO.Stream responseStream;
                System.IO.StreamReader reader;
                string srcString;
                response = request.GetResponse() as System.Net.HttpWebResponse;
                responseStream = response.GetResponseStream();
                reader = new System.IO.StreamReader(responseStream, System.Text.Encoding.GetEncoding("UTF-8"));
                srcString = reader.ReadToEnd();
                string result = srcString;   //返回值赋值  
                reader.Close();

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
