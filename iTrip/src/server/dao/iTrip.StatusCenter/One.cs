using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.iPP.IProxy;
using MongoDB.Driver;

namespace iTrip.StatusCenter
{
    public class One : SEntity
    {
        public One()
        {
            Setting = (int)PushSetting.IM;
            LastOnOffTime = DateTime.Now;
            LastPushTime = DateTime.Now;
        }
        public One(string account)
        {
            Account = account;
            Setting = (int)PushSetting.IM;
            LastOnOffTime = DateTime.Now;
            LastPushTime = DateTime.Now;
            State = true;
        }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// 上一次在线状态变更的时间
        /// </summary>
        public DateTime LastOnOffTime { get; set; }

        /// <summary>
        /// 上次发生推送的时间
        /// </summary>
        public DateTime LastPushTime { get; set; }

        /// <summary>
        /// 推送设置（有即开，无即关）
        /// </summary>
        public int Setting { get; set; }

        public void SwitchPushSetting(PushSetting setting)
        {
            if (HasPushSetting(setting))
                Setting = ((int)Setting) - ((int)setting);
            else Setting = ((int)Setting) + ((int)setting);
        }
        public void PushSettingClose(PushSetting setting)
        {
            if (((PushSetting)Setting & setting) != 0)
                Setting = (Setting - ((int)setting));
        }
        public bool HasPushSetting(PushSetting setting)
        {
            return ((PushSetting)Setting & setting) != 0;
        }

        /// <summary>
        /// 用户是否接受推送
        /// </summary>
        /// <param name="setting">推送设置</param>
        /// <returns></returns>
        public bool CanBePushed(PushSetting setting)
        {
            if (!State)
                return false;
            if (setting == PushSetting.IM)
            {
                LastPushTime = DateTime.Now;
                return true;
            }
            return HasPushSetting(setting);
        }

        /// <summary>
        /// 用户上次的推送时间，并更新
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastPushedTime()
        {
            DateTime time = LastPushTime;
            LastPushTime = DateTime.Now;
            return time;
        }
    }
}
