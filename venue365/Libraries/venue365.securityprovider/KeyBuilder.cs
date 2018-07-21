using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace venue365.securityprovider
{
    public class KeyBuilder
    {
        public static string Build(params string[] param)
        {
            if(param == null || param.Length < 1)
            {
                throw new ArgumentNullException(nameof(param));
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach(string s in param)
            {
                stringBuilder.Append(s);
            }
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(stringBuilder.ToString()));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
