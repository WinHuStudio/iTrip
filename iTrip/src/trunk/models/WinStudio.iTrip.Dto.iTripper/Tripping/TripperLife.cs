using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WinStudio.iTrip.Dto.iTripper.Tripping
{
    public class TripperLife : TripBase
    {
        public List<MongoDBRef> Plans { get; set; }
    }
}
