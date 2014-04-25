using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.Proxy;
using iTrip.Service.Business.Message.IPackageReception;
using iTrip.Service.Business.Message.PackageReception;
using iTrip.Service.Common.Wcf;
using iTrip.Service.Wcf.Message.IPublisherIM;
using iTrip.Service.Wcf.Relation.ITripperRelationShipResolver;

namespace iTrip.Service.Wcf.Message.PublisherIM
{
    [WinWcfService]
    public class PackageDelivery : SuperWcfService, IPackageDelivery
    {
        public void PackageDeliveryToServer(ipp_Package package)
        {
            IRecipientResolver resolver = GetService<IRecipientResolver>();
            var ret = resolver.ParseRecipients(package.PR);
            if (!ret.Ret) return;

            IPackageDealer dealer = new PackageDealer();
            var refpackage = dealer.SavePackage(package);
            var receivers = ret.Obj as string[];
            var count = dealer.DealPackage(refpackage, receivers);
            //return Result(count > 0, receivers.Length == count ? "" : (receivers.Length - count) + "个用户未能派送包裹");
        }

        public StandardResult PackageDeliveryToClient(string account, DateTime lastTime)
        {
            IPackageDealer dealer = new PackageDealer();
            return Result(dealer.PickPackage(account, lastTime));
        }
        
        public void RegisterTripper(string account, string ticket)
        {
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(ticket)) return;
            IHolderResolver holder = new HolderResolver();
            holder.RegisterTripper(account, ticket);
        }
    }
}
