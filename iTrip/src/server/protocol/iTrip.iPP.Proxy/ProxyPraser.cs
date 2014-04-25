using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.IProxy;

namespace iTrip.iPP.Proxy
{
    public class ProxyPraser : IProxyParser
    {
        public ProxyPraser() : this(Encoding.UTF8) { }
        public ProxyPraser(Encoding encoding)
        {
            _defEncoding = encoding;
        }
        private Encoding _defEncoding;

        private const int min_body_header_length = 10;
        private const int min_body_byte_length = 74;
        public IPackage Parse(string packagebody)
        {
            if (string.IsNullOrEmpty(packagebody))
                return null;
            byte[] body_bytes = Convert.FromBase64String(packagebody);
            if (body_bytes.Length <= min_body_byte_length) return null;

            return Parse(body_bytes);
        }

        public IPackage Parse(byte[] packagebodybyte)
        {
            ipp_Package package = new ipp_Package();
            Parse(packagebodybyte, package);
            return package;
        }

        //public string ToIPPBody(ipp_Package package)
        //{
        //    throw new NotImplementedException();
        //}

        List<byte> _byte_content;
        List<byte> _byte_header;
        public byte[] ToIPPBody(IPackage package)
        {
            _byte_content = new List<byte>();
            _byte_header = new List<byte>();

            //var pc = Encoding.UTF8.GetBytes(_pc);
            var ps = Encoding.UTF8.GetBytes(package.PS);
            var pr = Encoding.UTF8.GetBytes(package.PR);
            //PCC=(PD(ddHHmmss)|PCL)|(PT|PCT)
            package.PCC = ((package.PD.ToString("ddHHmmss").ToInt(0) | package.PCL) | ((int)package.PT | (int)package.PCT)).ToLitString();

            Build(package.PCC, false);
            Build(package.UID);
            Build(package.PD.ToString("yyyyMMddHHmmss"), false);
            Build(package.IPPV);
            Build((int)package.PT);
            Build((int)package.PCT);
            Build(package.PCL);
            Build(ps.Length, false);
            Build(pr.Length, false);
            Build(package.PCN);
            _byte_header.AddRange(new byte[] { 0, 0, 0 });
            _byte_header.AddRange(_byte_content);
            _byte_header.AddRange(ps);
            _byte_header.AddRange(pr);
            _byte_header.AddRange(package.PC);
            return _byte_header.ToArray();
        }

        private void Build(string c, bool h = true)
        {
            byte[] bytes = _defEncoding.GetBytes(c);
            _byte_content.AddRange(bytes);
            if (h)
                _byte_header.Add((byte)bytes.Length);
        }
        private void Build(int i, bool c = true)
        {
            if (i < 256 && !c)
                _byte_header.Add((byte)i);
            else
            {
                byte[] bytes = BitConverter.GetBytes(i);
                _byte_header.Add((byte)bytes.Length);
                if (c)
                    _byte_content.AddRange(bytes);
            }
        }
        private void Build(Guid uid)
        {
            byte[] bytes = uid.ToiTripByteArray(_defEncoding);// Encoding.UTF8.GetBytes(Convert.ToBase64String(uid.ToByteArray()));
            //_byte_header.Add((byte)bytes.Length);
            _byte_content.AddRange(bytes);
        }

        public void Parse(string packagebody, IPackage package)
        {
            if (string.IsNullOrEmpty(packagebody))
                return;
            byte[] body_bytes = _defEncoding.GetBytes(packagebody);
            if (body_bytes.Length <= min_body_byte_length) return;

            Parse(body_bytes, package);
        }

        public void Parse(byte[] packagebodybyte, IPackage package)
        {
            try
            {
                byte[] header = packagebodybyte.Take(min_body_header_length).ToArray();
                byte[] body = packagebodybyte.Skip(min_body_header_length).Take(packagebodybyte.Length - min_body_header_length).ToArray();

                ipp_Header ippheader = new ipp_Header(header);
                ipp_Body ippbody = new ipp_Body(body, _defEncoding);

                Indexes indexes = new Indexes(0, 6);

                package.PCC = ippbody.GetString(indexes);
                package.UID = ippbody.GetUid(indexes.Next(24));//ci + ippheader.PT + ippheader.PCT, ippheader.PCT);
                package.PD = ippbody.GetDatetime(indexes.Next(14));//ci + ippheader.PT + ippheader.PCT, ippheader.PCT);

                package.IPPV = ippbody.GetString(indexes.Next(ippheader.IPPV));//ci, ippheader.PT);
                package.PT = ippbody.GetInt(indexes.Next(ippheader.PT));//ci, ippheader.PT);
                package.PCT = ippbody.GetInt(indexes.Next(ippheader.PCT));//ci + ippheader.PT, ippheader.PCT);

                package.PCL = ippbody.GetInt(indexes.Next(ippheader.PCL));//ci + ippheader.PT + ippheader.PCT, ippheader.PCT);
                package.PS = ippbody.GetString(indexes.Next(ippheader.PS));//ci + ippheader.PT + ippheader.PCT + ippheader.PCL, ippheader.PS);
                package.PR = ippbody.GetString(indexes.Next(ippheader.PR));//ci + ippheader.PT + ippheader.PCT + ippheader.PCL + ippheader.PS, ippheader.PR);
                package.PCN = ippbody.GetString(indexes.Next(ippheader.PCN));//ci + ippheader.PT + ippheader.PCT + ippheader.PCL + ippheader.PS + ippheader.PR, ippheader.PS);
                package.PC = body.Skip(indexes.Index + indexes.Count).Take(body.Length - indexes.Index + indexes.Count).ToArray();//ci + ippheader.PT + ippheader.PCT + ippheader.PCL, ippheader.PCT);
            }
            catch (Exception e)
            {

            }
        }

        private void test()
        {
            string header = "07040202030300150000";
            Guid uid = Guid.NewGuid();
            DateTime pd = DateTime.Now;
            string body = "1.0.1.113092015winhyf你好出行者";
            int pcc = (Convert.ToInt32(pd.ToString("ddHHmmss")) | 15) | (1309 | 20);

            List<byte> lst = new List<byte>();
            lst.AddRange(Encoding.UTF8.GetBytes(header));
            lst.AddRange(Encoding.UTF8.GetBytes(pcc.ToLitString(6)));
            lst.AddRange(uid.ToByteArray());
            lst.AddRange(Encoding.UTF8.GetBytes(pd.ToString("yyyyMMddHHmmss")));
            lst.AddRange(Encoding.UTF8.GetBytes(body));

            var msg = Convert.ToBase64String(lst.ToArray());
            Console.WriteLine(msg);

            IPackage package = new ProxyPraser().Parse(msg);
            Console.WriteLine(package.UID);
            Console.WriteLine(package.IsValid());
        }


        public string Version
        {
            get { return "1.0.0.0"; }
        }

        public bool CanParse(string ippv)
        {
            return "1.0.0.1".Equals(ippv);
        }
    }
}
