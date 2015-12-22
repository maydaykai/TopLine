using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conn;
using Model;

namespace Dal
{
    public class ArticleDal
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ArticleModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Article(");
            strSql.Append("Title,Content,Imgs,IsHot,IsBot,Type");
            strSql.Append(") values (");
            strSql.Append("@OID,@Title,@Content,@Imgs,@IsHot,@IsBot,@Type");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@Title", SqlDbType.NVarChar,100){Value= model.Title},
                        new SqlParameter("@Content", SqlDbType.NVarChar,-1){Value= model.Content},
                        new SqlParameter("@Imgs", SqlDbType.VarChar,500){Value= model.Imgs},
                        new SqlParameter("@IsHot", SqlDbType.Bit,1){Value= model.IsHot},
                        new SqlParameter("@IsBot", SqlDbType.Bit,1){Value= model.IsBot},
                        new SqlParameter("@Type", SqlDbType.VarChar,50){Value= model.Type}
                        };
            object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(), parameters);
            return obj == null ? 0 : Convert.ToInt32(obj);
        }
    }
}
