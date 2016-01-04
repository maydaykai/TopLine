using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AdvertModel
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
        /// 链接地址
        /// </summary>		
        public string linkUrl { get; set; }

        /// <summary>
        /// 所属频道
        /// </summary>		
        public string channelId { get; set; }
        
        /// <summary>
        /// 状态 0：禁用；1：启用
        /// </summary>		
        public bool status { get; set; }

        public string statusStr
        {
            get { return status ? "启用" : "禁用"; }
        }
        /// <summary>
        /// 关联频道
        /// </summary>
        public ChannelModel channelModel { get; set; }
    }
}
