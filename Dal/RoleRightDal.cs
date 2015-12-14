using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conn;

namespace Dal
{
    public class RoleRightDal
    {
        /// <summary>
        /// 根据角色ID（含多个角色）与栏目ID获取该角色对该栏目所拥有的操作权限
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="columnId">栏目ID</param>
        /// <returns></returns>
        public string GetRightListByRoleIdAndCid(string roleId, int columnId)
        {
            var rightStr = string.Empty;
            var strSql = new StringBuilder();
            strSql.Append(" select RightID from RoleRight RR left join [Right] R on RR.RightID=R.ID ");
            strSql.Append(" WHERE RR.ColumnID=" + columnId + " AND RoleID in(select value from [dbo].[fun_SplitToTable]('" + roleId + "',',')) AND R.Visible=1 GROUP BY RightID");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@RoleID", SqlDbType.NVarChar) {Value = roleId},
                    new SqlParameter("@ColumnID", SqlDbType.Int) {Value = columnId}
                };

            var ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(),parameters);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (rightStr.Length <= 0)
                    {
                        rightStr = dr["RightID"].ToString();
                    }
                    else
                    {
                        rightStr += "|" + dr["RightID"];
                    }
                }
            }
            return rightStr;
        }


        /// <summary>
        /// 根据角色ID获取角色所有权限字符串形式
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public string GetRoleRightStr(int roleId)
        {
            string rightStr = string.Empty;
            var strSql = new StringBuilder();
            strSql.Append("select ColumnID,RightID ");
            strSql.Append(" FROM [RoleRight] where RoleID=@RoleID");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@RoleID", SqlDbType.Int) {Value = roleId}
                };
            var ds = SqlHelper.ExecuteDataSet(SqlHelper.ConnectionStringLocal, CommandType.Text, strSql.ToString(),
                                              parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (rightStr.Length <= 0)
                    {
                        rightStr = dr["ColumnID"] + "|" + dr["RightID"];
                    }
                    else
                    {
                        rightStr += "," + dr["ColumnID"] + "|" + dr["RightID"];
                    }
                }
            }
            return rightStr;
        }
    }
}
