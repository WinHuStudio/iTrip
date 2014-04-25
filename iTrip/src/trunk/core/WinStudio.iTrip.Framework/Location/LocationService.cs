using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WinStudio.iTrip.Framework.Location
{
    public interface ILocationService
    {

        void Update(string account, float longitude, float latitude, string name);

        void Remove(string account);

        string GetAllUserLocations();
    }

    public class LocationService : ILocationService
    {
        private List<Location> _locations = new List<Location>();

        private static ILocationService _instance = new LocationService();
        public static ILocationService Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Update(string account, float longitude, float latitude, string name)
        {
            if (!_locations.Exists(l => l.Account == account))
                _locations.Add(new Location() { Account = account, Name = name, Latitude = latitude, Longitude = latitude });
            else _locations.Find(l => l.Account == account).Refresh(longitude, latitude);
        }

        public void Remove(string account)
        {
            _locations.RemoveAll(l => l.Account == account);
        }

        public string GetAllUserLocations()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("count:{0}", _locations.Count);
            foreach (var location in _locations)
            {
                sb.AppendFormat(";{0}", location.ToString());
            }
            return sb.ToString();
        }
    }
}
