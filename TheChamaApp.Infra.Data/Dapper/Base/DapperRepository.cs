using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace TheChamaApp.Infra.Data.Dapper.Base
{
    public class DapperRepository
    {
        #region # Propriedades

        private readonly string Connection;

        #endregion

        #region # Constructor
        public DapperRepository()
        {
            this.Connection = GetConnection();
        }
        #endregion

        #region # Methods
        public IEnumerable<T> ExecuteSelect<T>(string Sql, object param = null)
        {
            using (var con = new MySqlConnection(Connection))
            {
                return con.Query<T>(Sql, param, commandType: CommandType.StoredProcedure);
            }
        }

        public T ExecuteSelectUnique<T>(string sql, object param = null)
        {
            using (var con = new MySqlConnection(Connection))
            {
                return con.QueryFirstOrDefault<T>(sql, param);
            }
        }

        #endregion

        #region # Private Methods

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        private string GetConnection()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

           return this.Decrypt(config.GetSection("ConnectionStrings:Connection").Value);        }

        #endregion
    }
}
