using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.ModelInitializer.UserCenter;
using MongoDB.Repository;

namespace iTrip.ModelInitializer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Press i to initialize data");
            Console.WriteLine("Press r to remove data");
            Console.WriteLine("Press any key to quit");

            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.KeyChar == 'i')
            {
                MongoDBRepository.RegisterMongoDBContext(new UserCenterDBContext());
                new UserCenterInitializer().Init();
            }
            if (key.KeyChar == 'r')
            {
                MongoDBRepository.RegisterMongoDBContext(new UserCenterDBContext());
                new UserCenterInitializer().Remove();
            }
        }
    }
}
