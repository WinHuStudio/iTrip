using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Repository;

namespace WinStudio.iTrip.Dto.iTripper.Tripping
{

    public class Tripper : TripBase
    {
        public MongoDBRef Snap { get; set; }

        public TripperLife TripLife { get; set; }
    }
}
