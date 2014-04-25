using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.DeliveryCenter;
using iTrip.iPP.IProxy;
using iTrip.Service.Business.Message.IPackageReception;
using iTrip.Service.Common;
using MongoDB.Driver;

namespace iTrip.Service.Business.Message.PackageReception
{
    public class HolderResolver : SuperBllService, IHolderResolver
    {
        //public StandardResult ParserHolders(string[] holderAccounts)
        //{
        //    if (holderAccounts == null || holderAccounts.Length == 0) return Result(iTripExceptionCode.Error_Null_Reference);
        //    var resp = GetRespository<Holder>();
        //    var holders = resp.Select(h => holderAccounts.Contains(h.Account)).ToList();
        //    if (holders.Count == holderAccounts.Length)
        //        return Result(holders);
        //    List<Holder> hs = new List<Holder>();
        //    holderAccounts.ForEach(delegate(string acc)
        //    {
        //        if (!holders.Any(h => h.Account == acc))
        //            hs.Add(new Holder(acc));
        //    });
        //    resp.Insert(hs);
        //    hs.AddRange(holders);
        //    return Result(hs);
        //}

        public int AttachPackage(string[] holders, MongoDBRef package)
        {
            if (holders == null || holders.Length == 0) return 0;
            List<PackageHolding> phs = new List<PackageHolding>();

            holders.ForEach(a => phs.Add(new PackageHolding(a, package.Id.AsString)));
            GetRespository<PackageHolding>().Insert(phs);
            return phs.Count;
        }


        public void RegisterTripper(string account, string ticket)
        {
            if (string.IsNullOrEmpty(account)) return;
            if (GetRespository<Holder>().Exists(o => o.Account == account)) return;
            GetRespository<Holder>().Save(new Holder(account));
        }
    }
}
