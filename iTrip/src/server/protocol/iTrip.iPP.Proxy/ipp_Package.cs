using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.IProxy;

namespace iTrip.iPP.Proxy
{
    [DataContract]
    public class ipp_Package : IPackage
    {
        Encoding _defEncoding = Encoding.UTF8;
        private IProxyParser parser = new ProxyPraser(Encoding.UTF8);
        private byte[] bodybytes;
        public ipp_Package() { }
        public ipp_Package(string body)
        {
            parser.Parse(body, this);
        }
        public ipp_Package(byte[] body)
        {
            bodybytes = body;
            parser.Parse(body, this);
        }
        public ipp_Package(string ps, string pc, PackageType pt, PackageContentType pct, string pr, string pcn, string ippv)
        {
            PS = ps;
            PC = _defEncoding.GetBytes(pc);
            PCL = PC.Length;
            PR = pr;
            PCT = (int)pct;
            PT = (int)pt;
            PCN = pcn;
            IPPV = ippv;

            UID = Guid.NewGuid();
            PD = DateTime.Now;
        }
        public ipp_Package(Guid uid, DateTime pd, string ps, string pc, PackageType pt, PackageContentType pct, string pr, string pcn, string ippv)
        {
            PS = ps;
            PC = _defEncoding.GetBytes(pc);
            PCL = PC.Length;
            PR = pr;
            PCT = (int)pct;
            PT = (int)pt;
            PCN = pcn;
            IPPV = ippv;

            UID = uid;
            PD = pd;
        }

        [DataMember]
        public Guid UID { get; set; }

        [DataMember]
        public int PT { get; set; }

        [DataMember]
        public string PS { get; set; }

        [DataMember]
        public string PR { get; set; }

        [DataMember]
        public DateTime PD { get; set; }

        [DataMember]
        public byte[] PC { get; set; }

        [DataMember]
        public int PCT { get; set; }

        [DataMember]
        public string PCN { get; set; }

        [DataMember]
        public int PCL { get; set; }

        [DataMember]
        public string PCC { get; set; }

        [DataMember]
        public string IPPV { get; set; }

        public byte[] ToOrginBytes()
        {
            if (bodybytes == null || bodybytes.Length == 0)
                bodybytes = parser.ToIPPBody(this);
            return bodybytes;
        }
        public byte[] GetUidBytes()
        {
            return UID.ToiTripByteArray(_defEncoding);
        }

        public byte[] ReceivedResultBytes()
        {
            if (IsValid())
                return UID.ToiTripByteArray(_defEncoding);
            var lst = new List<byte>();
            lst.AddRange(UID.ToiTripByteArray(_defEncoding));
            lst.Add(1);
            return lst.ToArray();
        }

        public bool IsValid()
        {
            int pd;
            Int32.TryParse(PD.ToString("ddHHmmss"), out pd);
            var a = (pd | PCL);
            var b = PT | PCT;
            var c = a | b;
            return PCC == c.ToLitString(6);// ToL6S(c);
            //return PCC == c;
            //return PCC == ((pd | PCL) | ((int)PT | PCL));
        }



        public byte[] ToServerBytes()
        {
            List<byte> cmd = new List<byte>();
            if (PT >= (int)PackageType.MI && PT <= (int)PackageType.MIR)
            {
                cmd.AddRange(_defEncoding.GetBytes("ipp_MSG "));
            }
            byte[] body = parser.ToIPPBody(this);
            cmd.AddRange(body);
            return cmd.ToArray();
        }

        public byte[] ToClientBytes()
        {
            return parser.ToIPPBody(this);
        }

        public byte[] ToServerResultBytes(string err = null)
        {
            if (IsValid())
                return UID.ToiTripByteArray(_defEncoding);
            var ret = UID.ToiTripByteArray(_defEncoding).ToList();
            ret.AddRange(_defEncoding.GetBytes(err ?? "Error"));
            return ret.ToArray();
        }


        public T GetContent<T>() where T : class
        {
            if (PCT == (int)PackageContentType.T)
            {
                return _defEncoding.GetString(PC) as T;
            }
            return null;
        }
    }

}
