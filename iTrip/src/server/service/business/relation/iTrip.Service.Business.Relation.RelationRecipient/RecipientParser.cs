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
    public class RecipientParser : SuperBllService, IRecipientParser
    {
        public StandardResult ParseRecipient(string account)
        {
            if (Group.IsCommonAccount(account, GlobalConst.CodeAccountPreFlag_Group))
            {
                var resp_group = GetRespository<Group>();
                var group = resp_group.Get(g => g.Account == account);
                if (group == null) return Result(iTripExceptionCode.Error_Null_Account);
                return Result(group.GetMemberAccounts());
            }

            return Result(new string[] { account });
        }

    }
}
