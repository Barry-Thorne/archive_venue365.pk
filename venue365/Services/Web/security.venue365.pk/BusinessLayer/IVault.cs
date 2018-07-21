using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace security.venue365.pk.BusinessLayer
{
    public interface IVault
    {
        void Add(string key, string input);
        string Get(string key);
    }
}