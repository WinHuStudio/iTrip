using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Service.Wcf.Status.ITripperStatusResolver;
using iTrip.StatusCenter;

namespace iTrip.TestConsoler.Wcf
{
    public class WcfStatus : WcfBase
    {
        public void SwitchStatus()
        {
            Console.WriteLine("input account");
            string acc = Console.ReadLine();
            var status = GetService<ITripperStatusParser>();
            bool state = status.CanBePush(acc, (int)PushSetting.IM);
            Console.WriteLine("{0} PushSetting.IM={1}", acc, state);
            bool ret = status.CanBePush(acc, (int)PushSetting.RBC);
            Console.WriteLine("{0} PushSetting.RBC={1}", acc, ret);
            ret = status.CanBePush(acc, (int)PushSetting.AD);
            Console.WriteLine("{0} PushSetting.AD={1}", acc, ret);

            if (!state)
            {
                Console.WriteLine("switch state");

                status.SwitchStatus(acc, true);
                state = !state;
                Console.WriteLine("switch state to online");
            }

            Console.WriteLine("switch PushSetting.GBC");
            status.SwitchSetting(acc, (int)PushSetting.GBC);
            ret = status.CanBePush(acc, (int)PushSetting.GBC);
            Console.WriteLine("{0} PushSetting.GBC={1}", acc, ret);

            Console.WriteLine("switch PushSetting.AD");
            status.SwitchSetting(acc, (int)PushSetting.AD);
            ret = status.CanBePush(acc, (int)PushSetting.AD);
            Console.WriteLine("{0} PushSetting.AD={1}", acc, ret);

            Console.WriteLine("switch PushSetting.GBC");
            status.SwitchSetting(acc, (int)PushSetting.GBC);
            ret = status.CanBePush(acc, (int)PushSetting.GBC);
            Console.WriteLine("{0} PushSetting.GBC={1}", acc, ret);
            if (state)
            {
                Console.WriteLine("switch state");

                status.SwitchStatus(acc, false);
                Console.WriteLine("switch state to offline");
            }
        }
    }
}
