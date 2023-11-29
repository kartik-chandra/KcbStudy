namespace Kcb.Logger
{
    public class KcbLogger : IKcbLogger
    {
        private string _LogfilePath;

        public KcbLogger(string logfilePath)
        {
            _LogfilePath = logfilePath;
            SetLogfileName();
        }

        private void SetLogfileName()
        {
            if (!Directory.Exists(_LogfilePath))
            {
                Directory.CreateDirectory(_LogfilePath);
            }

            _LogfilePath = Path.Combine(_LogfilePath, GetCurrentDateLogFile());
        }

        private string GetCurrentDateLogFile()
        {
            DateTime dt = DateTime.Now;
            return string.Format("Log_{0}{1}{2}.txt", dt.Year.ToString("0000"), dt.Month.ToString("00"), dt.Day.ToString("00"));
        }

        private string GetCurrentDatetime()
        {
            DateTime dt = DateTime.Now;
            return string.Format("{0} {1}", dt.ToShortDateString(), dt.ToLongTimeString());
        }

        public void Info(string message)
        {
            WriteLog(message, LogType.INFO);
        }

        public void Warning(string message)
        {
            WriteLog(message, LogType.WARNING);
        }

        public void Error(string message)
        {
            WriteLog(message, LogType.ERROR);
        }

        public void Error(Exception ex)
        {
            WriteLog(ex.ToString(), LogType.ERROR);
        }

        public void Debug(string message)
        {
            WriteLog(message, LogType.DEBUG);
        }

        public void Fatal(string message)
        {
            WriteLog(message, LogType.FATAL);
        }

        private void WriteLog(string message, LogType logType)
        {
            try
            {
                message = string.Format("[{0} | {1}]: {2}" + Environment.NewLine, GetCurrentDatetime(), logType.ToString(), message);

                Console.WriteLine(message);

                File.AppendAllText(_LogfilePath, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

    public enum LogType
    {
        INFO = 1,
        WARNING,
        ERROR,
        DEBUG,
        FATAL
    }
}