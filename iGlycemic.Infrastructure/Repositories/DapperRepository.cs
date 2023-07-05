using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGlycemic.Infrastructure.Repositories
{
    public abstract class DapperRepositoryBase
    {
        public DapperRepositoryBase()
        {
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);
        }
        public virtual T QueryAsNoTrackingFirstOrDefault<T>(string conn, string sql, object parametros = null, int? timeout = null)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            using (var db = new SqlConnection(conn))
            {
                return db.QueryFirstOrDefault<T>(sql, parametros, commandTimeout: timeout);
            }
        }

        public virtual List<T> QueryAsNoTracking<T>(string conn, string sql, object parametros = null, int? timeout = null)
        {


            DefaultTypeMap.MatchNamesWithUnderscores = true;

            using (var db = new SqlConnection(conn))
            {
                return db.Query<T>(sql, parametros, commandTimeout: timeout).ToList();
            }
        }
    }
}
