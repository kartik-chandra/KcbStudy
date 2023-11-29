using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kcb.Logger
{
    public interface IKcbLogger
    {
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Error(Exception ex);
        void Debug(string logText);
        void Fatal(string logText);
    }
}
