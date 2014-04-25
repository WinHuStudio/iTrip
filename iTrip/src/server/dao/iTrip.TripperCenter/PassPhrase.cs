using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Model;

namespace iTrip.TripperCenter
{
    /// <summary>
    /// 通行证
    /// </summary>
    public class PassPhrase : UEntity
    {
        public PassPhrase() { }
        public PassPhrase(string account, string password)
        {
            Account = account;
            Password = password;
            DeviceType = DeviceType.Unknown;
        }

        /// <summary>
        /// 密码（MD5）
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 通行票据
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// 客户端设备串号
        /// </summary>
        public string DeviceSN { get; set; }

        /// <summary>
        /// 客户端设备类型
        /// </summary>
        public DeviceType DeviceType { get; set; }

        public bool IsFirst
        {
            get
            {
                return string.IsNullOrEmpty(DeviceSN) || DeviceType == DeviceType.Unknown;
            }
        }

        public bool IsValidDevice(string devicesn, DeviceType devicetype)
        {
            return DeviceSN == devicesn && DeviceType == devicetype;
        }

    }
}
