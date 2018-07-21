using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace security.venue365.pk
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISecurityAgent" in both code and config file together.
    [ServiceContract]
    public interface ISecurityAgent
    {
        [OperationContract]
        void Add(string key, string input);
        [OperationContract]
        string Get(string key);
    }
}
