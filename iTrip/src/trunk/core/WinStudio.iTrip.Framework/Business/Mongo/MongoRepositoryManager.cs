using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Repository;
using WinStudio.iTrip.Framework.IBusiness.Mongo;

namespace WinStudio.iTrip.Framework
{
    public class MongoRepositoryManager : IMongoRepositoryManager
    {
        public void RegisterMongoDBContext()
        {
            foreach (Type type in WinAssemblyUtility.GetAssembly<IMongoDBContext>().FindTypes<IMongoDBContext>())
            {
                if (type.IsAbstract) continue;
                var context = Activator.CreateInstance(type) as MongoDBContext;
                MongoDBRepository.RegisterMongoDBContext(context);
            }
        }
        private static IMongoRepositoryManager _instance = new MongoRepositoryManager();
        public static IMongoRepositoryManager Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
