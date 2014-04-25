using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;
using MongoDB.Driver;
using MongoDB.Repository;

namespace iTrip.RelationCenter
{
    public class Group : ComAcc
    {
        public Group()
            : this(null, null)
        { }
        public Group(string account, string name)
            : this(account, name, null)
        {
        }
        public Group(string account, string name, Member[] members)
            : base(GlobalConst.CodeAccountPreFlag_Publisher)
        {
            Account = account;
            Name = name;
            Members.AddRange(members);
        }
    }
}
