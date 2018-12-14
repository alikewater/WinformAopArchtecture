using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;

namespace GS.Entlib.AOPHandler
{
    [ConfigurationElementType(typeof(CustomCallHandlerData))]
    public class LockCallHandler:ICallHandler
    {
        public LockCallHandler(int order,bool output)
        {
            this.Order = order;
            this.Output = output;
        }

        /// <summary>
        /// 构造函数，此处不可省略，否则会导致异常
        /// </summary>
        /// <param name="attributes">配置文件中所配置的参数</param>
        public LockCallHandler(NameValueCollection attributes)
        {
            //从配置文件中获取key，如不存在则指定默认key
            this.Order = String.IsNullOrEmpty(attributes["Order"]) ? 1 : int.Parse(attributes["Order"].ToString());
            this.Output = String.IsNullOrEmpty(attributes["Output"]) ?true : bool.Parse(attributes["Order"].ToString());
        }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Type t = input.MethodBase.GetType();
            try
            {
                Monitor.Enter(t);
                if(this.Output)
                    Logger.Write("Get Lock " + input.MethodBase.Name, "General", 1);
                IMethodReturn result = getNext()(input, getNext);

                return result;
            }
            catch (Exception ex)
            {
                if (!(ex is ConfigurationErrorsException) && !(ex is ExtraDebugInfoException))
                {
                    string msg = RuntimeInfoCollector.GenerateInputLogMsg(input);
                    ExtraDebugInfoException extraEx = new ExtraDebugInfoException(
                        "[extraInfo:" + msg + ",OriginInfo:" + ex.Message + "]", ex);
                    throw extraEx;
                }
                else
                    throw ex;
                 
            }
            finally
            {
                if (this.Output)
                    Logger.Write("Free Lock " + input.MethodBase.Name, "General", 1);
                Monitor.Exit(t);
            }
             
        }

        public int Order
        {
            get;
            set;
        }

        public bool Output
        {
            get;
            set;
        }
    }
}
