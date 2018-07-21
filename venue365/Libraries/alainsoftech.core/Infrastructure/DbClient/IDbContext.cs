using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alainsoftech.core.Infrastructure.DbClient
{
    public interface IDbContext : ICloneable, IDisposable
    {
        SqlConnection Connection { get; }
        SqlTransaction Transaction { get; set; }
        bool TransactionEnabled { get; }
        string Host { get; }
        string Database { get; }
        void OpenConnection();
        void OpenConnection(bool beginTransaction);
        void CloseConnection();
        void CloseConnection(bool commitTransaction);
        void CommitTransaction();
        void RollbackTransaction();
    }
}
