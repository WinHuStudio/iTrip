using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace iTrip.StatusCenter
{
    public class StatusCenterDBContext : MongoDBContext
    {
        public StatusCenterDBContext() : base("StatusCenterDBContext") { }
        public override void OnRegisterModel(ITypeRegistration registration)
        {
            registration.RegisterType<One>();
        }
    }
}
