using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStudio.iTrip.Location.IBusiness
{
    public interface ILocationCollector
    {
        void GatherLocation(string account, string name, double lon, double lat, int nation, int city);

        void UpdateLocation(string account, double lon, double lat);

        List<ISnapLocation> GetLocations(int nation, int city);

        List<ISnapLocation> GetLocations(int nation, int city, Func<ISnapLocation, bool> expression);
    }
}
