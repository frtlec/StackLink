using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        public object UserName => _loggingEvent.UserName;
        public string LogDateTime => _loggingEvent.TimeStamp.ToString("yyyy-MM-dd'T'HH:mm:ss");
        public object Message => _loggingEvent.MessageObject;
    }
}
