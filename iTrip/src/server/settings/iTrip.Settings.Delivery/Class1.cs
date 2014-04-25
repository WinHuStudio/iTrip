using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Settings.Delivery
{
    public class iTripChatPackage
    {
        /// <summary>
        /// 接收方
        /// </summary>
        public string Receivers { get; set; }

        /// <summary>
        /// 内容（真实内容转换成二进制，然后使用BASE64(utf8)编码）
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 内容类型（0：文字，1：图片，2：音频，3：视频）
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 文件扩展名（当为文字时可忽略）
        /// </summary>
        public string ExtName { get; set; }

        /// <summary>
        /// 内容长度（二进制长度）
        /// </summary>
        public int Length { get; set; }

    }
}
