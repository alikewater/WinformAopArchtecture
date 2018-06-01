using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace GS.Entlib.Extensions.Unity
{
    public class AutoInstanceInterceptionStrategy : AutoInterceptionStrategy
    {
        public override void PreBuildUp(IBuilderContext context)
        {
            Guard.ArgumentNotNull(context, "context");
            if (!this.CanIntercept(context))
            {
                return;
            }
            IInstanceInterceptionPolicy interceptionPolicy = FindInterceptionPolicy<IInstanceInterceptionPolicy>(context, true);
            if (null == interceptionPolicy)
            {
                IInstanceInterceptor interceptor = context.NewBuildUp<IInterceptor>(typeof(IInterceptor).AssemblyQualifiedName) as IInstanceInterceptor;
                if (null == interceptor)
                {
                    return;
                }
                if (!interceptor.CanIntercept(context.BuildKey.Type))
                {
                    return;
                }
                context.Policies.Set<IInstanceInterceptionPolicy>(new FixedInstanceInterceptionPolicy(interceptor), context.BuildKey);
                context.Policies.Clear<ITypeInterceptionPolicy>(context.BuildKey);
            }

            IInterceptionBehaviorsPolicy interceptionBehaviorsPolicy = FindInterceptionPolicy<IInterceptionBehaviorsPolicy>(context, true);
            if (null == interceptionBehaviorsPolicy)
            {
                var policyInjectionBehavior = new InterceptionBehavior<PolicyInjectionBehavior>();
                policyInjectionBehavior.AddPolicies(context.OriginalBuildKey.Type, context.BuildKey.Type, context.BuildKey.Name, context.Policies);
            }
        }

        private static T FindInterceptionPolicy<T>(IBuilderContext context, bool probeOriginalKey)
            where T : class, IBuilderPolicy
        {
            T policy;
            Type currentType = context.BuildKey.Type;
            policy = context.Policies.Get<T>(context.BuildKey, false) ?? context.Policies.Get<T>(currentType, false);
            if (policy != null)
            {
                return policy;
            }
            if (!probeOriginalKey)
            {
                return null;
            }
            Type originalType = context.OriginalBuildKey.Type;
            policy = context.Policies.Get<T>(context.OriginalBuildKey, false) ?? context.Policies.Get<T>(originalType, false);
            return policy;
        }
    }
}
