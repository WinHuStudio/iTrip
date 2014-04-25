using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.TripperCenter;
using MongoDB.Repository;

namespace iTrip.ModelInitializer.UserCenter
{
    public class UserCenterDBContext : MongoDBContext
    {
        public UserCenterDBContext() : base("UserCenterDBContext") { }
        public override void OnRegisterModel(ITypeRegistration registration)
        {
            registration.RegisterType<Passport>().RegisterType<Profile>();
        }
    }
}
