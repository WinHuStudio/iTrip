using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.Dto.iTripper.PhotoGraph;
using WinStudio.iTrip.Dto.iTripper.Setting;

namespace WinStudio.iTrip.Dto.iTripper.Snap
{
    public class SnapTripper : TripBase
    {
        public string Name { get; set; }

        public string Account { get; set; }

        public TripperLevel Level { get; set; }

        public SnapPic Photo { get; set; }
    }
}
