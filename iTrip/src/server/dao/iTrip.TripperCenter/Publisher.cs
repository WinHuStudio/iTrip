using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace iTrip.TripperCenter
{
    public class ComAccount : UEntity
    {
        [BsonIndex]
        public string Master { get; set; }

        public string CreationTime { get; set; }
    }
    /// <summary>
    /// 订阅账号
    /// </summary>
    public class Publisher : ComAccount
    {
        /// <summary>
        /// 构造函数，用于数据库操作，不建议逻辑层使用
        /// </summary>
        public Publisher()
        { }

        /// <summary>
        /// 构造函数，用户客户端创建
        /// </summary>
        /// <param name="master">创建人账号</param>
        public Publisher(string master)
        {
            if (string.IsNullOrEmpty(master))
                throw new Exception("master and member can not be null in Publisher");
            Master = master;
            Account = string.Format("{0}{1}{2}", GlobalConst.CodeAccountPreFlag_Publisher, Id, master);
        }
    }
}
