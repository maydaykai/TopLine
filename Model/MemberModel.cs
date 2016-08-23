using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MemberModel
    {
        /// <summary>
        /// 编号
        /// </summary>		
        public string id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
        public string nickname { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createdAt { get; set; }
    }
}
