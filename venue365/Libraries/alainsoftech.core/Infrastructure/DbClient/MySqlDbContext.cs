using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using alainsoftech.core.Constants;
using alainsoftech.core.Utilities;
using MySql.Data.MySqlClient;

namespace alainsoftech.core.Infrastructure.DbClient
{
    [Serializable]
    public class MySqlDbContext : IMySqlDbContext
    {
        private string _strConnection;
        public MySqlDbContext()
        {

        }
        public MySqlDbContext(ConnectionParams connectionParams)
        {
            this._strConnection = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};SslMode=none",
                Crypto.Decode(CryptoKeys.EncryptionKey, connectionParams.Host),
                Crypto.Decode(CryptoKeys.EncryptionKey, connectionParams.Port),
                Crypto.Decode(CryptoKeys.EncryptionKey, connectionParams.Database),
                Crypto.Decode(CryptoKeys.EncryptionKey, connectionParams.Username),
                Crypto.Decode(CryptoKeys.EncryptionKey, connectionParams.Password));
            this.Connection = new MySqlConnection(this._strConnection);
            this.Host = connectionParams.Host;
            this.Database = connectionParams.Database;
        }
        public MySqlConnection Connection { get; private set; }

        public MySqlTransaction Transaction { get; set; }

        public bool TransactionEnabled { get; private set; }

        public string Host { get; private set; }

        public string Database { get; private set; }

        public object Clone()
        {
            MySqlDbContext clonedObject = new MySqlDbContext();
            clonedObject.Host = string.Copy(this.Host);
            clonedObject.Database = string.Copy(this.Database);
            clonedObject.Connection = (MySqlConnection)this.Connection.Clone();
            return clonedObject;
        }

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
                this.Connection = new MySqlConnection(this._strConnection);
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
    }
}
