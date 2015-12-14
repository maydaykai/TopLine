using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace Common
{
    public static class ConfigHelper
    {
        /// <summary>
        /// //站点根目录物理路径
        /// </summary>
        public static string WebRoot = HttpRuntime.AppDomainAppPath;

        /// <summary>
        /// 征信认证系统webservice接口的用户名
        /// </summary>
        public static string ZxUserid = WebConfigurationManager.AppSettings["zx_UserID"];

        /// <summary>
        /// 征信认证系统webservice接口的密码
        /// </summary>
        public static string ZxPwd = WebConfigurationManager.AppSettings["zx_Pwd"];

        /// <summary>
        /// 合同文件虚拟路径
        /// </summary>
        public static string ContractVirtualPath = WebConfigurationManager.AppSettings["contractVirtualPath"];

        /// <summary>
        /// 合同文件物理路径
        /// </summary>
        public static string ContractPhysicallPath = WebConfigurationManager.AppSettings["contractPhysicallPath"];

        /// <summary>
        /// 上传图片虚拟路径
        /// </summary>
        public static string ImgVirtualPath = WebConfigurationManager.AppSettings["imgVirtualPath"];

        /// <summary>
        /// 上传图片物理路径
        /// </summary>
        public static string ImgPhysicallPath = WebConfigurationManager.AppSettings["imgPhysicallPath"];

        /// <summary>
        /// 身份证照片虚拟路径
        /// </summary>
        public static string IdPhotoVirtualPath = WebConfigurationManager.AppSettings["idPhotoVirtualPath"];

        /// <summary>
        /// 身份证照片物理路径
        /// </summary>
        public static string IdPhotoPhysicallPath = WebConfigurationManager.AppSettings["idPhotoPhysicallPath"];

        /// <summary>
        /// 借款标审核附件虚拟路径
        /// </summary>
        public static string LoanFileVirtualPath = WebConfigurationManager.AppSettings["loanFileVirtualPath"];

        /// <summary>
        /// 借款标审核附件物理路径
        /// </summary>
        public static string LoanFilePhysicallPath = WebConfigurationManager.AppSettings["loanFilePhysicallPath"];

        /// <summary>
        /// APP文件虚拟路径
        /// </summary>
        public static string AppFileVirtualPath = WebConfigurationManager.AppSettings["appFileVirtualPath"];

        /// <summary>
        /// APP文件物理路径
        /// </summary>
        public static string AppFilePhysicallPath = WebConfigurationManager.AppSettings["appFilePhysicallPath"];

    }
}
