using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Transactions;
 

namespace GS.Entlib.AOPHandler
{
    [ConfigurationElementType(typeof(TransactionCallHandlerData))]
    public class TransactionCallHandler:ICallHandler
    {
        public System.Transactions.IsolationLevel Level { get; private set; }

        public bool Output { get; private set; }

        public TransactionCallHandler(int order,int level,bool output/**/ )
        {
            this.Level = (IsolationLevel)level;// level;
            this.Order = order;
            this.Output = output;
        }

        /// <summary>
        /// 构造函数，此处不可省略，否则会导致异常
        /// </summary>
        /// <param name="attributes">配置文件中所配置的参数</param>
        public TransactionCallHandler(NameValueCollection attributes)
        {
            //从配置文件中获取key，如不存在则指定默认key
            this.Order = String.IsNullOrEmpty(attributes["Order"]) ? 1 : int.Parse(attributes["Order"].ToString());
            this.Level = string.IsNullOrEmpty(attributes["Level"]) ? IsolationLevel.RepeatableRead :
                (IsolationLevel)Enum.Parse(typeof(IsolationLevel), attributes["Level"].ToString());

            this.Output = String.IsNullOrEmpty(attributes["Output"]) ? true : bool.Parse(attributes["Output"].ToString());
        }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            TransactionOptions option = new TransactionOptions();

            option.IsolationLevel = Level;

            using(TransactionScope ts = new TransactionScope(TransactionScopeOption.Required,option))
            {
                try
                {

                    if (Output)
                        Logger.Write("Begin Tran " + input.MethodBase.Name, "General", 1);

                    var result = getNext()(input, getNext);
                    ts.Complete();
                    
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
                    if(Output)
                        Logger.Write("Submit Tran " + input.MethodBase.Name, "General", 1);
                }
                
            }
        }

        public int Order
        {
            get;
            set;
        }
    }
}
