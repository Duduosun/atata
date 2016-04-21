﻿using System;
using System.Text;

namespace Atata
{
    public class SimpleLogManager : LogManagerBase
    {
        private Action<string> writeLineAction;

        public SimpleLogManager(Action<string> writeLineAction = null, string screenshotsFolderPath = null)
            : base(screenshotsFolderPath)
        {
            this.writeLineAction = writeLineAction ?? (x => Console.WriteLine(x));
        }

        public override void Info(string message, params object[] args)
        {
            Log("INFO", message, args);
        }

        public override void Warn(string message, params object[] args)
        {
            Log("WARN", message, args);
        }

        public override void Error(string message, Exception excepton)
        {
            Log("ERROR", string.Format("{0} {1}", message, excepton));
        }

        private void Log(string logLevel, string message, params object[] args)
        {
            StringBuilder builder = new StringBuilder();

            builder.
                Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff")).
                Append(" ").
                Append(logLevel).
                Append(" ").
                AppendFormat(message, args);

            writeLineAction(builder.ToString());
        }
    }
}
