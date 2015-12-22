using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;

namespace Bll
{
    public class ArticleBll
    {
        private ArticleDal _dal = new ArticleDal();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ArticleModel model)
        {
            return _dal.Add(model);
        }
    }
}
