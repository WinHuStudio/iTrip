using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace iTrip.DeliveryCenter
{
    public class DeliveryCenterDBContext : MongoDBContext
    {
        public DeliveryCenterDBContext() : base("DeliveryCenterDBContext") { }

        public override void OnRegisterModel(ITypeRegistration registration)
        {
            registration.RegisterType<iTripPackage>().RegisterType<Content>();
            registration.RegisterType<Holder>().RegisterType<PackageHolding>();
        }
    }
}
