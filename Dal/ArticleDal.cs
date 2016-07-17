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
            strSql.Append("Status,AuditStatus,PubTime,CreateTime,UpdateTime,Title,ChannelID,Content,Imgs,IsHot,IsBot,Type,Source,CreateUserID");
            strSql.Append(") VALUES (");
            strSql.Append("@Status,@AuditStatus,@PubTime,@CreateTime,@UpdateTime,@Title,@ChannelID,@Content,@Imgs,@IsHot,@IsBot,@Type,@Source,@CreateUserID");
            strSql.Append(") ");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] paras = {
			            new SqlParameter("@AuditStatus", SqlDbType.SmallInt,2){Value = 0},
                        new SqlParameter("@PubTime", SqlDbType.DateTime){Value = DateTime.Now}, 
                        new SqlParameter("@CreateTime", SqlDbType.DateTime){Value = DateTime.Now},            
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime){Value = DateTime.Now},         
                        new SqlParameter("@Title", SqlDbType.NVarChar,100){Value = model.Title},           
                        new SqlParameter("@Source", SqlDbType.NVarChar,50){Value = model.Source},            
                        new SqlParameter("@Content", SqlDbType.NVarChar,-1){Value = model.Content},
                        new SqlParameter("@ChannelID", SqlDbType.VarChar,50){Value= model.ChannelID},
                        new SqlParameter("@Imgs", SqlDbType.VarChar,500){Value = model.Imgs},            
                        new SqlParameter("@IsHot", SqlDbType.Bit,1){Value = model.IsHot},            
                        new SqlParameter("@IsBot", SqlDbType.Bit,1){Value = model.IsBot},            
                        new SqlParameter("@Type", SqlDbType.VarChar,50){Value = model.Type},            
                        new SqlParameter("@Status", SqlDbType.SmallInt,2){Value = 1},
                        new SqlParameter("@CreateUserID", SqlDbType.Int,4){Value = model.CreateUserID}
            };
            var obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(), paras);
            return obj == null ? 0 : Convert.ToInt32(obj);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ArticleModel model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE Article SET ");
            strSql.Append(" AuditStatus = @AuditStatus , ");
            strSql.Append(" AuditRecord = @AuditRecord , ");
            strSql.Append(" PubTime = @PubTime , ");
            strSql.Append(" UpdateTime = @UpdateTime , ");
            strSql.Append(" Title = @Title , ");
            strSql.Append(" Content = @Content , ");
            strSql.Append(" Imgs = @Imgs , ");
            strSql.Append(" IsHot = @IsHot , ");
            strSql.Append(" IsBot = @IsBot , ");
            strSql.Append(" Source = @Source , ");
            strSql.Append(" Type = @Type  ");
            strSql.Append(" WHERE ID=@ID ");

            SqlParameter[] paras = {
                        new SqlParameter("@AuditStatus", SqlDbType.SmallInt,2){Value = model.AuditStatus},            
                        new SqlParameter("@AuditRecord", SqlDbType.NVarChar,100){Value = model.AuditRecord},            
                        new SqlParameter("@PubTime", SqlDbType.DateTime){Value = model.PubTime},            
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime){Value = DateTime.Now},    
                        new SqlParameter("@Title", SqlDbType.NVarChar,100){Value = model.Title},          
                        new SqlParameter("@Source", SqlDbType.NVarChar,50){Value = model.Source},            
                        new SqlParameter("@Content", SqlDbType.NVarChar,-1){Value = model.Content},            
                        new SqlParameter("@Imgs", SqlDbType.VarChar,500){Value = model.Imgs},            
                        new SqlParameter("@IsHot", SqlDbType.Bit,1){Value = model.IsHot},            
                        new SqlParameter("@IsBot", SqlDbType.Bit,1){Value = model.IsBot},            
                        new SqlParameter("@Type", SqlDbType.VarChar,50){Value = model.Type},            
                        new SqlParameter("@ID", SqlDbType.Int,4){Value = model.ID}            
            };
            var rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(), paras);
            return rows > 0;
        }
        /// <summary>
        /// 上传成功
        /// </summary>
        public bool Upload(ArticleModel model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE Article SET ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" OID = @OID  ");
            strSql.Append(" WHERE ID=@ID ");

            SqlParameter[] paras = {
                        new SqlParameter("@Status", SqlDbType.SmallInt,2){Value = model.Status},                        
                        new SqlParameter("@OID", SqlDbType.VarChar,50){Value = model.OID},            
                        new SqlParameter("@ID", SqlDbType.Int,4){Value = model.ID}       
            };
            var rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(), paras);
            return rows > 0;
        }
        /// <summary>
        /// 隐藏
        /// </summary>
        public bool Delete(string oid)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE Article SET ");
            strSql.Append(" Status = 4 ");
            strSql.Append(" WHERE OID = @OID ");

            SqlParameter[] paras = {                   
                        new SqlParameter("@OID", SqlDbType.VarChar,50){Value = oid}     
            };
            var rows = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(), paras);
            return rows > 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ArticleModel GetModel(int id)
        {

            var strSql = new StringBuilder();
            strSql.Append("select ID, Status, AuditStatus, AuditRecord, PubTime, CreateTime, UpdateTime, OID, Title, ChannelID, Content, Imgs, IsHot, IsBot, Type, Source, CreateUserID  ");
            strSql.Append("  from Article ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] paras = {
					new SqlParameter("@ID", SqlDbType.Int,4){Value = id}
			};


            var model = new ArticleModel();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(), paras);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AuditStatus"].ToString() != "")
                {
                    model.AuditStatus = int.Parse(ds.Tables[0].Rows[0]["AuditStatus"].ToString());
                }
                model.AuditRecord = ds.Tables[0].Rows[0]["AuditRecord"].ToString();
                if (ds.Tables[0].Rows[0]["PubTime"].ToString() != "")
                {
                    model.PubTime = DateTime.Parse(ds.Tables[0].Rows[0]["PubTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
                }
                model.OID = ds.Tables[0].Rows[0]["OID"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.ChannelID = ds.Tables[0].Rows[0]["ChannelID"].ToString();
                model.Source = ds.Tables[0].Rows[0]["Source"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.Imgs = ds.Tables[0].Rows[0]["Imgs"].ToString();
                if (ds.Tables[0].Rows[0]["IsHot"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsHot"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsHot"].ToString().ToLower() == "true"))
                    {
                        model.IsHot = true;
                    }
                    else
                    {
                        model.IsHot = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsBot"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsBot"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsBot"].ToString().ToLower() == "true"))
                    {
                        model.IsBot = true;
                    }
                    else
                    {
                        model.IsBot = false;
                    }
                }
                model.Type = ds.Tables[0].Rows[0]["Type"].ToString();

                if (ds.Tables[0].Rows[0]["CreateUserID"].ToString() != "")
                {
                    model.CreateUserID = int.Parse(ds.Tables[0].Rows[0]["CreateUserID"].ToString());
                }
                return model;
            }
            return null;
        }
    }
}
