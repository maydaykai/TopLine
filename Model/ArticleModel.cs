using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ArticleModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 标识ID
        /// </summary>
        public string OID { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Imgs { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        public bool IsHot { get; set; }

        /// <summary>
        /// IsBot
        /// </summary>
        public bool IsBot { get; set; }

        /// <summary>
        /// 类型：包括play、img、txt
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 状态：1，添加成功；2，上传失败；3上传成功
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 审核状态：0，初审中；1，初审失败；2，复审中；3，复审失败；4，复审成功
        /// </summary>
        public int AuditStatus { get; set; }

        /// <summary>
        /// 本地创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 服务器创建时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
