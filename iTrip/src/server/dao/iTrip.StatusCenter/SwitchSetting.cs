using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;

namespace iTrip.StatusCenter
{
    /// <summary>
    /// 推送开关设置
    /// </summary>
    [Flags]
    public enum PushSetting
    {
        [Description("IM消息")]
        IM = 1,
        [Description("全网广播")]
        GBC = 2,
        [Description("关系网内广播")]
        RBC = 4,
        [Description("广告")]
        AD = 8
    }
}
