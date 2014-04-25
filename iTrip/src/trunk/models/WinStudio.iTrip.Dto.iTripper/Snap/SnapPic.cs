using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WinStudio.iTrip.Dto.iTripper.PhotoGraph
{
    public class SnapPic : TripBase
    {
        public string Url { get; set; }

        public MongoDBRef Photo { get; set; }
    }
}
