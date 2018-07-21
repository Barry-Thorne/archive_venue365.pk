using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alainsoftech.core.Caching;
using alainsoftech.core.Infrastructure;
using alainsoftech.core.Infrastructure.DbClient;

namespace alainsoftech.core
{
    public class ApplicationContext : IWorkContext
    {
        private ICacheManager _cacheManager;
        public ApplicationContext(ICacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
        }

        public IDbContext DbContext
        {
            get
            {
                return _cacheManager.Get<IDbContext>(Keys.DatabaseKey);
            }
        }
        public static ApplicationContext Current { get; private set; }
        public bool IsAdmin { get; private set; }
    }
}
