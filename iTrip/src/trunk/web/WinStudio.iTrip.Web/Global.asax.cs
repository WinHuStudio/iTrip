using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MongoDB.Repository;
using WinStudio.DynamicLogger;
using WinStudio.iTrip.Framework.Passport.Permission;
using WinStudio.iTrip.Web.Core.Permission;

namespace WinStudio.iTrip.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            //MongoDBRepository.RegisterMongoDBContext(new iTripModelContext());
            //MongoDBRepository.RegisterMongoIndex();

            //MongoEntity.RemoveAll<Nationality>();
            //MongoEntity.RemoveAll<NativePlace>();

            //var initializer = new Initializer();
            //var nations = initializer.InitializeNationality();
            //MongoEntity.InsertBatch<NativePlace>(initializer.InitializeNativePlace(nations[0]));
            //MongoEntity.InsertBatch<Nationality>(nations);

            Initialize();
            DLogger.SetLocalPath(@"c:\log\itrip\web");
        }
        private void Initialize()
        {
            WebConfiguration.Instance.Reset(
                ConfigurationManager.AppSettings["ConfigAccountTokenName"].ToString(),
                ConfigurationManager.AppSettings["ConfigIdTokenName"].ToString(),
                ConfigurationManager.AppSettings["ConfigSecurityTokenName"].ToString(),
                ConfigurationManager.AppSettings["ConfigHeaderCodeName"].ToString(),
                ConfigurationManager.AppSettings["ConfigHeaderTypeName"].ToString(),
                ConfigurationManager.AppSettings["ConfigHeaderBusiCodeName"].ToString(),
                ConfigurationManager.AppSettings["ConfigDomainName"].ToString(),
                ConfigurationManager.AppSettings["ConfigTimeout"].ToInt(0)
                );
            WebConfiguration.Instance.Reset(
                ConfigurationManager.AppSettings["WebProtalAddress"].ToString(),
                ConfigurationManager.AppSettings["WebPassportAddress"].ToString(),
                ConfigurationManager.AppSettings["WebLoginAddress"].ToString(),
                ConfigurationManager.AppSettings["WebLogoutAddress"].ToString(),
                ConfigurationManager.AppSettings["WebRegisterAddress"].ToString(),
                ConfigurationManager.AppSettings["WebUpdateUserAddress"].ToString(),
                ConfigurationManager.AppSettings["WebUpdatePermissionAddress"].ToString()
                );

            Reception.Instance.SetUserSnapLoader(new iTripWebUserSnapLoader());
            Reception.Instance.SetUserPermissionLoader(null);
        }
    }
}