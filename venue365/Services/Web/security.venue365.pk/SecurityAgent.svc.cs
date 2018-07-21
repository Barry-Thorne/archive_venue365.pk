using alainsoftech.core.Infrastructure;
using security.venue365.pk.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace security.venue365.pk
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SecurityAgent" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SecurityAgent.svc or SecurityAgent.svc.cs at the Solution Explorer and start debugging.
    public class SecurityAgent : ISecurityAgent
    {
        public void Add(string key, string input)
        {
            try
            {
                EngineContext.Current.Resolve<IVault>()
                    .Add(key, input);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"Add(key, input)\"{4}  Class > {5}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    Environment.NewLine,
                    Environment.NewLine,
                    typeof(SecurityAgent)), ex);
            }
        }

        public string Get(string key)
        {
            try
            {
                return EngineContext.Current.Resolve<IVault>()
                    .Get(key);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"Get(key, input)\"{4}  Class > {5}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    Environment.NewLine,
                    Environment.NewLine,
                    typeof(SecurityAgent)), ex);
            }
        }
    }
}
