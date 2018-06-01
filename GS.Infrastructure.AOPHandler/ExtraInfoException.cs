using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GS.Entlib.AOPHandler
{
    public class ExtraDebugInfoException:Exception
    {
        public string ExtraDebugInfo { get; set; }

        public ExtraDebugInfoException(string extraInfo,Exception e):base(extraInfo,e)
        {
            this.ExtraDebugInfo = extraInfo;
        }
        
    }
}
