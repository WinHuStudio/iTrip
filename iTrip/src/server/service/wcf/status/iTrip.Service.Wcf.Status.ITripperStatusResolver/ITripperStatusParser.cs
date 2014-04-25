using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Service.Wcf.Status.ITripperStatusResolver
{
    [ServiceContract]
    public interface ITripperStatusParser
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="ticket">票据</param>
        [OperationContract(IsOneWay = true)]
        void RegisterTripper(string account, string ticket);

        /// <summary>
        /// 是否接受推送
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <param name="settingType">推送类型</param>
        /// <returns></returns>
        [OperationContract]
        bool CanBePush(string account, int settingType);

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <param name="state">状态（true：在线）</param>
        [OperationContract(IsOneWay = true)]
        void SwitchStatus(string account, bool state);


        /// <summary>
        /// 切换推送设置状态
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <param name="settingType">推送类型</param>
        [OperationContract(IsOneWay = true)]
        void SwitchSetting(string account, int settingType);
    }
}
