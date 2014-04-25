using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.RelationCenter
{
    [ServiceContract]
    public class Member
    {
        public Member()
            : this(null, null)
        { }
        public Member(string account, string name)
        {
            Account = account;
            Name = name;
        }
        /// <summary>
        /// 账号
        /// </summary>
        [DataMember]
        public string Account { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 个性昵称
        /// </summary>
        [DataMember]
        public string Nick { get; set; }
    }
}
