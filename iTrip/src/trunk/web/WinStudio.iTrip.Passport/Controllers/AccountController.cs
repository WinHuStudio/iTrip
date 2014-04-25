using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WinStudio.iTrip.Framework.Passport.Permission;
using WinStudio.iTrip.Models;
using WinStudio.iTrip.Passport.Models;
using WinStudio.iTrip.Permission.IPassport;

namespace WinStudio.iTrip.Passport.Controllers
{
    public class AccountController : iTripPassportController
    {

        public ActionResult Login(string next)
        {
            ViewBag.Next = next;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string next)
        {
            if (ModelState.IsValid)//&& WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                var recepter = GetService<IProfile>();
                var ret = recepter.CheckIn(model.UserAccount, model.Password, LoginType.Web, IP);
                if (ret.Ret)
                {
                    CheckIn(model.UserAccount, ret.LastMsg, LoginType.Web, IP);
                    return RedirectToLocal(next.FromBase64String());
                }
                else
                    ModelState.AddModelError("", ret.LastMsg);
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }



        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // 尝试注册用户
                try
                {
                    var ret = GetService<IProfile>().Register(model.UserAccount, model.Password);
                    if (ret.Ret)
                    {
                        var tp = RegisterProfile(model, ret.LastMsg);
                        //var tc = RegisterCustomer(model);
                        await Task.WhenAll(tp);
                        if (tp.Result)
                        {
                            return RedirectToLocal();
                        }
                        //else
                        //{
                        //    return RedirectToLocal("/Account/Profile/" + model.UserName);
                        //}
                    }
                    else
                        ModelState.AddModelError("", ret.LastMsg);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }

        private async Task<bool> RegisterProfile(RegisterModel model, string id)
        {
            return GetService<IProfile>().Register(id, model.UserAccount, model.UserName, model.Email).Ret;
        }
        //private async Task<bool> RegisterCustomer(Customer customer)
        //{
        //    return GetService<ICustomerBusiness>().RegisterCustomer(customer).Ret;
        //}

        public string UpdateUser()
        {
            return GetUserInfo();
        }
        public string UpdatePermission()
        {
            return "";
        }

        public string ValidationToken()
        {
            var ret = ValidateToken();
            //Response.Write(ret.ToString());
            return ret.ToString();
        }

        public ActionResult Logout()
        {
            DoLogout();
            return RedirectToLocal(WebConfiguration.Instance.WebProtalAddress);
        }
        [HttpPost]
        public void Logoff()
        {
            DoLogout();
        }
    }
}
