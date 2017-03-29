using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace AppInsightOwinDeepDive.Helpers
{
    public class AppInsightHelper
    {
        public static void LogMetric(Action action, string eventName)
        {
            LogMetric(action, eventName, null);
        }

        public static void LogMetric(Action action, string eventName, Dictionary<string, string> properties)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var telemetryClient = new TelemetryClient();
            var eventTelemetry = new EventTelemetry()
            {
                Name = eventName,
            };

            eventTelemetry = AssignPropertiesIfAny(eventTelemetry, properties);

            action();

            stopwatch.Stop();
            eventTelemetry.Properties.Add("TimeToRun (ms)", stopwatch.Elapsed.TotalMilliseconds.ToString());
            telemetryClient.TrackEvent(eventTelemetry);
        }

        private static EventTelemetry AssignPropertiesIfAny(EventTelemetry eventTelemetry, Dictionary<string, string> properties)
        {
            if (properties != null)
            {
                foreach (var property in properties)
                {
                    eventTelemetry.Properties.Add(property.Key, property.Value);
                }
            }

            return eventTelemetry;
        }
    }
}