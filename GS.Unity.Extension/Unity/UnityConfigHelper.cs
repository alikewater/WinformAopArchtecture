using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace GS.Entlib.Extension.Unity
{
    public class EntlibConfigHelper
    {
        public static void LoadUnityConfigFile(IUnityContainer container, string containerName, string exeConfigFileName)
        {
            
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap 
            {
                 ExeConfigFilename = exeConfigFileName
            };

            UnityConfigurationSection unitySection = 
                ConfigurationManager.OpenMappedExeConfiguration(fileMap,ConfigurationUserLevel.None)
                .GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
            if (unitySection == null)
            {
                throw new ConfigurationErrorsException("unity section missing!");
            }
            
            if (string.IsNullOrEmpty(containerName))
            {
                unitySection.Configure(container);
                
            }
            else
            {
                unitySection.Configure(container, containerName);
            }
            
        }
    
        
         
    }
}
