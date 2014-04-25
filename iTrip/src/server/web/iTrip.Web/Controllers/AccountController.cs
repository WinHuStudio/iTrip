using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTrip.Model;
using iTrip.Settings;
using iTrip.WebBusiness;
using WinStudio.ComResult;

namespace iTrip.Web.Controllers
{
    public class AccountController : iTripController
    {
        ServicePassport.ServiceReceptionClient client;

        /// <summary>
        /// 用户登录（改变用户状态为online，并返回用户票据）
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码（MD5加密）</param>
        /// <param name="client">登录客户端类型</param>
        /// <param name="client_sn">登录客户端标识</param>
        /// <returns>Json{ret=true/false,msg=ticket}</returns>
        [HttpPost]
        public ActionResult Login(string account, string password, ClientType clientype, string clientsn)
        {
            client = new ServicePassport.ServiceReceptionClient();
            var ret = client.Login(account, password, clientype, clientsn);
            //IServiceAuthentication serv = new ServiceAuthentication();
            //ComRet ret = serv.Login(account, password, client, clientsn);
            return JResult(ret);
        }

        /// <summary>
        /// 检查用户票据
        /// </summary>
        /// <param name="ticket">票据</param>
        /// <returns>true/false</returns>
        [HttpPost]
        public ActionResult CheckTicket(string ticket)
        {
            client = new ServicePassport.ServiceReceptionClient();
            var ret = client.CheckTicket(ticket);

            //IServiceAuthentication serv = new ServiceAuthentication();
            //ComRet ret = serv.CheckTicket(ticket);
            return JResult(ret);
        }

        /// <summary>
        /// 用户登出（服务端只改变用户状态为offline，客户端需要移除当前有效票据）
        /// </summary>
        /// <param name="ticket">票据</param>
        /// <returns>true/false</returns>
        [HttpPost]
        public ActionResult Logout(string ticket)
        {
            client = new ServicePassport.ServiceReceptionClient();
            var ret = client.Logout(ticket);
            //IServiceAuthentication serv = new ServiceAuthentication();
            //ComRet ret = serv.Logout(ticket);
            return JResult(ret);
        }

        /// <summary>
        /// 用户注册（无登录功能）
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码（MD5加密）</param>
        /// <returns>true/false</returns>
        [HttpPost]
        public ActionResult Register(string account, string password)
        {
            client = new ServicePassport.ServiceReceptionClient();
            var ret = client.Register(account, password);
            //IServiceAuthentication serv = new ServiceAuthentication();
            //ComRet ret = serv.Register(account, password);
            return JResult(ret);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="ticket">用户当前票据</param>
        /// <param name="name">姓名</param>
        /// <param name="gender">性别</param>
        /// <returns>true/false</returns>
        [HttpPost]
        public ActionResult UpdateUserInfo(string ticket, string name, int gender)
        {
            client = new ServicePassport.ServiceReceptionClient();
            var ret = client.UpdateInfo(ticket, name, (Gender)gender);
            //IServiceAuthentication serv = new ServiceAuthentication();
            //ComRet ret = serv.UpdateInfo(ticket, name, (Gender)gender);
            return JResult(ret);
        }

        /// <summary>
        /// 更新用户手机号码
        /// </summary>
        /// <param name="ticket">用户当前票据</param>
        /// <param name="telphone">手机号码</param>
        /// <returns>true/false</returns>
        [HttpPost]
        public ActionResult UpdateTelphone(string ticket, string telphone)
        {
            client = new ServicePassport.ServiceReceptionClient();
            var ret = client.UpdateInfo(ticket, telphone);
            //IServiceAuthentication serv = new ServiceAuthentication();
            //ComRet ret = serv.UpdateInfo(ticket, telphone);
            return JResult(ret);
        }

    }
}
