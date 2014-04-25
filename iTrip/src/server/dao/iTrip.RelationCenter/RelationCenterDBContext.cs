using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace iTrip.RelationCenter
{
    public class RelationCenterDBContext : MongoDBContext
    {
        public RelationCenterDBContext() : base("RelationCenterDBContext") { }

        public override void OnRegisterModel(ITypeRegistration registration)
        {
            registration.RegisterType<Person>().RegisterType<Group>().RegisterType<Organization>().RegisterType<Community>();
            registration.RegisterType<Application>();
        }
    }
}
