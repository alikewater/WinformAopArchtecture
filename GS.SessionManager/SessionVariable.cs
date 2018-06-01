using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace GS.SessionContextManager
{
    public class SessionVariable
    {
        public static ThreadLocal<string> User = new ThreadLocal<string>();
        public static ThreadLocal<string> Role = new ThreadLocal<string>();
         
    }
}
