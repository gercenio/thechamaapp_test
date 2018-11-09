using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Builder;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TheChamaApp.Infra.Data.Interfaces;

namespace TheChamaApp.Infra.Data.Contexto
{
    public class DapperContexto : IDapperContexto
    {
        #region # Properties
        private readonly string _connectionString;
        private IDbConnection _connection;
        public IConfiguration Configuration { get; set; }
        #endregion

        #region # Constructor
        public DapperContexto()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            _connectionString = Microsoft.Extensions.Configuration.ConfigurationExtensions.GetConnectionString(this.Configuration, "Connection");
        }
        #endregion

        #region # Methods

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);

                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }

        #endregion
    }
}
