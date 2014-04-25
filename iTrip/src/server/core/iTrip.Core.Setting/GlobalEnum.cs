using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip
{

    public enum DeviceType
    {
        Unknown = 0,
        Android = 1,
        iOS = 2,
        WinPhone = 3
    }
    public enum Gender
    {
        Female = 0,
        Male = 1,
        Unknown = 100
    }

    public enum AccountType
    {
        [Description("个人")]
        Personage = 0,
        [Description("社区")]
        Community = 1,
        [Description("组织")]
        Organization = 10
    }

    /// <summary>
    /// 请求过滤器（值越低，级别越高）
    /// </summary>
    [Flags]
    public enum WebRequestFilterType
    {
        [Description("Web请求方式")]
        WebMethod = 1,
        [Description("Web请求需携带客户端版本号")]
        Version = 2,
        [Description("Web请求需携带用户账号")]
        Ticket = 4,
        [Description("Web请求需携带用户票据")]
        Account = 8,
        [Description("Web请求需携带客户端设备串号")]
        DeviceSN = 16,
        [Description("Web请求需携带客户端设备类型")]
        DeviceType = 32,
        [Description("Web请求需验证用户合法性")]
        Authentication = 64

    }
}
