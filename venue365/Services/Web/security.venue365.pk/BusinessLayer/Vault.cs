using security.venue365.pk.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace security.venue365.pk.BusinessLayer
{
    public class Vault : IVault
    {
        private IVaultData _vaultData;
        public Vault(IVaultData vaultData)
        {
            this._vaultData = vaultData;
        }
        public void Add(string key, string input)
        {
            try
            {
                _vaultData.DbContext.OpenConnection(true);
                _vaultData.Add(key, input);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"Add(key, input)\"{4}  Class > {5}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    Environment.NewLine,
                    Environment.NewLine,
                    this.GetType().ToString()), ex);
            }
            finally
            {
                _vaultData.DbContext.CloseConnection(true);
            }
        }

        public string Get(string key)
        {
            try
            {
                _vaultData.DbContext.OpenConnection(true);
                return _vaultData.Get(key);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error > \"{0}\" {1} Error Type > \"{2}\" {3} Method > \"Get(Key, input)\"{4}  Class > {5}",
                    ex.Message,
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    Environment.NewLine,
                    Environment.NewLine,
                    this.GetType().ToString()), ex);
            }
            finally
            {
                _vaultData.DbContext.CloseConnection(true);
            }
        }
    }
}