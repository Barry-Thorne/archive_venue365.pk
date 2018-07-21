using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alainsoftech.core.Infrastructure.DbClient
{
    public class MySqlDataProvider : IMySqlDataProvider
    {
        public IMySqlDbContext GetDbContext(ConnectionParams connectionParams)
        {
            MySqlDbContext dbContext = new MySqlDbContext(connectionParams);
            return dbContext;
        }
    }
}
