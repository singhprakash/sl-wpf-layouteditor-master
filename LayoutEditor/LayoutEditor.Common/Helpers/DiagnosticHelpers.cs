using System;
using System.Diagnostics;

namespace LayoutEditor.Common.Helpers
{
    internal static class DiagnosticHelpers
    {
        public static Stopwatch GetStartedStopWatch()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            return stopWatch;
        }

        public static void DebugWriteStopWatchTime(this Stopwatch stopWatch)
        {
            Debug.WriteLine(GetElapsedTime(stopWatch), "RunTime");
        }

        public static string GetElapsedTime(this Stopwatch stopWatch)
        {
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
        }
    }
}