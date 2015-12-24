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
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO Article(");
            strSql.Append("AuditStatus,CreateTime,UpdateTime,Title,Content,Imgs,IsHot,IsBot,Type,Status");
            strSql.Append(") VALUES (");
            strSql.Append("@AuditStatus,@CreateTime,@UpdateTime,@Title,@Content,@Imgs,@IsHot,@IsBot,@Type,@Status");
            strSql.Append(") ");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] paras = {
			            new SqlParameter("@AuditStatus", SqlDbType.SmallInt,2){Value = 0},
                        new SqlParameter("@CreateTime", SqlDbType.DateTime){Value = DateTime.Now},            
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime){Value = DateTime.Now},         
                        new SqlParameter("@Title", SqlDbType.NVarChar,100){Value = model.Title},            
                        new SqlParameter("@Content", SqlDbType.NVarChar,-1){Value = model.Content},            
                        new SqlParameter("@Imgs", SqlDbType.VarChar,500){Value = model.Imgs},            
                        new SqlParameter("@IsHot", SqlDbType.Bit,1){Value = model.IsHot},            
                        new SqlParameter("@IsBot", SqlDbType.Bit,1){Value = model.IsBot},            
                        new SqlParameter("@Type", SqlDbType.VarChar,50){Value = model.Type},            
                        new SqlParameter("@Status", SqlDbType.SmallInt,2){Value = 1}            
            };
            var obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(), paras);
            return obj == null ? 0 : Convert.ToInt32(obj);
        }
    }
}
