using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alainsoftech.core.Infrastructure.DbClient
{
    public interface IMySqlDataProvider
    {
        IMySqlDbContext GetDbContext(ConnectionParams connectionParams);
    }
}
