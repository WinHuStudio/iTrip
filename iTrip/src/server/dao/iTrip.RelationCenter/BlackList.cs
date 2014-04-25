using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.RelationCenter
{
    /// <summary>
    /// 黑名单
    /// </summary>
    public class BlackList : REntity
    {
        /// <summary>
        /// 账户号
        /// </summary>
        public string Accounts { get; set; }
    }
}
