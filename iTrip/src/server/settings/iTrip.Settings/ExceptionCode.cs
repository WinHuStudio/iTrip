using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip
{
    public class iTripNullException : Exception
    {
        public iTripNullException(iTripExceptionCode code)
            : base(code.ToString())
        {
            base.HResult = (int)code;
        }
        public iTripNullException(int code)
            : base(code.ToString())
        {
            base.HResult = code;
        }
    }
    [Flags]
    public enum iTripExceptionCode
    {

        [Description("未定义的异常编码")]
        Error_UnKnown = 99999,

        [Description("不存在")]
        Error_Null = 100000,
        [Description("空引用")]
        Error_Null_Reference = 100001,
        [Description("未注册的账户")]
        Error_Null_Account = 100002,
        [Description("不存在的票据")]
        Error_Null_Ticket = 100003,

        [Description("已存在")]
        Error_Exist = 200000,
        [Description("已存在的账户")]
        Error_Exist_Account = 200001,
        [Description("已存在的票据")]
        Error_Exist_Ticket = 200002,

        [Description("不合法")]
        Error_Illegal = 300000,
        [Description("不合法的票据")]
        Error_Illegal_Ticket = 300001,
        [Description("不能变更性别")]
        Error_Illegal_Operation_Gender = 300002,

        [Description("不正确")]
        Error_Wrong = 400000,
        [Description("不正确的密码")]
        Error_Wrong_Password = 400001,
        [Description("尝试在其他设备上登录")]
        Error_Wrong_DeviceSN = 400002,
        [Description("错误的账号")]
        Error_Wrong_Account = 400003

    }
}
