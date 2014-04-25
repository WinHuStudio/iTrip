using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using WinStudio.iTrip.Dto.iTripper.Snap;

namespace WinStudio.iTrip.Dto.iTripper
{
    public class TripCompanion : TripBase
    {
        public SnapTripper Creator { get; set; }

        public List<MongoDBRef> TripperSnaps { get; set; }
    }
}
