using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alainsoftech.core.Infrastructure.DbClient
{
    public interface IDbClient
    {
        SqlCommand CreateSqlCommand(string query,IDbContext dbContext, IEnumerable<SqlParameter> sqlParams = null, CommandType commandType = CommandType.StoredProcedure);
        DataTable GetDataTable(SqlCommand command);
        DataSet GetDataSet(SqlCommand command);
        object ExecuteScalar(SqlCommand command);
        int ExecuteNonQuery(SqlCommand command);
    }
}
