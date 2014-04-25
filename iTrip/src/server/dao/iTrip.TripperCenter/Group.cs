using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;
using MongoDB.Driver;
using MongoDB.Repository;

namespace iTrip.TripperCenter
{
    /// <summary>
    /// 群组
    /// </summary>
    public class Group : UEntity
    {
        /// <summary>
        /// 构造函数，用于数据库操作，不建议逻辑层使用
        /// </summary>
        public Group()
        { }

        /// <summary>
        /// 构造函数，用户客户端创建群组
        /// </summary>
        /// <param name="master">创建人账号</param>
        /// <param name="member">首次创建所带的组员</param>
        public Group(string master)
        {
            Master = master;
            Account = string.Format("{0}{1}_{2}", GlobalConst.CodeAccountPreFlag_Group, master, Id);
        }

        /// <summary>
        /// 群组创建者
        /// </summary>
        [BsonIndex]
        public string Master { get; set; }

        /// <summary>
        /// 群组名称
        /// </summary>
        public string Title { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
