using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;

namespace Bll
{
    public class ArticleBll
    {
        private readonly ArticleDal _dal = new ArticleDal();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ArticleModel model)
        {
            return _dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ArticleModel model)
        {
            return _dal.Update(model);
        }

        /// <summary>
        /// 上传成功
        /// </summary>
        public bool Upload(ArticleModel model)
        {
            return _dal.Upload(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ArticleModel GetModel(int id)
        {
            return _dal.GetModel(id);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRows"></param>
        /// <returns></returns>
        public DataTable GetList(string where, string orderBy, int pageIndex, int pageSize, ref int totalRows)
        {
            const string fields = "*";
            const string tables = "dbo.[Article]";
            return BaseClass.GetPageDataTable(fields, tables, where, orderBy, pageIndex, pageSize, ref totalRows);
        }
    }
}
