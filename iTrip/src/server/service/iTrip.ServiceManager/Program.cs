using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using iTrip.DeliveryCenter;
using iTrip.Model;
using iTrip.RelationCenter;
using iTrip.Service.Wcf.Message.IPublisherIM;
using iTrip.Service.Wcf.Passport.IAuthentication;
using iTrip.StatusCenter;
using iTrip.TripperCenter;
using MongoDB.Repository;
using WinStudio.WcfManager;

namespace iTrip.ServiceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDBRepository.RegisterMongoDBContext(new TripperCenterDBContext());
            MongoDBRepository.RegisterMongoDBContext(new DeliveryCenterDBContext());
            MongoDBRepository.RegisterMongoDBContext(new StatusCenterDBContext());
            MongoDBRepository.RegisterMongoDBContext(new RelationCenterDBContext());
            MongoDBRepository.RegisterMongoIndex();

            var ass = WinAssemblyUtility.GetAssembly();
            HostInfo host = new HostInfo(ConfigurationManager.AppSettings["WcfHostAddress"]).LoadTypesFromAssemblies(ass);
            using (ServiceContainer container = new ServiceContainer())
            {
                container.Open(host);
                Console.WriteLine("press close to stop host");

                while (true)
                {
                    if ("close" == Console.ReadLine().ToLower())
                    {
                        container.Close(host);
                        break;
                    }
                }
                Console.WriteLine("press 'Enter' to quit");
                Console.ReadKey();
            }
        }
    }
}
