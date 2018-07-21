using alainsoftech.cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using venue365.securityprovider.Constants;
using venue365.securityprovider.SecurityAgentService;
using venue365.securityprovider.Utilities;

namespace venue365.securityprovider
{
    public class SecurityClient
    {
        public static void Add(string key, string input)
        {
            try
            {
                string encodedInput = Crypto.Encode(Keys.EncryptionKey, input);
                SecurityAgentClient client = new SecurityAgentClient();
                client.Add(key, encodedInput);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"Add(key, input)\"{4}  Class > {5}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    Environment.NewLine,
                    Environment.NewLine,
                    typeof(SecurityClient)), ex);
            }
        }
        public static string Get(string key)
        {
            try
            {
                string info = string.Empty;
                string decodedInfo = string.Empty;
                SecurityAgentClient client = new SecurityAgentClient();
                ICacheManager cacheManager = new MemoryCacheManager();
                decodedInfo = cacheManager.Get<string>(key);
                if (string.IsNullOrWhiteSpace(decodedInfo))
                {
                    info = client.Get(key);
                    decodedInfo = Crypto.Decode(Keys.EncryptionKey, info);
                    cacheManager.Set(key, decodedInfo, 1080);
                }
                return decodedInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"Get(key, input)\"{4}  Class > {5}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    Environment.NewLine,
                    Environment.NewLine,
                    typeof(SecurityClient)), ex);
            }
        }
    }
}
