using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common
{
    public class JsonTipHelper
    {
        public static string SuccessMessage(string msg = "添加成功")
        {
            return JsonConvert.SerializeObject(new { result = "success", message = msg });
        }
        public static string WarningMessage(string msg)
        {
            return JsonConvert.SerializeObject(new { result = "warning", message = msg });
        }
        public static string ErrorMessage(string msg = "添加失败")
        {
            return JsonConvert.SerializeObject(new { result = "error", message = msg });
        }
    }
}
