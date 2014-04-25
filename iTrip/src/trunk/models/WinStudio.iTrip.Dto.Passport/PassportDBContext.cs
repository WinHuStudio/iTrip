using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace WinStudio.iTrip.Dto.Passport
{
    public class PassportDBContext : MongoDBContext
    {
        public PassportDBContext() : base("PassportDBContext") { }

        public override void OnRegisterModel(ITypeRegistration registration)
        {
            registration.RegisterType<Passport>().RegisterType<Profile>();
            registration.RegisterType<Nationality>().RegisterType<GlobalRegion>().RegisterType<NativePlace>();
            registration.RegisterType<UserIcon>().RegisterType<Level>();
            registration.RegisterType<LoginHistory>();
        }
    }
}
