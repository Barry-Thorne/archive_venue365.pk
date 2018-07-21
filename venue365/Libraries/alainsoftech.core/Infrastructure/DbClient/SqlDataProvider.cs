using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alainsoftech.core.Infrastructure.DbClient
{
    public class SqlDataProvider : IDataProvider
    {
        public IDbContext GetDbContext(ConnectionParams connectionParams)
        {
            DbContext dbContext = new DbContext(connectionParams);
            return dbContext;
        }
    }
}
