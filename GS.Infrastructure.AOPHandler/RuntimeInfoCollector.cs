using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GS.Entlib.AOPHandler
{
    internal class RuntimeInfoCollector
    {
        public static string GenerateInputLogMsg(IMethodInvocation input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
             
            sb.Append("User:" + SessionContextManager.SessionVariable.User.Value + ",");
            sb.Append("Role:" + SessionContextManager.SessionVariable.Role.Value + "||");
            sb.Append("Method:" + input.MethodBase.Name + "||");
            sb.Append("Parameters:[");
            for (int idx = 0; idx < input.Inputs.Count; idx++)
            {
                Type t = input.Inputs.GetParameterInfo(idx).ParameterType;

                sb.Append("Type:" + t.ToString() + ",Value:");
                if (t.IsPrimitive || t == typeof(string))
                    sb.Append(input.Inputs[idx]);
                else
                {
                    sb.Append(Newtonsoft.Json.JsonConvert.SerializeObject(input.Inputs[idx]));
                    
                }
                sb.Append("|");
            }
            sb.Remove(sb.Length-1,1);
            sb.Append("]\n");
           
            return sb.ToString();
        }

        public static string GenerateOutputLogMsg(IMethodReturn result)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();

            sb.Append("Result:[");

            object res = result.ReturnValue;
            Type t = res.GetType();
            
            sb.Append("Type:" + t.ToString() + ",Value:");
            if (t.IsPrimitive || t == typeof(string))
                sb.Append(res==null?"null":res.ToString());
            else
            {
                sb.Append(Newtonsoft.Json.JsonConvert.SerializeObject(res));
            }


            sb.Append("]\n");

            return sb.ToString();
        }

    }
}
