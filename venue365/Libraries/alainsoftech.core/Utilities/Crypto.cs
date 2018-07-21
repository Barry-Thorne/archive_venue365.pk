using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace alainsoftech.core.Utilities
{
    public class Crypto
    {
        public static string EncryptPassword(string password)
        {
            byte[] passwordBytes = Encoding.Default.GetBytes(password);
            byte[] encryptedPasswordBytes = null;

            SHA256 sha256Hasher = SHA256Managed.Create();
            encryptedPasswordBytes = sha256Hasher.ComputeHash(passwordBytes);
            return Convert.ToBase64String(encryptedPasswordBytes);
        }
    }
}
