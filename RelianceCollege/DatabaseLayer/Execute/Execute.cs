using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Execute
{
    public class Execute : IExecute
    {
        private readonly IConfiguration _configuration;
        public Execute(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private string GetConnectionString()
        {
            string connectionStrings = _configuration.GetConnectionString("DefaultConnection");
            return connectionStrings;
        }
        public List<object> ExecuteQuery<T0, T1>(string SqlQuery, object SqlParam, CommandType type = CommandType.StoredProcedure)
        {
            using (SqlConnection sqlcnt = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlcnt.Open();
                    List<object> resp = new List<object>();
                    var result = sqlcnt.QueryMultiple(SqlQuery, SqlParam, commandTimeout: 3000, commandType: type);
                    resp.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed)
                        return resp;
                    resp.Add(result.Read<T1>().ToList());
                    return resp;

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    sqlcnt.Close();
                }

            }
        }

        public List<T0> ExecuteQuery<T0>(string SqlQuery, object SqlParam, CommandType type = CommandType.StoredProcedure)
        {
            using (SqlConnection sqlcnt = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlcnt.Open();                   
                    var result = sqlcnt.QueryMultiple(SqlQuery, SqlParam, commandTimeout: 3000, commandType: type);                    
                    return result.Read<T0>().ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    sqlcnt.Close();
                }

            }
        }
    }
}
