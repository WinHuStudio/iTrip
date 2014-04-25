using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using WinStudio.iTrip.Location.IBusiness;

namespace WinStudio.iTrip.Location.Business
{
    public class LocationCollector : ILocationCollector
    {
        private static List<ISnapLocation> _collector = new List<ISnapLocation>();

        private static ILocationCollector _instance = new LocationCollector();
        public static ILocationCollector Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<ISnapLocation> GetLocations(int nation, int city)
        {
            return _collector.Where(s => s.Nation == nation && s.City == city).ToList();
        }

        public List<ISnapLocation> GetLocations(int nation, int city, Func<ISnapLocation, bool> expression)
        {
            return _collector.Where(s => s.Nation == nation && s.City == city).Where(expression).ToList();
        }

        public void GatherLocation(string account, string name, double lon, double lat, int nation, int city)
        {
            if (_collector.Exists(s => s.Account == account)) return;
            _collector.Add(new SnapLocation(account, name, lon, lat, nation, city));
        }

        public void UpdateLocation(string account, double lon, double lat)
        {
            var snap = _collector.SingleOrDefault(s => s.Account == account);
            if (snap == null) return;
            snap.UpdateLonLat(lon, lat);
        }
    }
}
