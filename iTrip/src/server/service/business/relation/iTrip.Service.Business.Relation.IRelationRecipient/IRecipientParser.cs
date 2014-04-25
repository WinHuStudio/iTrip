using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Service.Business.Relation.IRelationRecipient
{
    public interface IRecipientParser
    {
        /// <summary>
        /// 分析接收人
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns></returns>
        StandardResult ParseRecipient(string account);
    }
}
