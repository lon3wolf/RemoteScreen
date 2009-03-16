using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Animaonline.Globals
{
    [DebuggerNonUserCode]
    public class Tracer
    {
        public static event EventHandler<TraceEventArgs> OnTrace;

        public static void WriteLine(object value)
        {
            WriteLine(value, TraceCategory.ALL);
        }

        public static void WriteLine(string message)
        {
            WriteLine(message, TraceCategory.ALL);
        }

        public static void WriteLine(object value, TraceCategory type)
        {
            WriteLine(value.ToString(), TraceCategory.ALL);
        }

        public static void WriteLine(string message, TraceCategory type)
        {
            if (OnTrace != null)
            {
                TraceEventArgs teArgs = new TraceEventArgs();
                teArgs.Value = message;
                teArgs.Category = type;
                OnTrace(null, teArgs);
            }
        }

        public static void WriteLineIf(bool condition, object value)
        {
            WriteLineIf(condition, value, TraceCategory.ALL);
        }

        public static void WriteLineIf(bool condition, string message)
        {
            WriteLineIf(condition, message, TraceCategory.ALL);
        }

        public static void WriteLineIf(bool condition, object value, TraceCategory type)
        {
            WriteLineIf(condition, value.ToString(), TraceCategory.ALL);
        }

        public static void WriteLineIf(bool condition, string message, TraceCategory type)
        {
            if (condition)
            {
                WriteLine(message, type);
            }
        }

        private interface ITraceEventArgs
        {
            Tracer.TraceCategory Category { get; set; }
            string Value { get; set; }
        }

        public enum TraceCategory
        {
            DEBUG,
            INFO,
            ERROR,
            FATAL,
            ALL
        }

        public class TraceEventArgs : EventArgs, Tracer.ITraceEventArgs
        {
            public Tracer.TraceCategory Category
            {
                get;
                set;
            }

            public string Value
            {
                get;
                set;
            }
        }
    }
}

