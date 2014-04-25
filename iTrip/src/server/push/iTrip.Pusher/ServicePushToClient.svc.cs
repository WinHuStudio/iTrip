using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using iTrip.iPP.Proxy;
using iTrip.Push.iTripSession;
using iTrip.Push.ServerManager;
using iTrip.Push.Wcf.PushService;

namespace iTrip.Pusher
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ServicePushToClient”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ServicePushToClient.svc 或 ServicePushToClient.svc.cs，然后开始调试。
    public class ServicePushToClient : ServerPushToClient
    {
    }
}
