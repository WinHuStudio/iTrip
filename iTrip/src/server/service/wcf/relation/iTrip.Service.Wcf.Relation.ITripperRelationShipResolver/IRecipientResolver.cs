using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Service.Wcf.Relation.ITripperRelationShipResolver
{
    [ServiceContract]
    public interface IRecipientResolver
    {

        /// <summary>
        /// 分析最终接收人
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns></returns>
        [OperationContract]
        StandardResult ParseRecipients(string account);

    }
}
