using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.RelationCenter;

namespace iTrip.Service.Business.Relation.IRelationRecipient
{
    public interface IRelationAccountRegistration
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="ticket">票据</param>
        void Register(string account, string ticket);

        /// <summary>
        /// 注册群组（返回群组账号）
        /// </summary>
        /// <param name="account">创建人账号</param>
        /// <param name="name">群组名称</param>
        /// <returns>返回群组账号</returns>
        string RegisterGroup(string account, string name);

        /// <summary>
        /// 注册公共账号（返回公共账号）
        /// </summary>
        /// <param name="account">创建人账号</param>
        /// <param name="name">创建人姓名</param>
        /// <returns>返回公共账号</returns>
        string RegisterOrganization(string account, string name);

        /// <summary>
        /// 注册团体账号（返回团体账号）
        /// </summary>
        /// <param name="account">创建人账号</param>
        /// <param name="name">创建人姓名</param>
        /// <returns>返回团体账号</returns>
        string RegisterCommunity(string account, string name);

        /// <summary>
        /// 更新群组成员
        /// </summary>
        /// <param name="account">群组账号</param>
        /// <param name="ary_str_member">被更新的群组成员</param>
        /// <param name="isremove">是否为移除操作（true：移除，false：添加）</param>
        /// <returns></returns>
        StandardResult UpdateGroupMember(string account, Member[] ary_str_member, bool isremove);
    }
}
