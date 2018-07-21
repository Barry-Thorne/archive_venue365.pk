using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alainsoftech.core.Infrastructure.DbClient;

namespace alainsoftech.core
{
    /// <summary>
    /// Work context
    /// </summary>
    public interface IWorkContext
    {
        IDbContext DbContext { get;}

        /// <summary>
        /// Get or set value indicating whether we're in admin area
        /// </summary>
        bool IsAdmin { get;}
    }
}
