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
    public class BannerBll
    {
        private readonly BannerDal _dal = new BannerDal();

        /// <summary>
        /// 增加
        /// </summary>
        public int Add(BannerModel model)
        {
            return _dal.Add(model);
        }

        /// <summary>
        /// 更新
        /// </summary>
        public bool Update(BannerModel model)
        {
            return _dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BannerModel GetModel(int ID)
        {
            return _dal.GetModel(ID);
        }

        /// <summary>
        /// 数据分页
        /// </summary>
        public DataTable GetPageList(string where, string orderBy, int pageIndex, int pageSize, ref int totalRows)
        {
            const string fields = "*";
            const string tables = "dbo.[Banner]";
            return BaseClass.GetPageDataTable(fields, tables, where, orderBy, pageIndex, pageSize, ref totalRows);
        }
    }
}
