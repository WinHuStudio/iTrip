using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Repository;

namespace iTrip.RelationCenter
{

    public class Person : ComAcc
    {
        public Person() : this(null) { }

        public Person(string account)
            : base(string.Empty)
        {
            Account = account;
            Friends = new List<Member>();
            Groups = new List<MongoDBRef>();
        }

        [BsonIgnore]
        public override List<Member> Members
        {
            get
            {
                return base.Members;
            }
            set
            {
                base.Members = value;
            }
        }

        public int PhoneNumber { get; set; }

        public List<Member> Friends { get; set; }

        public List<MongoDBRef> Groups { get; set; }
    }
}
