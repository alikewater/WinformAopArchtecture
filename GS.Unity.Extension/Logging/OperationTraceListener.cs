using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GS.Entlib.Extension.Logging
{
     
    public class OperationTraceListener:RollingFlatFileTraceListener
    {
        public OperationTraceListener(string fileName, string header, string footer, ILogFormatter formatter, 
            int rollSizeKB, string timeStampPattern, RollFileExistsBehavior rollFileExistsBehavior, 
            RollInterval rollInterval) :
            base(fileName,header,footer,formatter,rollSizeKB,timeStampPattern,rollFileExistsBehavior,rollInterval)
        {
   
        }

      
    }
}
