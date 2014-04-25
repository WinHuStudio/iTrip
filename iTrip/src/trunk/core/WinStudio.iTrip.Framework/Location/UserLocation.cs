using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStudio.iTrip.Framework.Location
{
    public class Location
    {
        public Location() { Time = DateTime.Now; }
        public string Account { get; set; }

        public string Name { get; set; }

        public float Longitude { get; set; }

        public float Latitude { get; set; }

        public DateTime Time { get; set; }

        public void Refresh(Location location)
        {
            if (location.Account != Account) return;
            Longitude = location.Longitude;
            Latitude = location.Latitude;
            Time = DateTime.Now;
        }
        public void Refresh(float longitude, float latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            Time = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format("account:{0},name:{1},lat:{2},lng:{3}", Account, Name, Latitude, Longitude);
        }
    }
}
