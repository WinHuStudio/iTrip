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
using MongoDB.Repository;

namespace iTrip.Service.Business.Message.PackageReception
{
    public class PackageDealer : SuperBllService, IPackageDealer
    {
        private void CheckHolder(string account)
        {
            var resp_holder = GetRespository<Holder>();
            if (resp_holder.Exists(h => h.Account == account))
                return;
            resp_holder.Save(new Holder(account));
        }

        public List<IPackage> PickPackage(string holder, DateTime LastPickTime)
        {
            try
            {
                var resp_holding = GetRespository<PackageHolding>();

                string[] packageids = resp_holding.Select(h => h.Account == holder && h.CreationTime >= LastPickTime).Select(p => p.PackageId).ToArray();


                var packages = GetRespository<iTripPackage>().Select(p => p.Time > LastPickTime).Where(p => packageids.Contains(p.Id)).Select(p => p.ToTransferPackage()).ToList();
                return packages;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<IPackage>();
            }
            //IPackageDealer pacakgeDealer = new PackageDealer();
            //return pacakgeDealer.PickPackage(holder, LastPickTime);
        }

        public MongoDBRef SavePackage(IPackage package)
        {
            var ipackage = new iTripPackage(package);
            GetRespository<iTripPackage>().Save(ipackage);
            //CheckHolder(package.PR);
            //GetRespository<PackageHolding>().Save(new PackageHolding(
            return ipackage.ToDBRef();
        }

        public int DealPackage(MongoDBRef package, string[] holders)
        {
            IHolderResolver holderResolver = new HolderResolver();
            return holderResolver.AttachPackage(holders, package);
        }
    }
}
