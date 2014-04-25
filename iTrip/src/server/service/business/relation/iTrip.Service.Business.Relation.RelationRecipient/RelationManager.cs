using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.RelationCenter;
using iTrip.Service.Common;
using MongoDB.Repository;

namespace iTrip.Service.Business.Relation.IRelationRecipient
{
    public class RelationManager : SuperBllService, IRelationManager
    {
        public StandardResult ApplyFriend(string applier, string friend, string name, string memo)
        {
            if (!GetRespository<Person>().Exists(p => p.Account == applier || p.Account == friend))
            {
                return Result(iTripExceptionCode.Error_Wrong_Account);
            }

            var app = new Application(applier, friend, name, memo);
            GetRespository<Application>().Save(app);
            return Result(true, app.Id);
        }

        public bool AcceptApplication(string person, string applicationId)
        {
            var resp_application = GetRespository<Application>();
            var app = resp_application.Get(applicationId);
            if (app == null) return false;
            if (app.State) return true;
            app.State = true;
            resp_application.Save(app);

            var resp_person = GetRespository<Person>();
            var ps = resp_person.Select(p => p.Account == app.Applicant || p.Account == app.DestAcc).ToList();
            if (ps.Count != 2)
                return false;
            foreach (var p in ps)
            {
                //if (p.Account == app.Applicant)
                //{
                //    if (!p.Friends.Contains(app.DestAcc))
                //        p.Friends.Add(app.DestAcc);
                //}
                //else if (p.Account == app.DestAcc)
                //    if (!p.Friends.Contains(app.Applicant))
                //        p.Friends.Add(app.Applicant);
            }

            resp_person.Save(ps);

            return true;
        }


        public Member[] GetMyFriends(string account)
        {
            var resp_person = GetRespository<Person>();
            Person person = resp_person.Get(p => p.Account == account);
            if (person == null)
                return new Member[0];
            return person.Friends.ToArray();
        }

    }
}
