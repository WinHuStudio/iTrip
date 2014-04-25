using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTrip.Model.Settings;

namespace iTrip.TransferCenter
{
    public interface ITripPackage
    {
        /// <summary>
        /// 包裹类型
        /// </summary>
        public PackageType PType { get; set; }

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public Content Content { get; set; }

        public DateTime Time { get; set; }
    }

}
