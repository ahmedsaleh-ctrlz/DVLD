using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace DVLD
{
    public class clsLogger
    {
        public delegate void LogAction(string Message);
        private event LogAction _LogAction;


        public clsLogger(LogAction Action) 
        {
            _LogAction += Action; 
        }

        public void Log(string Message) 
        {
            _LogAction.Invoke(Message);

        }




        public static void SaveLogInEventLogger(string LogMessage) 
        
        {
            string source = "DVLD";



            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source,"Application");
            }

            EventLog.WriteEntry(source, LogMessage,EventLogEntryType.Information);


        }
    }
}
