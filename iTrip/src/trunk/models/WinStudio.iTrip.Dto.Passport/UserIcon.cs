using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace WinStudio.iTrip.Dto.Passport
{
    public class iTripFile : UIBaseEntity
    {
        public static IMongoFile Instance<TMongoFile>(string fileid) where TMongoFile : UIFileEntity
        {
            return MongoEntity.LoadFile<TMongoFile>(fileid);
        }
    }

    public class UserIcon : UIFileEntity
    {

    }
}
