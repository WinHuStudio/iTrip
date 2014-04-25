using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Service.Business.Status.ITripperStatusReception;
using iTrip.Service.Common;
using iTrip.StatusCenter;

namespace iTrip.Service.Business.Status.TripperStatusReception
{
    public class TripperStatusManager : SuperBllService, ITripperStatusManager
    {
        public bool CanBePush(string account, int setting)
        {
            PushSetting settingType;
            if (Enum.TryParse<PushSetting>(setting.ToString(), out settingType))
            {
                var resp = GetRespository<One>();
                var one = resp.Get(o => o.Account == account);
                if (one == null)
                    return false;
                return one.CanBePushed(settingType);
            }
            return false;
        }

        public DateTime SwitchStatus(string account, bool state)
        {
            var resp = GetRespository<One>();
            var one = resp.Get(o => o.Account == account);
            if (one == null)
                return DateTime.MaxValue;
            if (one.State != state)
            {
                one.State = state;
                resp.Save(one);
            }
            return one.State ? one.LastPushTime : DateTime.MaxValue;
        }

        public void SwitchSetting(string account, int setting)
        {
            var resp = GetRespository<One>();
            var one = resp.Get(o => o.Account == account);
            if (one == null) return;

            PushSetting settingType;
            if (Enum.TryParse<PushSetting>(setting.ToString(), out settingType))
            {
                one.SwitchPushSetting(settingType);
                resp.Save(one);
            }
        }

        public void ResetLastPushTime(string account)
        {
            var resp = GetRespository<One>();
            var one = resp.Get(o => o.Account == account);
            if (one == null) return;
            one.LastPushTime = DateTime.Now;
            resp.Save(one);
        }

        public void RegisterTripper(string account, string ticket)
        {
            if (string.IsNullOrEmpty(account)) return;
            if (GetRespository<One>().Exists(o => o.Account == account)) return;
            GetRespository<One>().Save(new One(account));
        }
    }
}
