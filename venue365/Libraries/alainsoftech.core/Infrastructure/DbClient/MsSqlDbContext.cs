using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace alainsoftech.core.Infrastructure.DbClient
{
    [Serializable]
    public class MsSqlDbContext : IDbContext
    {
        private string _strConnection;
        public MsSqlDbContext()
        {

        }
        public MsSqlDbContext(ConnectionParams connectionParams)
        {
            this._strConnection = string.Format("Data Source={0}; Initial Catalog={1};User Id={2};Password='{3}'",
                connectionParams.Host,
                connectionParams.Database,
                connectionParams.Username,
                connectionParams.Password);
            this.Connection = new SqlConnection(this._strConnection);
            this.Host = connectionParams.Host;
            this.Database = connectionParams.Database;
        }
        public SqlConnection Connection { get; private set; }

        public SqlTransaction Transaction { get; set; }

        public bool TransactionEnabled { get; private set; }

        public string Host { get; private set; }

        public string Database { get; private set; }

        public void CloseConnection()
        {
            if (this.Connection != null && this.Connection.State != System.Data.ConnectionState.Closed)
            {
                this.Connection.Close();
            }
        }

        public void CloseConnection(bool commitTransaction)
        {
            if (commitTransaction)
            {
                CommitTransaction();
            }
            CloseConnection();
        }

        public void CommitTransaction()
        {
            if (this.TransactionEnabled && this.Transaction != null)
            {
                this.Transaction.Commit();
                this.Transaction = null;
                this.TransactionEnabled = false;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void OpenConnection()
        {
            if (this.Connection == null)
            {
                this.Connection = new SqlConnection(this._strConnection);
            }
            if (this.Connection.State == System.Data.ConnectionState.Closed)
            {
                this.Connection.Open();
            }
        }

        public void OpenConnection(bool beginTransaction)
        {
            OpenConnection();
            if (beginTransaction)
            {
                this.TransactionEnabled = true;
                this.Transaction = this.Connection.BeginTransaction();
            }
        }

        public void RollbackTransaction()
        {
            if (this.TransactionEnabled && this.Transaction != null)
            {
                this.Transaction.Rollback();
                this.Transaction = null;
                this.TransactionEnabled = false;
            }
        }
        public object Clone()
        {
            MsSqlDbContext clonedObject = new MsSqlDbContext();
            clonedObject.Host = string.Copy(this.Host);
            clonedObject.Database = string.Copy(this.Database);
            clonedObject.Connection = new SqlConnection(string.Copy(this.Connection.ConnectionString));
            return clonedObject;
        }
    }
}
