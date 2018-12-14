using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace GS.Entlib.AOPHandler
{
    [Assembler(typeof(LogCallHandlerDataAssembler))]
    public class LogCallHandlerData : CallHandlerData
    {
        [ConfigurationProperty("order", DefaultValue = 0,IsRequired=true)]
        public int Order
        {
            get { return (int)base["order"]; }
            set { base["order"] = value; }
        }
        
        [ConfigurationProperty("header", DefaultValue = "",IsRequired=false)]
        public string Header
        {
            get { return (string)base["header"]; }
            set { base["header"] = value; }
        }

        [ConfigurationProperty("footer", DefaultValue = "",IsRequired=false)]
        public string Footer
        {
            get { return (string)base["footer"]; }
            set { base["footer"] = value; }
        }
    }
}
