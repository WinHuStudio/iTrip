using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WinStudio.iTrip.Framework.Location
{
    public class PublishService
    {
        private static IDictionary<string, HttpResponseBase> contexts = new Dictionary<string, HttpResponseBase>();
        public static void AddHttpContext(HttpContextBase context)
        {
            //var token = context.GetToken(WinWebGlobalManager.Config.WinTokenName);
            //if (!contexts.Keys.Contains(token))
            //    contexts.Add(token, context.Response);
            //if (contexts.Exists(c => c..GetToken(WinWebGlobalManager.Config.WinTokenName) == context.GetToken(WinWebGlobalManager.Config.WinTokenName)))
            //    return;
            //contexts.Add(context.Response);
        }

        public static void Publish()
        {
            var data = LocationService.Instance.GetAllUserLocations();
            Publish(data);
        }

        private static void Publish(string msg)
        {
            foreach (var context in contexts.Values)
            {
                try
                {
                    //if (context.IsClientConnected)
                    //{
                    context.ContentType = "text/event-stream";
                    context.CacheControl = "no-cache";
                    var data = LocationService.Instance.GetAllUserLocations();
                    context.Write("data:" + msg);
                    context.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static Timer timer = new Timer(new TimerCallback(KeepAlive), "keepalive", 0, 1000);

        public static void KeepAlive(object state)
        {
            Console.WriteLine(state);
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Publish(state.ToString());
        }
    }
}
