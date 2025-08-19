using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AdfsaLabAPI.Services
{
    public class UserService
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["LIMSConnection"].ConnectionString;

        private static readonly string key = "12345678901234567890123456789012";

        private static readonly string iv = "1234567890123456";
        public int? ValidateUser(string sUsername, string sPassword)
        {
            string sPasswordHash = EncryptQRCODE(sPassword);

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ValidateUser", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", sUsername);
                cmd.Parameters.AddWithValue("@Password", sPasswordHash);

                SqlParameter userIdParam = new SqlParameter("@UserId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(userIdParam);

                con.Open();
                cmd.ExecuteNonQuery();

                if (userIdParam.Value != DBNull.Value)
                    return Convert.ToInt32(userIdParam.Value);

                return null;
            }
        }

        public string CreateApiKey(int userId, int expiryMinutes = 60)
        {
            string apiKey;

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_CreateApiKey", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ExpiryMinutes", expiryMinutes);

                SqlParameter outputParam = new SqlParameter("@ApiKey", SqlDbType.NVarChar, 128)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputParam);

                con.Open();
                cmd.ExecuteNonQuery();

                apiKey = outputParam.Value.ToString();
            }

            return apiKey;
        }

      
        public bool IsValidApiKey(string apiKey)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ValidateApiKey", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApiKey", apiKey);

                con.Open();
                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result) == 1;
            }
        }

        public  string EncryptQRCODE(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }

                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public  string DecryptQRCODE(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}