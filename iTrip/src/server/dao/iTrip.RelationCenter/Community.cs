using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace iTrip.RelationCenter
{
    public class Community : ComAcc
    {
        public Community() :
            base(GlobalConst.CodeAccountPreFlag_Community)
        { }
    }
}
