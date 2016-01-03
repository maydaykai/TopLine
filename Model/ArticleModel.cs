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
        /// 频道ID
        /// </summary>
        public string ChannelID { get; set; }

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
        /// 状态：1，添加成功；2，上传失败；3，上传成功；4，已隐藏
        /// </summary>
        public int Status { get; set; }
        public string StatusStr
        {
            get
            {
                switch (Status)
                {
                    case 1:
                        return "添加成功";
                    case 2:
                        return "上传失败";
                    case 3:
                        return "上传成功";
                }
                return "添加成功";
            }
        }

        /// <summary>
        /// 审核状态：0，审核中；1，审核不通过；2，审核通过；
        /// </summary>
        public int AuditStatus { get; set; }
        public string AuditStatusStr
        {
            get
            {
                switch (Status)
                {
                    case 0:
                        return "审核中";
                    case 1:
                        return "审核不通过";
                    case 2:
                        return "审核通过";
                }
                return "审核中";
            }
        }

        /// <summary>
        /// 审核记录
        /// </summary>
        public string AuditRecord { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PubTime { get; set; }

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
