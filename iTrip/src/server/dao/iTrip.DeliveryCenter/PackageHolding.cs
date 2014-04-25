using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.DeliveryCenter
{
    public class PackageHolding : DEntity
    {
        public PackageHolding() { }
        public PackageHolding(string holder, string packageId)
        {
            Account = holder;
            PackageId = packageId;
            CreationTime = DateTime.Now;
        }

        public string Account { get; set; }

        public string PackageId { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
