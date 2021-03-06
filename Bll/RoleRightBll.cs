﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Bll
{
    public class RoleRightBll
    {
        private readonly RoleRightDal _roleRightDal = new RoleRightDal();

        /// <summary>
        /// 根据角色ID（含多个角色）与栏目ID获取该角色对该栏目所拥有的操作权限
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="columnId">栏目ID</param>
        /// <returns></returns>
        public string GetRightListByRoleIdAndCid(string roleId, int columnId)
        {
            return _roleRightDal.GetRightListByRoleIdAndCid(roleId, columnId);
        }

        /// <summary>
        /// 根据角色ID获取角色所有权限字符串形式
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public string GetRoleRightStr(int roleId)
        {
            return _roleRightDal.GetRoleRightStr(roleId);
        }

    }
}
