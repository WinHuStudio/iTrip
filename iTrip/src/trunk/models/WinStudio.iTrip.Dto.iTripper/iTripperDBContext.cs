using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;
using WinStudio.iTrip.Dto.iTripper.Location;
using WinStudio.iTrip.Dto.iTripper.Tripping;

namespace WinStudio.iTrip.Dto.iTripper
{
    public class iTripperDBContext : MongoDBContext
    {
        public iTripperDBContext() : base("iTripperDBContext") { }

        public override void OnRegisterModel(ITypeRegistration registration)
        {
            registration.RegisterType<Tripper>();
            registration.RegisterType<TripperLife>().RegisterType<TripPlan>().RegisterType<TripPoint>();
            registration.RegisterType<Continent>().RegisterType<Nation>().RegisterType<City>().RegisterType<Spot>();
            //registration.RegisterType<LocationRefer>().RegisterType<LocationSnapshoot>();
        }
    }
}
