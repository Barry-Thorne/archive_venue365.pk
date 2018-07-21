using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace alainsoftech.core.Configuration
{
    public partial class AppConfig : IConfigurationSectionHandler
    {
        /// <summary>
        /// Creates a configuration section handler.
        /// </summary>
        /// <param name="parent">Parent object.</param>
        /// <param name="configContext">Configuration context object.</param>
        /// <param name="section">Section XML node.</param>
        /// <returns>The created section handler object.</returns>
        public object Create(object parent, object configContext, XmlNode section)
        {
            var config = new AppConfig();

            
            var configNode = section.SelectSingleNode("Configurations");
            config.Host = GetString(configNode.SelectSingleNode("Host"), "value");
            config.Database = GetString(configNode.SelectSingleNode("Database"), "value");
            config.DbUsername = GetString(configNode.SelectSingleNode("DbUsername"), "value");
            config.DbPassword = GetString(configNode.SelectSingleNode("DbPassword"), "value");
            config.DbPort = GetString(configNode.SelectSingleNode("DbPort"), "value");
            config.ApplicationKey = GetString(configNode.SelectSingleNode("ApplicationKey"), "value");
            return config;
        }

        private string GetString(XmlNode node, string attrName)
        {
            return SetByXElement<string>(node, attrName, Convert.ToString);
        }

        private bool GetBool(XmlNode node, string attrName)
        {
            return SetByXElement<bool>(node, attrName, Convert.ToBoolean);
        }

        private T SetByXElement<T>(XmlNode node, string attrName, Func<string, T> converter)
        {
            if (node == null || node.Attributes == null) return default(T);
            var attr = node.Attributes[attrName];
            if (attr == null) return default(T);
            var attrVal = attr.Value;
            return converter(attrVal);
        }
        public string Host { get; private set; }
        public string Database { get; private set; }
        public string DbUsername { get; private set; }
        public string DbPassword { get; private set; }
        public string DbPort { get; private set; }
        public string ApplicationKey { get; private set; }
    }
}
