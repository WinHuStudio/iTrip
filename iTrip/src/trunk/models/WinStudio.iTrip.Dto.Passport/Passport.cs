using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Repository;
using WinStudio.iTrip.Models;

namespace WinStudio.iTrip.Dto.Passport
{
    public class Passport : UIBaseEntity
    {
        public Passport() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="passwrod">密码</param>
        /// <param name="type">登陆类型</param>
        public Passport(string account, string passwrod, LoginType type)
        {
            Password = passwrod;
            Account = account;
            Type = type;
            State = UserState.Registerd;
        }

        public string Password { get; set; }

        [BsonIndex]
        public string SecurityKey { get; set; }

        [BsonIndex]
        public string Account { get; set; }

        public LoginType Type { get; set; }

        public string WebCode { get; set; }

        public string ClientCode { get; set; }

        public UserState State { get; set; }

        public DateTime LastTime { get; set; }

        public string GetLoginCode(LoginType type)
        {
            return Type == LoginType.Web ? WebCode : ClientCode;
        }
    }
}
