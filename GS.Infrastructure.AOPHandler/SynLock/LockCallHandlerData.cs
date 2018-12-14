using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace GS.Entlib.AOPHandler
{
    [Assembler(typeof(LockCallHandlerDataAssembler))]
    public class LockCallHandlerData : CallHandlerData
    {
        [ConfigurationProperty("order", DefaultValue = 0,IsRequired=true)]
        public int Order
        {
            get { return (int)base["order"]; }
            set { base["order"] = value; }
        }

        [ConfigurationProperty("output", DefaultValue = true,IsRequired=false)]
        public bool Output
        {
            get { return (bool)base["output"]; }
            set { base["output"] = value; }
        }
    }
}
