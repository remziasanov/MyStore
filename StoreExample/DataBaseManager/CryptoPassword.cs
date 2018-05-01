using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace StoreExample.DataBaseManager
{
    public class CryptoPassword
    {
        // метод для хэширования пароля
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value))
                );
        }
    }
}