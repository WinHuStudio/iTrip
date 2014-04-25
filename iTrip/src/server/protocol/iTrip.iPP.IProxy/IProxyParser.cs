using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.iPP.IProxy
{
    public interface IProxyParser
    {
        string Version { get; }

        bool CanParse(string ippv);

        IPackage Parse(string packagebody);
        IPackage Parse(byte[] packagebodybyte);
        void Parse(string packagebody, IPackage package);
        void Parse(byte[] packagebodybyte, IPackage package);

        //string ToIPPBody(ipp_Package package);
        byte[] ToIPPBody(IPackage package);
    }
}
