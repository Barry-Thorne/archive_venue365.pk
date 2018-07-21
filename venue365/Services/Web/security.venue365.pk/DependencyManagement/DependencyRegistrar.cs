using alainsoftech.cache;
using alainsoftech.core;
using alainsoftech.core.Configuration;
using alainsoftech.core.Infrastructure;
using alainsoftech.core.Infrastructure.DbClient;
using alainsoftech.core.Infrastructure.DependencyManagement;
using Autofac;
using security.venue365.pk.BusinessLayer;
using security.venue365.pk.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace security.venue365.pk.DependencyManagement
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order
        {
            get { return 0; }
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, AppConfig config)
        {
            IMySqlDataProvider dataProvider = new MySqlDataProvider();
            ICacheManager cacheManager = new MemoryCacheManager();
            MySqlDbContext dbContext = (MySqlDbContext)dataProvider.GetDbContext(
                new ConnectionParams()
                {
                    Host = config.Host,
                    Database = config.Database,
                    Username = config.DbUsername,
                    Password = config.DbPassword,
                    Port = config.DbPort
                });
            builder.RegisterInstance<MySqlDbContext>(dbContext).As<IMySqlDbContext>().SingleInstance();
            builder.RegisterInstance<IMySqlDataProvider>(dataProvider).As<IMySqlDataProvider>().SingleInstance();
            builder.RegisterInstance<ICacheManager>(cacheManager).As<ICacheManager>().SingleInstance();
            builder.RegisterType<MySqlDbClient>().As<IMySqlDbClient>();
            builder.RegisterType<ApplicationContext>().As<IWorkContext>();
            builder.RegisterType<Vault>().As<IVault>();
            builder.RegisterType<VaultSqlHelper>().As<IVaultData>();

            cacheManager.Set(Keys.DatabaseKey, dbContext, 1080);
        }
    }
}