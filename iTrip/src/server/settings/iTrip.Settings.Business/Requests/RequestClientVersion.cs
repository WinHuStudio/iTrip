using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Settings.Business.Requests
{
    public class RequestClientVersion
    {
        private static IDictionary<string, bool> _clientversions = new Dictionary<string, bool>();
        public static void UpdateVersion(List<KeyValuePair<string, bool>> versions)
        {
            foreach (KeyValuePair<string, bool> version in versions)
            {
                UpdateVersion(version.Key, version.Value);
            }
        }
        public static void UpdateVersion(string version, bool state)
        {
            if (_clientversions.ContainsKey(version))
                _clientversions[version] = state;
            else _clientversions.Add(version, state);
        }

        public static bool CheckeVersion(string version)
        {
            if (_clientversions.ContainsKey(version))
                return _clientversions[version];
            return false;
        }
    }
}
