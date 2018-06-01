using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace GS.Entlib.Extension.Logging
{
    [ConfigurationElementType(typeof(CustomFormatterData))]
    public class SimpleLogFormatter:LogFormatter
    {
        private NameValueCollection Attributes = null;

        public SimpleLogFormatter(NameValueCollection attributes)
        {
            this.Attributes = attributes;
        }
        public override string Format(LogEntry log)
        {
            string delimiter = string.Empty;
            if (this.Attributes != null && this.Attributes.Keys.Cast<string>().Contains("delimiter"))
                delimiter = this.Attributes["delimiter"].ToString();
             
            using (StringWriter s = new StringWriter())
            {
                //时间，机器，级别，用户信息（TreadLocal），内容
                s.Write(delimiter);
                s.Write(log.TimeStamp + ",");
                s.Write(log.MachineName+",");
                s.Write(log.Severity+":");
                if(log.ExtendedProperties.Keys.Contains("user"))
                s.Write(log.ExtendedProperties["user"]+",");
                s.Write(log.Message);

                return s.ToString();
            }
        }
    }
}
