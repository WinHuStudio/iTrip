using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrip.Service.Business.Passport.IAuthentication
{
    public interface IPubAccount
    {
        StandardResult RegisterGroup(string account);
        StandardResult RegisterPublisher(string account);
        StandardResult RegisterOrganization(string account);
        StandardResult RegisterCommunity(string account);

        StandardResult RemoveGroup(string account);


    }
}
