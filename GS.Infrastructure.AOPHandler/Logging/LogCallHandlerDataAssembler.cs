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
    public class LogCallHandlerDataAssembler: IAssembler<ICallHandler, CallHandlerData>
    {
        public ICallHandler Assemble(IBuilderContext context, CallHandlerData objectConfiguration, IConfigurationSource configurationSource, ConfigurationReflectionCache reflectionCache)
        {
            LogCallHandlerData handlerData = objectConfiguration as LogCallHandlerData;
            return new LogCallHandler( handlerData.Order ,handlerData.Header,  handlerData.Footer );
        }
         
    }
}
