using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace GS.Entlib.Extensions.Unity.Configuration
{
    public class AutoInterceptionElement : ContainerConfiguringElement
    {
        [ConfigurationProperty("interceptor", IsRequired = false)]
        public AutoInterceptorElement Interceptor
        {
            get { return (AutoInterceptorElement)this["interceptor"]; }
            set { this["interceptor"] = value; }
        }
        protected override void ConfigureContainer(IUnityContainer container)
        {
            if (null == Interceptor)
            {
                return;
            }
            Type interceptorType = TypeResolver.ResolveType(this.Interceptor.TypeName);
            IInterceptor interceptor = container.Resolve(interceptorType) as IInterceptor;
            container.RegisterInstance<IInterceptor>(typeof(IInterceptor).AssemblyQualifiedName, interceptor, new ContainerControlledLifetimeManager());           
        }
    }
}
