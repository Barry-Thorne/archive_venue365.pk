using alainsoftech.cache;
using alainsoftech.core;
using alainsoftech.core.Infrastructure;
using alainsoftech.core.Infrastructure.DbClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace security.venue365.pk
{
    public class AppContext
    {
        private ICacheManager _cacheManager;
        public AppContext(ICacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
        }

        public static IMySqlDbContext DbContext
        {
            get
            {
                return EngineContext.Current.Resolve<ICacheManager>()
                    .Get<IMySqlDbContext>(Keys.DatabaseKey);
            }
        }
        public bool IsAdmin { get; private set; }
    }
}