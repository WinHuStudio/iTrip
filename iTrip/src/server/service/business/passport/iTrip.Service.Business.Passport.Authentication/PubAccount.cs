using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.Service.Business.Passport.IAuthentication;
using iTrip.Service.Common;
using iTrip.TripperCenter;

namespace iTrip.Service.Business.Passport.Authentication
{
    public class PubAccount : SuperBllService, IPubAccount
    {
        public StandardResult RegisterGroup(string account)
        {
            var resp_group = GetRespository<Group>();
            Group group = new Group(account);
            resp_group.Save(group);
            return Result(true);
        }

        public StandardResult RegisterPublisher(string account)
        {
            var resp_publisher = GetRespository<Publisher>();
            Publisher publisher = new Publisher(account);
            resp_publisher.Save(publisher);
            return Result(true);
        }

        public StandardResult RegisterOrganization(string account)
        {
            var resp_organization = GetRespository<Organization>();
            Organization organization = new Organization(account);
            resp_organization.Save(organization);
            return Result(true);
        }

        public StandardResult RegisterCommunity(string account)
        {
            var resp_community = GetRespository<Community>();
            Community community = new Community(account);
            resp_community.Save(community);
            return Result(true);
        }


        public StandardResult RemoveGroup(string account)
        {
            var resp_group = GetRespository<Group>();
            var group = resp_group.Get(g => g.Account == account);
            if (group != null)
                resp_group.Delete(group);
            return Result(true);
        }
    }
}
