using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alainsoftech.core.Infrastructure.DbClient
{
    public class MsSqlDataProvider : IDataProvider
    {
        public IDbContext GetDbContext(ConnectionParams connectionParams)
        {
            MsSqlDbContext dbContext = new MsSqlDbContext(connectionParams);
            return dbContext;
        }
    }
}
