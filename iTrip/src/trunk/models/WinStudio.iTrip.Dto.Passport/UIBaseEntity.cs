using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;
using WinStudio.iTrip.Models;

namespace WinStudio.iTrip.Dto.Passport
{
    public class UIBaseEntity : iTripBaseEntity
    {
        public override string LoggerCode
        {
            get { return Id; }
        }
    }

    public class UIFileEntity : MongoFile
    {
    }
}
