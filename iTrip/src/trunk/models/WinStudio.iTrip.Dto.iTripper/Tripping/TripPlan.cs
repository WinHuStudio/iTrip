using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WinStudio.iTrip.Dto.iTripper.Tripping
{
    public class TripPlan : TripBase
    {
        public DateTime TBeginning { get; set; }

        public DateTime TEnding { get; set; }

        public List<MongoDBRef> Points { get; set; }
    }
}
