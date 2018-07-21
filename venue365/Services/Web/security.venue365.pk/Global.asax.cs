using alainsoftech.cache;
using alainsoftech.core;
using alainsoftech.core.Infrastructure;
using alainsoftech.core.Infrastructure.DbClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace security.venue365.pk
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            EngineContext.Initialize(false);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if(AppContext.DbContext == null)
            {
                ICacheManager cacheManager = EngineContext.Current.Resolve<ICacheManager>();
                IMySqlDbContext dbContext = EngineContext
                    .Current
                    .Resolve<IMySqlDataProvider>()
                    .GetDbContext(
                    new ConnectionParams()
                    {
                        Host = EngineContext.Configurations.Host,
                        Database = EngineContext.Configurations.Database,
                        Username = EngineContext.Configurations.DbUsername,
                        Password = EngineContext.Configurations.DbPassword,
                        Port = EngineContext.Configurations.DbPort
                    });
                cacheManager.Set(Keys.DatabaseKey, dbContext, 1080);
            }
            IMySqlDbContext mySqlDbContext = (IMySqlDbContext)AppContext.DbContext.Clone();
            mySqlDbContext.OpenConnection(true);
            HttpContext.Current.Items.Add(Keys.DatabaseKey, AppContext.DbContext);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}