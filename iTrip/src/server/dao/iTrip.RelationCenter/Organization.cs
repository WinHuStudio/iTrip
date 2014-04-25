using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace iTrip.RelationCenter
{
    public class Organization : ComAcc
    {
        public Organization(string master)
            : base(GlobalConst.CodeAccountPreFlag_Organization)
        { }
    }
}
