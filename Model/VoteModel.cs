using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VoteModel
    {
        /// <summary>
        /// 编号
        /// </summary>		
        public string id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>		
        public string title { get; set; }

        /// <summary>
        /// 图片
        /// </summary>		
        public string img { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>		
        public DateTime beginDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>		
        public DateTime endDate { get; set; }

        /// <summary>
        /// 描述
        /// </summary>		
        public string desc { get; set; }
        
        /// <summary>
        /// 状态 0：禁用；1：启用
        /// </summary>		
        public bool status { get; set; }

        public string statusStr
        {
            get { return status ? "启用" : "禁用"; }
        }
    }
}
