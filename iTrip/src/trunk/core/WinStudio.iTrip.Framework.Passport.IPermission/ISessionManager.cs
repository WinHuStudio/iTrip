using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStudio.iTrip.ICore;

namespace WinStudio.iTrip.Framework.Passport.IPermission
{
    public interface ISessionManager
    {
        /// <summary>
        /// 过期用户
        /// </summary>
        /// <param name="securityToken">安全码</param>
        void Expire(string securityToken);

        /// <summary>
        /// 获取SessionSanp
        /// </summary>
        /// <param name="securityToken">安全码</param>
        /// <returns></returns>
        IUserSnap Get(string securityToken);

        /// <summary>
        /// 安全码是否过期
        /// </summary>
        /// <param name="securityToken">安全码</param>
        /// <returns></returns>
        bool IsExpired(string securityToken);

        /// <summary>
        /// 安全码是否合法
        /// </summary>
        /// <param name="securityToken">安全码</param>
        /// <returns></returns>
        bool IsLegal(string securityToken);

        /// <summary>
        /// 创建SessionSnap
        /// </summary>
        /// <param name="snap">IUserSnap</param>
        /// <returns>返回SecurityToken</returns>
        string Add(IUserSnap snap);

        /// <summary>
        /// 获取当前所有的活跃用户
        /// </summary>
        /// <returns></returns>
        List<IUserSnap> GetAllUser();
        List<IUserSnap> GetValidUsers();
        List<IUserSnap> GetLegalUsers();

        /// <summary>
        /// 获取当前所有活跃用户的数量
        /// </summary>
        /// <returns></returns>
        int CountAll();
        int CountLegal();
        int CountValid();

        /// <summary>
        /// 设置Session过期时间
        /// </summary>
        /// <param name="timeout">分钟</param>
        void SetTimeout(int timeout);
        /// <summary>
        /// 验证用户是否合法
        /// </summary>
        /// <param name="snap">IUserSnap</param>
        /// <returns></returns>
        bool IsValid(IUserSnap snap);
    }
}
