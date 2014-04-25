using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace iTrip.RelationCenter
{
    public class Publisher : ComAcc
    {
        public Publisher()
            : base(GlobalConst.CodeAccountPreFlag_Publisher)
        { }
    }
}
