using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace GS.Entlib.Extensions.Unity.Configuration
{
    public class AutoInterceptorElement : DeserializableConfigurationElement
    {
       
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public InjectionMemberElementCollection Injection
        {
            get { return (InjectionMemberElementCollection)this[""]; }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string TypeName
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

    }
}
