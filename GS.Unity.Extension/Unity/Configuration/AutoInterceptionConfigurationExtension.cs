using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.Configuration;

namespace GS.Entlib.Extensions.Unity.Configuration
{
    public class AutoInterceptionConfigurationExtension : SectionExtension
    {
        public override void AddExtensions(SectionExtensionContext context)
        {
            context.AddElement<AutoInterceptionElement>("autoInterception");//扩展为了能够使用该配置元素
            context.AddAlias<AutoInterception>("AutoInterception");//扩展为了能够在配置文件中使用该容器扩展
        }
    }
}
