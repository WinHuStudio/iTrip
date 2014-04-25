using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Repository;

namespace iTrip.DeliveryCenter
{
    /// <summary>
    /// 消息持有者（即发送方/接收方）
    /// </summary>
    public class Holder : DEntity
    {
        public Holder() { }
        public Holder(string account)
        {
            Account = account;
            LastPickTime = DateTime.MinValue;
        }

        [BsonIndex]
        public string Account { get; set; }

        public DateTime LastPickTime { get; set; }
    }
}
