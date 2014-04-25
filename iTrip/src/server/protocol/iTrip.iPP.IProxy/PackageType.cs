using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.iPP.IProxy
{
    public enum PackageType
    {
        [Description("MessageNotification")]
        MN = 1314,
        [Description("MessageInstant")]
        MI = 1309,
        [Description("MessageInstantGlobal")]
        MIG = 130907,
        [Description("MessageInstantCall")]
        MIC = 130903,
        [Description("MessageInstantRelation")]
        MIR = 130918,
        [Description("MessageFoot")]
        MF = 1306,
        [Description("MessageLocation")]
        ML = 1311,
        [Description("DiscoveryFriend")]
        DF = 406,
        [Description("DiscoveryFriendRelation")]
        DFR = 40618,
        [Description("DiscoveryLocation")]
        DL = 412

    }
}
