using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity.Utility;

namespace GS.Entlib.Extensions.Unity
{
    public class AutoInterception: UnityContainerExtension
    {
        protected override void Initialize()
        {
            base.Context.Strategies.AddNew<AutoInstanceInterceptionStrategy>(UnityBuildStage.Setup);
            base.Context.Strategies.AddNew<AutoTypeInterceptionStrategy>(UnityBuildStage.PreCreation);
            TransparentProxyInterceptor interceptor = new TransparentProxyInterceptor();
            this.Container.RegisterInstance<IInterceptor>(typeof(IInterceptor).AssemblyQualifiedName, interceptor, new ContainerControlledLifetimeManager());
        }
        public IUnityContainer RegisterInterceptor(IInterceptor interceptor)
        {
            Guard.ArgumentNotNull(interceptor, "interceptor");
            this.Container.RegisterInstance<IInterceptor>(typeof(IInterceptor).AssemblyQualifiedName, interceptor, new ContainerControlledLifetimeManager());
            return this.Container;
        }
    }
}
