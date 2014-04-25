using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.Dto.iTripper.Location;

namespace WinStudio.iTrip.Dto.iTripper.Tripping
{
    public class TripPoint : TripBase
    {
        public DateTime TBeginning { get; set; }

        public DateTime TEnding { get; set; }

        public Spot Spot { get; set; }

        public TripPoint Prev { get; set; }

        public TripPoint Next { get; set; }
    }
}
