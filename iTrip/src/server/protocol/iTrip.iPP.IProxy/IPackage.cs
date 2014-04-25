using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.iPP.IProxy
{
    public interface IPackage
    {
        Guid UID { get; set; }

        int PT { get; set; }

        string PS { get; set; }

        string PR { get; set; }

        DateTime PD { get; set; }

        byte[] PC { get; set; }

        int PCT { get; set; }

        string PCN { get; set; }

        int PCL { get; set; }

        string PCC { get; set; }

        string IPPV { get; set; }

        /// <summary>
        /// 将包括转换成byte数组
        /// </summary>
        /// <returns></returns>
        byte[] ToOrginBytes();

        /// <summary>
        /// 客户端发送到服务端（客户端使用）
        /// </summary>
        /// <returns></returns>
        byte[] ToServerBytes();
        /// <summary>
        /// 服务端发送到客户端（服务端使用）
        /// </summary>
        /// <returns></returns>
        byte[] ToClientBytes();
        /// <summary>
        /// 服务端发送到客户端（服务端使用，返回接收结果）
        /// </summary>
        /// <param name="err">错误信息（null为正常）</param>
        /// <returns></returns>
        byte[] ToServerResultBytes(string err);

        byte[] GetUidBytes();

        /// <summary>
        /// 接收并解析后的结果，直接返回给客户端
        /// </summary>
        /// <returns></returns>
        byte[] ReceivedResultBytes();

        bool IsValid();

        T GetContent<T>() where T : class;

    }
}
