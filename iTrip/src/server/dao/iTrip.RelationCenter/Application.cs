using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace iTrip.RelationCenter
{
    public enum ApplicationType
    {
        APerson,
        AGroup,
        AOrganization,
        ACommunity
    }

    public class Application : REntity
    {
        public Application() { }

        /// <summary>
        /// 好友邀请
        /// </summary>
        /// <param name="applicant">邀请人账号</param>
        /// <param name="destacc">受邀人账号</param>
        /// <param name="destname">受邀人姓名</param>
        /// <param name="memo">邀请说明</param>
        public Application(string applicant, string destacc, string destname, string memo)
            : this(ApplicationType.APerson, applicant, destacc, destname, memo)
        { }

        /// <summary>
        /// 群组邀请
        /// </summary>
        /// <param name="applicant">邀请人账号</param>
        /// <param name="destacc">受邀人账号</param>
        /// <param name="destname">受邀人姓名</param>
        /// <param name="memo">邀请说明</param>
        public Application(string applicant, string destacc, string destname)
            : this(ApplicationType.AGroup, applicant, destacc, destname, null)
        { }
        public Application(ApplicationType type, string applicant, string destacc, string destname, string memo)
        {
            AppType = type;
            Applicant = applicant;
            DestAcc = destacc;
            DestName = destname;
            Memo = memo;
            CreationTime = DateTime.Now;
            AppType = ApplicationType.APerson;
        }

        [BsonIndex]
        public string Applicant { get; set; }
        [BsonIndex]
        public string DestAcc { get; set; }

        public string DestName { get; set; }

        public ApplicationType AppType { get; set; }

        public string Memo { get; set; }

        public bool State { get; set; }


        public DateTime CreationTime { get; set; }
    }
}
