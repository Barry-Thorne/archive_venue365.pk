using alainsoftech.core.Infrastructure.DbClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace security.venue365.pk.DataLayer
{
    public class VaultSqlHelper : IVaultData
    {
        private IMySqlDbClient _dbClient;
        private IMySqlDbContext _dbContext;
        public VaultSqlHelper(IMySqlDbContext dbContext,
            IMySqlDbClient mySqlDbClient)
        {
            this._dbContext = dbContext;
            this._dbClient = mySqlDbClient;
        }

        public IMySqlDbContext DbContext
        {
            get { return _dbContext; }
        }

        public void Add(string key, string input)
        {
            try
            {
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                parameters.Add(new MySqlParameter() {
                    ParameterName = "keyparam",
                    Value = key
                });
                parameters.Add(new MySqlParameter()
                {
                    ParameterName = "valueparam",
                    Value = input
                });
                using (MySqlCommand command = _dbClient.CreateSqlCommand("stp_AddInfo",
                    _dbContext, 
                    parameters, 
                    System.Data.CommandType.StoredProcedure))
                {
                    _dbClient.ExecuteScalar(command);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"Add(key, input)\"{4}  Class > {5}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    Environment.NewLine,
                    Environment.NewLine,
                    this.GetType().ToString()), ex);
            }
        }

        public string Get(string key)
        {
            try
            {
                string value = string.Empty;
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                parameters.Add(new MySqlParameter()
                {
                    ParameterName = "keyparam",
                    Value = key
                });
                using (MySqlCommand command = _dbClient.CreateSqlCommand("stp_GetInfo",
                    _dbContext,
                    parameters,
                    System.Data.CommandType.StoredProcedure))
                {
                    using(DataTable dt = _dbClient.GetDataTable(command))
                    {
                        value = dt.Rows[0]["str_value"].ToString();
                    }
                }
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"Get(Key, input)\"{4}  Class > {5}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    Environment.NewLine,
                    Environment.NewLine,
                    this.GetType().ToString()), ex);
            }
        }
    }
}