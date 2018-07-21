using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alainsoftech.core.Infrastructure.DbClient
{
    public class MsSqlDbClient : IDbClient
    {
        public SqlCommand CreateSqlCommand(string query, IDbContext dbContext, IEnumerable<SqlParameter> sqlParams = null, CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, dbContext.Connection);
                command.CommandType = commandType;
                if (dbContext.TransactionEnabled)
                {
                    command.Transaction = dbContext.Transaction;
                }
                if(sqlParams != null)
                {
                    for(int i = 0; i < sqlParams.Count(); i++)
                    {
                        command.Parameters.Add(sqlParams.ElementAt(i));
                    }
                }
                return command;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"CreateSqlCommand\"{4}  Class > {5}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    Environment.NewLine,
                    Environment.NewLine,
                    this.GetType().ToString()), ex);
            }
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"ExecuteNonQuery\"{4}  Class > {5}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    Environment.NewLine,
                    Environment.NewLine,
                    this.GetType().ToString()), ex);
            }
        }

        public object ExecuteScalar(SqlCommand command)
        {
            try
            {
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"ExecuteScalar\"{4}  Class > {5}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    Environment.NewLine,
                    Environment.NewLine,
                    this.GetType().ToString()), ex);
            }
        }

        public DataSet GetDataSet(SqlCommand command)
        {
            try
            {
                DataSet ds = new DataSet();
                using(SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(ds);
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"GetDataSet\"{4}  Class > {5}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    Environment.NewLine,
                    Environment.NewLine,
                    this.GetType().ToString()), ex);
            }
        }

        public DataTable GetDataTable(SqlCommand command)
        {
            try
            {
                DataTable dt = new DataTable();
                using(SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"GetDataTable\"{4}  Class > {5}",
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
