using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.IProxy;

namespace iTrip.iPP.Proxy
{
    public class ipp_Body
    {
        public ipp_Body() : this(Encoding.UTF8) { }
        public ipp_Body(Encoding encoding)
        {
            _defEncoding = encoding;
        }
        public ipp_Body(byte[] body, Encoding encoding)
        {
            _body = body;
            _defEncoding = encoding;
        }
        private Encoding _defEncoding;
        private byte[] _body;

        public Guid GetUid(Indexes indexes)
        {
            return _body.Skip(indexes.Index).Take(indexes.Count).ToArray().FromiTripByteArray(_defEncoding);
            //return new Guid(Convert.FromBase64String(Encoding.Default.GetString(_body.Skip(indexes.Index).Take(indexes.Count).ToArray())));
            //return new Guid(_body.Skip(indexes.Index).Take(indexes.Count).ToArray());
            //Guid guid = Guid.Empty;
            //Guid.TryParse(Encoding.UTF8.GetString(_body, indexes.Index, indexes.Count), out guid);
            //return guid;
        }
        public DateTime GetDatetime(Indexes indexes)
        {
            return _defEncoding.GetString(_body, indexes.Index, indexes.Count).ToDateTime("yyyyMMddHHmmss");
        }
        public int GetInt(Indexes indexes)
        {
            return BitConverter.ToInt32(_body.Skip(indexes.Index).Take(indexes.Count).ToArray(), 0);
            //return Encoding.Default.GetString(_body, indexes.Index, indexes.Count).ToInt();
        }
        public string GetString(Indexes indexes)
        {
            return _defEncoding.GetString(_body, indexes.Index, indexes.Count);
        }
    }

    public class DatatimeFormatProvider : IFormatProvider
    {
        public object GetFormat(Type formatType)
        {
            return "yyyyMMddHHmmss";
        }
    }

    public class Indexes
    {
        private int _index = 0;
        private int _count = 0;
        public Indexes(int index, int count)
        {
            _index = index;
            _count = count;
        }

        public int Index { get { return _index; } }
        public int Count { get { return _count; } }

        public Indexes Next(int count)
        {
            _index += _count;
            _count = count;
            return this;
        }
    }
}
