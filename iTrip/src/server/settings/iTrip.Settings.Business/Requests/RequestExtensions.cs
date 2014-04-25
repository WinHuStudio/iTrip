using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Settings.Business.Requests;
using iTrip.Settings.Consts;
using WinStudio.ComResult;

namespace System.Web
{
    public static class RequestExtensions
    {
        /// <summary>
        /// 判断客户端请求是否合法（必须为POST请求，要求必须包含客户端版本号）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static ComRet IsClientPostRequest(this HttpContextBase context)
        {
            if (context.Request.HttpMethod != RequestOfClient.HttpPostMethod)
                return new ComRet(false, string.Format("不支持非{0}请求", RequestOfClient.HttpPostMethod));

            if (context.Request.RequestType != RequestOfClient.HttpRequestType)
                return new ComRet(false, "非法请求");

            var ret = context.GetClientVersion();
            if (!ret.Ret)
                return new ComRet(false, ret.LastMsg);
            if (!RequestClientVersion.CheckeVersion(ret.LastMsg))
                return new ComRet(false, "请升级新的客户端");
            return new ComRet(true);
        }
        public static ComRet GetClientVersion(this HttpContextBase context)
        {
            var version = context.Request.Headers[RequestOfClient.ClientVersion];
            if (string.IsNullOrEmpty(version)) return new ComRet(false, "非法请求");
            return new ComRet(true, version);
        }
    }
}
