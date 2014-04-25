using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Settings.Consts
{
    /// <summary>
    /// 提示信息
    /// </summary>
    public class PromptMessage
    {
        public const string AccountNull = "账户不存在";
        public const string AccountExist = "账户已存在";
        public const string TicketIllegal = "票据不合法";
    }

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
        UnKnown = 0,

        [Description("不存在")]
        Null = 100000,
        [Description("不存在的账户")]
        Null_Account = 100001,
        [Description("不存在的票据")]
        Null_Ticket = 100002,

        [Description("已存在")]
        Exist = 200000,
        [Description("已存在的账户")]
        Exist_Account = 200001,
        [Description("已存在的票据")]
        Exist_Ticket = 200002,

        [Description("不合法")]
        Illegal = 300000,
        [Description("不合法的票据")]
        Illegal_Ticket = 300001
    }
}
