using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace alainsoftech.core.Infrastructure.DbClient
{
    public interface IMySqlDbClient
    {
        MySqlCommand CreateSqlCommand(string query,IMySqlDbContext dbContext, IEnumerable<MySqlParameter> sqlParams = null, CommandType commandType = CommandType.StoredProcedure);
        DataTable GetDataTable(MySqlCommand command);
        DataSet GetDataSet(MySqlCommand command);
        object ExecuteScalar(MySqlCommand command);
        int ExecuteNonQuery(MySqlCommand command);
    }
}
