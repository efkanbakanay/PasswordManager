using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Core.DataAccess.Dapper
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IDbConnection LogonConnection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("LogonConnectionString"));
            }
        }

        public IDbConnection EgitimConnection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("EgitimConnectionString"));
            }
        }

        public IDbConnection KurumlarConnection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("KurumlarConnectionString"));
            }
        }



    }
}
