using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.Dto.iTripper.Snap;

namespace WinStudio.iTrip.Dto.iTripper.Tripping
{
    public class TripReview : TripBase
    {
        public string Contenet { get; set; }

        public SnapTripper Reviewer { get; set; }
    }
}
