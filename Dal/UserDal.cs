using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conn;
using Model;
using Common;

namespace Dal
{
    public class UserDal
    {

        /// <summary>
        /// 判断用户名是否已存在
        /// </summary>
        public bool Exists(string userName)
        {
            var strSql = new StringBuilder();
            strSql.Append("select count(1) from [User]");
            strSql.Append(" where ");
            strSql.Append(" UserName = @UserName  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,20){Value = userName}
			};
            var row = ConvertHelper.ToInt(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(), parameters).ToString());
            return row > 0;
        }

        //登陆验证
        public bool LoginValidate(ref UserModel model)
        {
            model = GetUserByNameAndPwd(model.UserName, model.PassWord);
            if (model != null)
            {
                if (model.ID > 0)
                {
                    return true;
                }
            }
            return false;
        }

        ///// <summary>
        ///// 更新登录信息
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public bool UpdateLoginInfo(UserModel model)
        //{
        //    var flag = false;
        //    var strSql = new StringBuilder();
        //    strSql.Append("update Member set ");
        //    strSql.Append(" LastIP = @LastIP, ");
        //    strSql.Append(" LastLoginTime = @LastLoginTime, ");
        //    strSql.Append(" Times = Times + 1 ");
        //    strSql.Append(" where ID=@ID");
        //    SqlParameter[] parameters =
        //    {
        //        new SqlParameter("@ID", SqlDbType.Int, 4) {Value = model.ID},
        //        new SqlParameter("@LastLoginTime", SqlDbType.DateTime) {Value = model.LastLoginTime},
        //        new SqlParameter("@LastIP", SqlDbType.NVarChar, 50) {Value = HttpConnect. Request.UserHostAddress}
        //    };

        //    var num = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(), parameters);

        //    return num > 0;
        //}

        private UserModel GetUserByNameAndPwd(string userName, string passWord)
        {
            var strSql = new StringBuilder();
            strSql.Append("select [ID], [Email], [QQ], [RegTime], [LastLoginTime], [LastIP], [Times], [IsLock], [UpdateTime], [RoleID], [Channels], [ParentID], [UserName], [PassWord], [RealName],[AnotherName], [Sex], [Phone], [Mobile] ");
            strSql.Append("  from [User] ");
            strSql.Append(" where UserName=@UserName ");
            strSql.Append(" AND PassWord=@PassWord ");
            strSql.Append(" AND [IsLock]=0");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@UserName", SqlDbType.NVarChar) {Value = userName},
                    new SqlParameter("@PassWord", SqlDbType.VarChar) {Value = passWord}
                };

            var model = new UserModel();
            var ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                if (ds.Tables[0].Rows[0]["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(ds.Tables[0].Rows[0]["RegTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                model.LastIP = ds.Tables[0].Rows[0]["LastIP"].ToString();
                if (ds.Tables[0].Rows[0]["Times"].ToString() != "")
                {
                    model.Times = int.Parse(ds.Tables[0].Rows[0]["Times"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsLock"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsLock"].ToString().ToLower() == "true"))
                    {
                        model.IsLock = true;
                    }
                    else
                    {
                        model.IsLock = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
                }
                model.RoleId = ds.Tables[0].Rows[0]["RoleID"].ToString();
                model.Channels = ds.Tables[0].Rows[0]["Channels"].ToString();
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.AnotherName = ds.Tables[0].Rows[0]["AnotherName"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                return model;
            }
            return null;
        }

        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(UserModel model)
        {
            var falg = false;
            var sqlcon = new SqlConnection(SqlHelper.ConnectionStringLocal);
            sqlcon.Open();
            var sqltran = sqlcon.BeginTransaction();
            var sqlcmd = new SqlCommand { Connection = sqlcon, Transaction = sqltran, CommandType = CommandType.Text };

            try
            {
                var strSql = new StringBuilder();
                strSql.Append("insert into [User] ");
                strSql.Append(" (UserName,Email,QQ ,LastLoginTime,RegTime,IsLock,UpdateTime,RoleID,Channels,ParentID,PassWord,RealName,AnotherName,Sex,Phone,Mobile,Times)");
                strSql.Append(" Values(@UserName,@Email,@QQ ,@LastLoginTime,@RegTime,@IsLock,@UpdateTime,@RoleID,@Channels,@ParentID,@PassWord,@RealName,@AnotherName,@Sex,@Phone,@Mobile,@Times)");
                strSql.Append(";select SCOPE_IDENTITY()");
                SqlParameter[] parameters =
                    {
                        new SqlParameter("@UserName", SqlDbType.VarChar, 50) {Value = model.UserName},
                        new SqlParameter("@Email", SqlDbType.NVarChar, 200) {Value = model.Email},
                        new SqlParameter("@QQ", SqlDbType.VarChar, 20) {Value = model.QQ},
                        new SqlParameter("@LastLoginTime", SqlDbType.DateTime) {Value = model.LastLoginTime},
                        new SqlParameter("@RegTime", SqlDbType.DateTime) {Value = model.RegTime},
                        new SqlParameter("@IsLock", SqlDbType.Bit, 1) {Value = model.IsLock},
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime) {Value = model.UpdateTime},
                        new SqlParameter("@RoleID", SqlDbType.VarChar, 100) {Value = model.RoleId},           
                        new SqlParameter("@Channels", SqlDbType.VarChar,100){Value = model.Channels} ,  
                        new SqlParameter("@ParentID", SqlDbType.Int, 4) {Value = model.ParentID},
                        new SqlParameter("@PassWord", SqlDbType.VarChar, 50) {Value = model.PassWord},
                        new SqlParameter("@RealName", SqlDbType.NVarChar, 50) {Value = model.RealName},
                        new SqlParameter("@AnotherName", SqlDbType.NVarChar, 50) {Value = model.AnotherName},
                        new SqlParameter("@Sex", SqlDbType.Int, 4) {Value = model.Sex},
                        new SqlParameter("@Phone", SqlDbType.VarChar, 20) {Value = model.Phone},
                        new SqlParameter("@Mobile", SqlDbType.VarChar, 20) {Value = model.Mobile},
                        new SqlParameter("@Times", SqlDbType.Int, 4) {Value = model.Times}
                    };
                sqlcmd.CommandText = strSql.ToString();
                sqlcmd.Parameters.Clear();
                foreach (var sqlParameter in parameters)
                {
                    sqlcmd.Parameters.Add(sqlParameter);
                }
                var result = sqlcmd.ExecuteNonQuery();

                if (result == 1)
                {
                    sqltran.Commit();
                    falg = true;
                }
                else
                {
                    sqltran.Rollback();
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteError(ex);
                sqltran.Rollback();
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
            }
            return falg;
        }


        /// <summary>
        /// 更新
        /// </summary>
        public bool Update(UserModel model)
        {
            var falg = false;
            var sqlcon = new SqlConnection(SqlHelper.ConnectionStringLocal);
            sqlcon.Open();
            var sqltran = sqlcon.BeginTransaction();
            var sqlcmd = new SqlCommand { Connection = sqlcon, Transaction = sqltran, CommandType = CommandType.Text };
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("update [User] set ");
                strSql.Append(" Email = @Email , ");
                strSql.Append(" QQ = @QQ , ");
                strSql.Append(" IsLock = @IsLock , ");
                strSql.Append(" UpdateTime = @UpdateTime , ");
                strSql.Append(" RoleID = @RoleID , ");
                strSql.Append(" Channels = @Channels , ");
                strSql.Append(" ParentID = @ParentID , ");
                strSql.Append(" PassWord = @PassWord , ");
                strSql.Append(" RealName = @RealName , ");
                strSql.Append(" AnotherName = @AnotherName , ");
                strSql.Append(" Sex = @Sex , ");
                strSql.Append(" Phone = @Phone , ");
                strSql.Append(" Mobile = @Mobile  ");
                strSql.Append(" where ID=@ID ");

                SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4){Value = model.ID} ,            
                        new SqlParameter("@Email", SqlDbType.NVarChar,200){Value = model.Email} ,            
                        new SqlParameter("@QQ", SqlDbType.VarChar,20){Value = model.QQ} ,                                                  
                        new SqlParameter("@IsLock", SqlDbType.Bit,1){Value = model.IsLock} ,            
                        new SqlParameter("@UpdateTime", SqlDbType.DateTime){Value = model.UpdateTime} ,            
                        new SqlParameter("@RoleID", SqlDbType.VarChar,100){Value = model.RoleId} ,                 
                        new SqlParameter("@Channels", SqlDbType.VarChar,100){Value = model.Channels} ,   
                        new SqlParameter("@ParentID", SqlDbType.Int,4){Value = model.ParentID} ,                     
                        new SqlParameter("@PassWord", SqlDbType.VarChar,50){Value = model.PassWord} ,                     
                        new SqlParameter("@RealName", SqlDbType.NVarChar,50){Value = model.RealName} , 
                        new SqlParameter("@AnotherName", SqlDbType.NVarChar,50){Value = model.AnotherName} ,  
                        new SqlParameter("@Sex", SqlDbType.Int,4){Value = model.Sex} ,            
                        new SqlParameter("@Phone", SqlDbType.VarChar,20){Value = model.Phone} ,            
                        new SqlParameter("@Mobile", SqlDbType.VarChar,20){Value = model.Mobile}                           
                 };
                sqlcmd.Parameters.Clear();
                sqlcmd.CommandText = strSql.ToString();
                foreach (var sqlParameter in parameters)
                {
                    sqlcmd.Parameters.Add(sqlParameter);
                }
                var result = sqlcmd.ExecuteNonQuery();

                if (result == 1)
                {
                    falg = true;
                    sqltran.Commit();
                }
                else
                {
                    sqltran.Rollback();
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.WriteError(ex);
                sqltran.Rollback();
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcon.Close();
            }
            return falg;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserModel GetModel(int id)
        {
            var strSql = new StringBuilder();
            strSql.Append("select [ID], [Email], [QQ], [RegTime], [LastLoginTime], [LastIP], [Times], [IsLock], [UpdateTime], [RoleID], [Channels], [ParentID], [UserName], [PassWord], [RealName],[AnotherName], [Sex], [Phone], [Mobile]  ");
            strSql.Append("  from [User] ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4){Value=id}
			};

            var model = new UserModel();
            var ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                if (ds.Tables[0].Rows[0]["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(ds.Tables[0].Rows[0]["RegTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                model.LastIP = ds.Tables[0].Rows[0]["LastIP"].ToString();
                if (ds.Tables[0].Rows[0]["Times"].ToString() != "")
                {
                    model.Times = int.Parse(ds.Tables[0].Rows[0]["Times"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsLock"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsLock"].ToString().ToLower() == "true"))
                    {
                        model.IsLock = true;
                    }
                    else
                    {
                        model.IsLock = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
                }
                model.RoleId = ds.Tables[0].Rows[0]["RoleID"].ToString();
                model.Channels = ds.Tables[0].Rows[0]["Channels"].ToString();
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.AnotherName = ds.Tables[0].Rows[0]["AnotherName"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();

                return model;
            }
            return null;
        }
        
        /// <summary>
        /// 获取用户分页列表
        /// </summary>
        /// <param name="whereStr"></param>
        /// <param name="orderBy"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowsCount"></param>
        /// <returns></returns>
        public List<UserModel> GetUserList(string whereStr, string orderBy, int currentPage, int pageSize, ref int rowsCount)
        {
            var list = new List<UserModel>();
            string sqlCount = "select count(*) as totals from [User]";
            if (!string.IsNullOrEmpty(whereStr))
            {
                sqlCount = sqlCount + " where " + whereStr;
            }
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocal, CommandType.Text, sqlCount);
            if (reader.Read())
            {
                rowsCount = reader["totals"] != DBNull.Value ? Convert.ToInt32(reader["totals"]) : 0;
            }
            reader.Close();
            var sqlPage = "select (ROW_NUMBER() OVER(ORDER BY " + orderBy + ")) AS rownum, [ID],[UserName],[RealName],[AnotherName],[Mobile],[RegTime],[LastLoginTime],[IsLock],[UpdateTime],[RoleID],[Channels] from [User]";
            if (!string.IsNullOrEmpty(whereStr))
            {
                sqlPage = sqlPage + " where " + whereStr;
            }
            var startIndex = (currentPage - 1) * pageSize + 1;
            sqlPage = "Select [ID],[UserName],[RealName],[AnotherName],[Mobile],[RegTime],[LastLoginTime],[IsLock],[UpdateTime],[RoleID],[Channels] from (" + sqlPage + ") tmp where rownum between " + startIndex + " and " + currentPage * pageSize;
            reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocal, CommandType.Text, sqlPage);
            while (reader.Read())
            {
                var info = GetUserModel(reader);
                list.Add(info);
            }
            reader.Close();
            return list;
        }

        private static UserModel GetUserModel(SqlDataReader dr)
        {
            var model = new UserModel
                {
                    ID = ConvertHelper.ToInt(dr["ID"].ToString()),
                    UserName = dr["UserName"].Equals(DBNull.Value) ? "" : dr["UserName"].ToString(),
                    RealName = dr["RealName"].Equals(DBNull.Value) ? "" : dr["RealName"].ToString(),
                    AnotherName = dr["AnotherName"].Equals(DBNull.Value) ? "" : dr["AnotherName"].ToString(),
                    Mobile = dr["Mobile"].Equals(DBNull.Value) ? "" : dr["Mobile"].ToString(),
                    RegTime = dr["RegTime"].Equals(DBNull.Value) ? DateTime.Now : ConvertHelper.ToDateTime(dr["RegTime"].ToString()),
                    LastLoginTime = dr["LastLoginTime"].Equals(DBNull.Value) ? DateTime.Now : ConvertHelper.ToDateTime(dr["LastLoginTime"].ToString()),
                    IsLock = ConvertHelper.ToBool(dr["IsLock"].ToString()),
                    UpdateTime = dr["UpdateTime"].Equals(DBNull.Value) ? DateTime.Now : ConvertHelper.ToDateTime(dr["UpdateTime"].ToString()),
                    RoleId = dr["RoleID"].Equals(DBNull.Value) ? "" : dr["RoleID"].ToString(),
                    Channels = dr["Channels"].Equals(DBNull.Value) ? "" : dr["Channels"].ToString()
                };
            return model;
        }
    }
}
