using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.IProxy;
using iTrip.iPP.Proxy;

namespace iTrip.DeliveryCenter
{
    /// <summary>
    /// 包裹对象
    /// </summary>
    [DataContract]
    public class iTripPackage : DEntity
    {
        private IPackage _package;
        public iTripPackage() { }
        public iTripPackage(IPackage package)
        {
            _package = package;

            UID = package.UID;
            PType = package.PT;
            Sender = package.PS;
            Receiver = package.PR;
            Time = package.PD;
            IPPV = package.IPPV;
            PCC = package.PCC;

            Content = new Content();
            Content.CType = (PackageContentType)package.PCT;
            Content.FullName = package.PCN;
            Content.Summary = package.PC;
            Content.Length = package.PCL;
        }
        [DataMember]
        public Guid UID { get; set; }
        /// <summary>
        /// 包裹类型
        /// </summary>
        [DataMember]
        public int PType { get; set; }
        [DataMember]
        public string IPPV { get; set; }
        [DataMember]
        public string PCC { get; set; }

        [DataMember]
        public string Sender { get; set; }

        [DataMember]
        public string Receiver { get; set; }

        [DataMember]
        public Content Content { get; set; }

        [DataMember]
        public DateTime Time { get; set; }

        public IPackage ToTransferPackage()
        {
            IPackage package = new ipp_Package();
            package.IPPV = IPPV;
            package.PT = PType;
            package.PS = Sender;
            package.PR = Receiver;
            package.PD = Time;

            package.PCT = (int)Content.CType;
            //package.ExtName = Content.ExtName;
            package.PCN = Content.FullName;
            package.PC = Content.Summary;
            package.PCL = Content.Length;
            return package;
        }
    }
}
