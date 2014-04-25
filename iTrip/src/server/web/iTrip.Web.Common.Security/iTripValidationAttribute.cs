using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace iTrip.Web.Common.Security
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class iTripValidationAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 最高级别验证，需要执行所有的验证器，且为HttpPost请求
        /// </summary>
        public iTripValidationAttribute()
            : this(0)
        {
        }
        /// <summary>
        /// 自定义验证
        /// </summary>
        /// <param name="level">所需的验证（参考枚举WebRequestFilterType）</param>
        /// <param name="method">请求方式</param>
        public iTripValidationAttribute(int level)
        {
            _level = level;
        }
        /// <summary>
        /// 自定义验证
        /// </summary>
        /// <param name="level">所需的验证（参考枚举WebRequestFilterType）</param>
        /// <param name="method">请求方式</param>
        public iTripValidationAttribute(WebRequestFilterType filterType)
        {
            _level = (int)filterType;
        }
        protected int _level;
        public int Level { get { return _level; } }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (ValidatorFactory.Instance.Validate(filterContext.Controller as IWebController, (WebRequestFilterType)Level))
                return;
            ContentResult cr = new ContentResult();
            cr.Content = "illegal request";
            filterContext.Result = cr;
        }
    }

    public class iTripVSNValidationAndAttribute : iTripValidationAttribute
    {
        /// <summary>
        /// 需要验证请求所携带的版本号和参数所代表的其他内容 
        /// </summary>
        /// <param name="level">所需的验证（参考枚举WebRequestFilterType）</param>
        /// <param name="method">请求方式</param>
        public iTripVSNValidationAndAttribute(WebRequestFilterType filterType)
            : base(filterType | WebRequestFilterType.Version)
        {
        }
    }

    public class iTripValidationWithVSN_WMDAndAttribute : iTripValidationAttribute
    {
        /// <summary>
        /// 需要验证请求所携带的版本号、请求方式和参数所代表的其他内容 
        /// </summary>
        /// <param name="level">所需的验证（参考枚举WebRequestFilterType）</param>
        /// <param name="method">请求方式</param>
        public iTripValidationWithVSN_WMDAndAttribute(WebRequestFilterType filterType)
            : base(filterType | WebRequestFilterType.Version | WebRequestFilterType.WebMethod)
        {
        }
    }

    public class iTripValidationWithVSN_WMD_AUTAttribute : iTripValidationAttribute
    {
        /// <summary>
        /// 需要验证请求所携带的版本号、请求方式和认证信息 
        /// </summary>
        public iTripValidationWithVSN_WMD_AUTAttribute()
            : base(WebRequestFilterType.Version | WebRequestFilterType.WebMethod | WebRequestFilterType.Authentication)
        {
        }
    }
}
