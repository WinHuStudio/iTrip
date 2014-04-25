using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WinStudio.iTrip.Dto.iTripper.Snap
{
    public abstract class SnapRefer : TripBase
    {
        public string Summary { get; set; }

        public string Description { get; set; }

        public List<MongoDBRef> Shootes { get; set; }
    }

    public abstract class SnapVotingRefer : VotingBase
    { }
}
