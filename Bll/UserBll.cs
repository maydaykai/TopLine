using System.Collections.Generic;
using Dal;
using Model;

namespace Bll
{
    public class UserBll
    {
        private readonly UserDal _dal = new UserDal();
        /// <summary>
        /// 判断用户名是否已存在
        /// </summary>
        public bool Exists(string userName)
        {
            return _dal.Exists(userName);
        }

        //登陆验证
        public bool LoginValidate(ref UserModel fcmsUserModel)
        {
            return _dal.LoginValidate(ref fcmsUserModel);
        }

        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(UserModel model)
        {
            return _dal.Add(model);
        }

        /// <summary>
        /// 更新
        /// </summary>
        public bool Update(UserModel model)
        {
            return _dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserModel GetModel(int id)
        {
            return _dal.GetModel(id);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        public List<UserModel> GetFcmsUserList(string whereStr, string orderBy, int currentPage, int pageSize, ref int rowsCount)
        {
            return _dal.GetUserList(whereStr, orderBy, currentPage, pageSize, ref rowsCount);
        }
    }
}
