using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.Location.IBusiness;

namespace WinStudio.iTrip.Location.Business
{
    [Serializable]
    public class SnapLocation : ISnapLocation
    {
        private List<ILocationLonLat> _trace = new List<ILocationLonLat>();

        public SnapLocation(string account, string name, double lon, double lat, int nation, int city)
        {
            Account = account;
            Name = name;
            Longitude = lon;
            Latitude = lat;
            City = city;
            Nation = nation;
            LonLat = new LocationLonLat(lon, lat);
            _trace.Add(LonLat);
        }
        public string Account { get; set; }

        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        private ILocationLonLat LonLat { get; set; }

        public int Nation { get; set; }

        public int City { get; set; }

        public DateTime Time { get; set; }

        public List<ILocationLonLat> GetTrace()
        {
            return _trace;
        }

        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", Account, Name, Longitude, Latitude, Time.ToString("yyyyMMddHHmmss"), Nation, City);
        }


        public void UpdateLonLat(double lon, double lat)
        {
            Longitude = lon;
            Latitude = lat;
            Time = DateTime.Now;
            _trace.Add(new LocationLonLat(lon, lat));
        }
    }

    [Serializable]
    public class LocationLonLat : ILocationLonLat
    {
        private DateTime _time = DateTime.Now;
        private double _lon, _lat;
        public LocationLonLat(double lon, double lat)
        {
            _lon = lon;
            _lat = lat;
            _time = DateTime.Now;

        }
        public double Longitude { get { return _lon; } set { _lon = value; } }

        public double Latitude { get { return _lat; } set { _lat = value; } }

        public DateTime Time { get { return _time; } set { _time = value; } }


        public object ToJson()
        {
            return new { Longitude = _lon, Latitude = _lat, Time = _time };
        }
    }
}
