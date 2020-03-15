using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace HotBloodr
{
    public static class TestHelper
    {
        public static Stopwatch m_stopwatch = new Stopwatch();

        public static void MeasureByDateTime(Action action, string logName)
        {
            var startTime = DateTime.Now;

            action();

            var elapsed = (DateTime.Now - startTime).Milliseconds;

            Debug.Log(logName + ": " + elapsed);
        }

        public static void MeasureByEnvironmentTickCount(Action action, string logName)
        {
            var startTick = Environment.TickCount;

            action();

            var elapsed = Environment.TickCount - startTick;

            Debug.Log(logName + ": " + elapsed);
        }

        public static void MeasureByStopwatch(Action action, string logName)
        {
            m_stopwatch.Reset();
            m_stopwatch.Start();

            action();

            m_stopwatch.Stop();

            Debug.Log(logName + ": " + m_stopwatch.ElapsedMilliseconds);
        }
    }
}
