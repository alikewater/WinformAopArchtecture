using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GS.Entlib.AOPHandler
{
    public class TransactionCallHandlerDataAssembler : IAssembler<ICallHandler, CallHandlerData>
    {
        public ICallHandler Assemble(IBuilderContext context, CallHandlerData objectConfiguration, IConfigurationSource configurationSource, ConfigurationReflectionCache reflectionCache)
        {
            TransactionCallHandlerData handlerData = objectConfiguration as TransactionCallHandlerData;
            return new TransactionCallHandler(handlerData.Level,handlerData.Order);
        }
         
    }
}
