using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.RelationCenter;
using iTrip.Service.Business.Relation.IRelationRecipient;
using iTrip.Service.Common;

namespace iTrip.Service.Business.Relation.RelationRecipient
{
    public class RelationAccountRegistration : SuperBllService, IRelationAccountRegistration
    {
        public void Register(string account, string ticket)
        {
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(ticket)) return;
            var resp_person = GetRespository<Person>();
            resp_person.Save(new Person(account));
        }

        public string RegisterGroup(string account, string name)
        {
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(name)) return null;
            var resp_group = GetRespository<Group>();
            Group group = new Group(account, name);
            resp_group.Save(group);
            return group.Account;
        }

        public string RegisterOrganization(string account, string name)
        {
            throw new NotImplementedException();
        }

        public string RegisterCommunity(string account, string name)
        {
            throw new NotImplementedException();
        }

        public StandardResult UpdateGroupMember(string account, Member[] ary_str_member, bool isremove)
        {
            if (!ComAcc.IsCommonAccount(account, GlobalConst.CodeAccountPreFlag_Group))
                return Result(iTripExceptionCode.Error_Wrong_Account);

            var resp_group = GetRespository<Group>();
            var group = resp_group.Get(g => g.Account == account);

            if (isremove)
                group.Members.RemoveAll(m => ary_str_member.Any(o => o.Account == m.Account));
            else
            {
                ary_str_member.ForEach(delegate(Member member)
                {
                    if (!group.Members.Exists(m => m.Account == member.Account))
                        group.Members.Add(member);
                });
            }
            resp_group.Save(group);
            return Result();
        }
    }
}
