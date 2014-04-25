using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace iTrip.TripperCenter
{
    public class TripperCenterDBContext : MongoDBContext
    {
        public TripperCenterDBContext() : base("TripperCenterDBContext") { }

        public override void OnRegisterModel(ITypeRegistration registration)
        {
            registration.RegisterType<PassPhrase>().RegisterType<Profile>();
            registration.RegisterType<Group>().RegisterType<Organization>().RegisterType<Community>();
            registration.RegisterType<SnapProfile>();
        }
    }
}
