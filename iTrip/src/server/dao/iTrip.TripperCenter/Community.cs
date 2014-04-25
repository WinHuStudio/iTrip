using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace iTrip.TripperCenter
{
    /// <summary>
    /// 团体账号
    /// </summary>
    public class Community : ComAccount
    {
        /// <summary>
        /// 构造函数，用于数据库操作，不建议逻辑层使用
        /// </summary>
        public Community()
        { }

        /// <summary>
        /// 构造函数，用户客户端创建
        /// </summary>
        /// <param name="master">创建人账号</param>
        public Community(string master)
        {
            if (string.IsNullOrEmpty(master))
                throw new Exception("master and member can not be null in Community");
            Master = master;
            Account = string.Format("{0}{1}{2}", GlobalConst.CodeAccountPreFlag_Community, Id, master);
        }
    }
}
