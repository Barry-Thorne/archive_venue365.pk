using alainsoftech.core.Infrastructure.DbClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace security.venue365.pk.DataLayer
{
    public interface IEntityData
    {
        IMySqlDbContext DbContext { get; }
    }
}
