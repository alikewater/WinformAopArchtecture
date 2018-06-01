using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Transactions;

namespace GS.Entlib.AOPHandler
{
    [Assembler(typeof(TransactionCallHandlerDataAssembler))]
    public class TransactionCallHandlerData : CallHandlerData
    {
        [ConfigurationProperty("order", DefaultValue = 0)]
        public int Order
        {
            get { return (int)base["order"]; }
            set { base["order"] = value; }
        }

        [ConfigurationProperty("level", DefaultValue = (int)IsolationLevel.Unspecified)]
        public System.Transactions.IsolationLevel Level
        {
            get { return (IsolationLevel)base["order"]; }
            set { base["order"] = value;  }

        }
    }
}
