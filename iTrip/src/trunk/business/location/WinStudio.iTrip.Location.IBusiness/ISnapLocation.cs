using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStudio.iTrip.Location.IBusiness
{
    public interface ISnapLocation
    {
        string Account { get; set; }

        string Name { get; set; }

        double Longitude { get; set; }

        double Latitude { get; set; }

        //ILocationLonLat LonLat { get; set; }

        int Nation { get; set; }

        int City { get; set; }

        DateTime Time { get; set; }

        void UpdateLonLat(double lon, double lat);

        List<ILocationLonLat> GetTrace();

    }

    public interface ILocationLonLat
    {
        double Longitude { get; set; }

        double Latitude { get; set; }

        DateTime Time { get; set; }

    }
}
