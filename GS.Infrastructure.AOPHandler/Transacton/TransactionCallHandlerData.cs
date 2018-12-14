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

        //public enum IsolationLevel
        //{
        //    Serializable,
        //    RepeatableRead,
        //    ReadCommitted,
        //    ReadUncommitted,
        //    Snapshot,
        //    Chaos,
        //    Unspecified
        //}
        [ConfigurationProperty("level", DefaultValue = 1,IsRequired=false)]
        public int Level
        {
            get { return (int)base["level"]; }
            set { base["level"] = value; }

        }

        [ConfigurationProperty("output", DefaultValue = true, IsRequired = false)]
        public bool Output
        {
            get { return (bool)base["output"]; }
            set { base["output"] = value; }

        }
    }
}
