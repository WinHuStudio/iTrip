using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.TransferCenter
{
    /// <summary>
    /// iTrip.IM.Package
    /// </summary>
    [DataContract]
    public class T_Content
    {
        /// <summary>
        /// 内容（真实内容转换成二进制，然后使用BASE64(utf8)编码）
        /// </summary>
        [DataMember]
        public string Summary { get; set; }

        /// <summary>
        /// 内容类型（0：文字，1：图片，2：音频，3：视频）
        /// </summary>
        [DataMember]
        public int CType { get; set; }

        /// <summary>
        /// 文件扩展名（当为文字时可忽略）
        /// </summary>
        [DataMember]
        public string ExtName { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// 内容长度（二进制长度）
        /// </summary>
        [DataMember]
        public int Length { get; set; }
    }
}
