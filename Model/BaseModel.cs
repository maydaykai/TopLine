using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>		
        public string id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime createdAt { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>		
        public DateTime updatedAt { get; set; }
    }
}
