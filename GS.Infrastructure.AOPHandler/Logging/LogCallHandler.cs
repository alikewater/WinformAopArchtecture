using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GS.Entlib.AOPHandler
{

    [ConfigurationElementType(typeof(CustomCallHandlerData))]
    public class LogCallHandler:ICallHandler
    {
        public string Footer
        { get; private set; }
        
        public string Header
        { get; private set; }

         /// <summary>
        /// 构造函数，此处不可省略，否则会导致异常
        /// </summary>
        /// <param name="attributes">配置文件中所配置的参数</param>
        public LogCallHandler(NameValueCollection attributes)
        {
            //从配置文件中获取key，如不存在则指定默认key
            this.Order = String.IsNullOrEmpty(attributes["Order"]) ? 1 : int.Parse(attributes["Order"].ToString());
            this.Header = String.IsNullOrEmpty(attributes["Header"]) ? "" : attributes["Header"];
            this.Footer = String.IsNullOrEmpty(attributes["Footer"]) ? "" : attributes["Footer"];
        }

        public LogCallHandler(int order,string header,string footer)
        {
            this.Order = order;
            this.Footer = footer;
            this.Header = header;
        }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            string msg = string.Empty;
            try
            {
                Logger.Write(Header, "General", 1);
                msg = RuntimeInfoCollector.GenerateInputLogMsg(input);
                Logger.Write(msg, "General", 1);
 
                IMethodReturn result = getNext()(input, getNext);

                Logger.Write(RuntimeInfoCollector.GenerateOutputLogMsg(result),"General",1);

                return result;
            }
            catch (Exception ex)
            {

                if (!(ex is ConfigurationErrorsException) && !(ex is ExtraDebugInfoException))
                {
                    ExtraDebugInfoException extraEx = new ExtraDebugInfoException(
                        "[extraInfo:"+msg+",OriginInfo:"+ex.Message+"]", ex);
                    throw extraEx;
                }
                else
                    throw ex;
            }
            finally
            {
                Logger.Write(Footer, "General", 1);
            }
            
        } 

        public int Order
        {
            get;
            set;
        }
    }
}
