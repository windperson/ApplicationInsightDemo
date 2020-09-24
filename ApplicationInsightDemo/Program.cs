using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace ApplicationInsightDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = TelemetryConfiguration.CreateDefault();

            configuration.InstrumentationKey = "application_insight_instrumentation_key";
            var telemetryClient = new TelemetryClient(configuration);

            //telemetryClient.TrackTrace("Hello World2!");

            var myMetric = new MetricTelemetry
            {
                Name = "MyCustomMetric",
                Timestamp = DateTimeOffset.Now.Subtract(new TimeSpan(1, 1, 0, 0)),
                Sum = 5678,
                Count = 1234
            };

            telemetryClient.TrackMetric(myMetric);

            telemetryClient.Flush();
            Console.WriteLine("log written");
        }
    }
}
