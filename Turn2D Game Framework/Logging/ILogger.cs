using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn2D_Game_Framework.Logging
{
    public interface ILogger
    {
        void Log(TraceEventType eventType, int id, string message);
        void Log(TraceEventType eventType, string message);
    }
}
