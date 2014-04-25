using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.iPP.Proxy
{
    public class ipp_Header
    {
        private byte[] _headers;
        public ipp_Header(byte[] headers)
        {
            _headers = headers;
        }
        private int GetInt(int startIndex, int count = 1)
        {
            return _headers[startIndex];
            //return BitConverter.ToInt32(_headers.Take(count).Skip(startIndex).ToArray(), 0);
        }
        public int IPPV
        {
            get
            {
                return GetInt(0);// Encoding.UTF8.GetString(_headers, 0, 1).ToInt();
            }
        }
        public int PT
        {
            get
            {
                return GetInt(1);// Encoding.UTF8.GetString(_headers, 1,1).ToInt();
            }
        }
        public int PCT
        {
            get
            {
                return GetInt(2);// Encoding.UTF8.GetString(_headers, 2, 1).ToInt();
            }
        }
        public int PCL
        {
            get
            {
                return GetInt(3);// Encoding.UTF8.GetString(_headers, 3, 1).ToInt();
            }
        }
        public int PS
        {
            get
            {
                return GetInt(4);// Encoding.UTF8.GetString(_headers, 4, 1).ToInt();
            }
        }
        public int PR
        {
            get
            {
                return GetInt(5);// Encoding.UTF8.GetString(_headers, 5, 1).ToInt();
            }
        }
        public int PCN
        {
            get
            {
                return GetInt(6);// Encoding.UTF8.GetString(_headers, 6, 1).ToInt();
            }
        }
    }
}
