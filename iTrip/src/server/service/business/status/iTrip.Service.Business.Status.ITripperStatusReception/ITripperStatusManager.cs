using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Service.Business.Status.ITripperStatusReception
{
    public interface ITripperStatusManager
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="ticket">票据</param>
        void RegisterTripper(string account, string ticket);

        /// <summary>
        /// 是否接受推送
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <param name="settingType">推送类型</param>
        /// <returns></returns>
        bool CanBePush(string account, int settingType);

        /// <summary>
        /// 切换状态，并返回上次推送时间（如果返回的时间为最大值，则表示状态切换为下线状态，拒绝接受推送）
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <param name="state">状态（true：在线）</param>
        DateTime SwitchStatus(string account, bool state);


        /// <summary>
        /// 切换推送设置状态
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <param name="settingType">推送类型</param>
        void SwitchSetting(string account, int settingType);

        /// <summary>
        /// 获取用户上次的推送时间
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns></returns>
        void ResetLastPushTime(string account);
    }
}
