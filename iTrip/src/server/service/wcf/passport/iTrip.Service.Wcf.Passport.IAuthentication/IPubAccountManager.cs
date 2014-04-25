using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Service.Wcf.Passport.IAuthentication
{
    public enum PubAccountType
    {
        Group = 1,
        Publisher = 2,
        Organization = 3,
        Community = 4
    }

    [ServiceContract]
    public interface IPubAccountManager
    {
        [OperationContract]
        StandardResult RegisterComAcc(string account, PubAccountType acctype);

    }
}
