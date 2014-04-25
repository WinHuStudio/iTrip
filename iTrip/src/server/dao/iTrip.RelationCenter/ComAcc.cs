using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;

namespace iTrip.RelationCenter
{
    public class ComAcc : REntity
    {
        public ComAcc(string accflag)
        {
            _accflag = accflag;
        }

        private string _accflag = string.Empty;
        protected string AccFlag { get { return _accflag; } }

        /// <summary>
        /// 账号
        /// </summary>
        [BsonIndex]
        public string Account { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 成员
        /// </summary>
        public virtual List<Member> Members { get; set; }

        public static bool IsCommonAccount(string account, string accflag)
        {
            if (string.IsNullOrEmpty(account)) return false;
            return account.Length > (24 + accflag.Length) && account.StartsWith(accflag);
        }
        public virtual bool IsThisAccount(string account)
        {
            return ComAcc.IsCommonAccount(account, AccFlag);
        }

        public virtual string[] GetMemberAccounts()
        {
            return Members.Select(m => m.Account).ToArray();
        }
    }
}
