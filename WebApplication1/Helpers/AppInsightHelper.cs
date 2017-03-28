using System;
using System.Diagnostics;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace AppInsightOwinDeepDive.Helpers
{
    public class AppInsightHelper
    {
        public static void LogMetric(Action action, string eventName)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var telemetryClient = new TelemetryClient();
            var eventTelemetry = new EventTelemetry()
            {
                Name = eventName
            };

            action();

            stopwatch.Stop();
            eventTelemetry.Properties.Add("TimeToRun (ms)", stopwatch.ElapsedMilliseconds.ToString());
            telemetryClient.TrackEvent(eventTelemetry);
        }
    }
}