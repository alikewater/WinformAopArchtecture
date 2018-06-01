using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace GS.Entlib.Extensions.Unity
{
    public class AutoTypeInterceptionStrategy : AutoInterceptionStrategy
    {
        public override void PreBuildUp(IBuilderContext context)
        {
            Guard.ArgumentNotNull(context, "context");
            if (!this.CanIntercept(context))
            {
                return;
            }
            if (context.Existing != null)
            {
                return;
            }
            var interceptionPolicy = FindInterceptionPolicy<ITypeInterceptionPolicy>(context);
            ITypeInterceptor interceptor = null;
            if (interceptionPolicy == null)
            {
                interceptor = context.NewBuildUp<IInterceptor>(typeof(IInterceptor).AssemblyQualifiedName) as ITypeInterceptor;
                if (null == interceptor)
                {
                    return;
                }
                if (!interceptor.CanIntercept(context.BuildKey.Type))
                {
                    return;
                }
                interceptionPolicy = new FixedTypeInterceptionPolicy(interceptor);
                context.Policies.Set<ITypeInterceptionPolicy>(interceptionPolicy, context.BuildKey);
                context.Policies.Clear<IInstanceInterceptionPolicy>(context.BuildKey);
            }
            var interceptionBehaviorsPolicy = FindInterceptionPolicy<IInterceptionBehaviorsPolicy>(context);
            if (null == interceptionBehaviorsPolicy)
            {
                var policyInjectionBehavior = new InterceptionBehavior<PolicyInjectionBehavior>();
                policyInjectionBehavior.AddPolicies(context.OriginalBuildKey.Type, context.BuildKey.Type, context.BuildKey.Name, context.Policies);
            }
        }

        private static TPolicy FindInterceptionPolicy<TPolicy>(IBuilderContext context)
            where TPolicy : class, IBuilderPolicy
        {
            return context.Policies.Get<TPolicy>(context.BuildKey, false) ??
                context.Policies.Get<TPolicy>(context.BuildKey.Type, false);
        }
    }
}
