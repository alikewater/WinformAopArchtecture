using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GS.Entlib.Extension.Caching
{
    public class CacheHelper
    {
        public static ICacheManager Create(string configSource, string cacheName)
        {
            ICacheManager cache;
            FileConfigurationSource config = new FileConfigurationSource(configSource);
            CacheManagerFactory cf = new CacheManagerFactory(config);
            if (string.IsNullOrEmpty(cacheName))
                cache = cf.Create(cacheName);
            else
                cache = cf.CreateDefault();

            return cache;
        }
    }
}
