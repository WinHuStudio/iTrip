using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace iTrip.Web
{
    public interface IWebController
    {
        string Account { get; }

        string Ticket { get; }

        string DeviceSN { get; }

        DeviceType DeviceType { get; }

        string ClientVersion { get; }

        string WebMethod { get; }
    }

    public class WebController : Controller, IWebController
    {
        private string _account, _ticket, _devicesn, _clientversion;
        private DeviceType _devicetype = DeviceType.Unknown;

        /// <summary>
        /// 当前请求所携带的用户账号
        /// </summary>
        public string Account
        {
            get
            {
                if (string.IsNullOrEmpty(_account))
                {
                    if (Request.Headers.AllKeys.Contains(GlobalConst.CodeInRequest_iTripClientAccount))
                        _account = Request.Headers[GlobalConst.CodeInRequest_iTripClientAccount];
                }
                return _account;
            }
        }

        /// <summary>
        /// 当前请求所携带的用户票据
        /// </summary>
        public string Ticket
        {
            get
            {
                if (string.IsNullOrEmpty(_ticket))
                {
                    if (Request.Headers.AllKeys.Contains(GlobalConst.CodeInRequest_iTripClientTicket))
                        _ticket = Request.Headers[GlobalConst.CodeInRequest_iTripClientTicket];
                }
                return _ticket;
            }
        }

        /// <summary>
        /// 当前请求所携带的设备串号
        /// </summary>
        public string DeviceSN
        {
            get
            {
                if (string.IsNullOrEmpty(_devicesn))
                {
                    if (Request.Headers.AllKeys.Contains(GlobalConst.CodeInRequest_iTripClientDeviceSN))
                        _devicesn = Request.Headers[GlobalConst.CodeInRequest_iTripClientDeviceSN];
                }
                return _devicesn;
            }
        }
        /// <summary>
        /// 当前请求所携带的设备类型
        /// </summary>
        public DeviceType DeviceType
        {
            get
            {
                if (_devicetype == DeviceType.Unknown)
                {
                    if (Request.Headers.AllKeys.Contains(GlobalConst.CodeInRequest_iTripClientDeviceType))
                    {
                        if (!Enum.TryParse<DeviceType>(Request.Headers[GlobalConst.CodeInRequest_iTripClientDeviceType], out _devicetype))
                            _devicetype = DeviceType.Unknown;
                    }
                }
                return _devicetype;
            }
        }
        /// <summary>
        /// 当前请求所携带的客户端版本号
        /// </summary>
        public string ClientVersion
        {
            get
            {
                if (string.IsNullOrEmpty(_clientversion))
                {
                    if (Request.Headers.AllKeys.Contains(GlobalConst.CodeInRequest_iTripClientVersion))
                        _clientversion = Request.Headers[GlobalConst.CodeInRequest_iTripClientVersion];
                }
                return _clientversion;
            }
        }
        /// <summary>
        /// 当前请求方式
        /// </summary>
        public string WebMethod
        {
            get
            {
                return Request.HttpMethod;
            }
        }
    }
}
