﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace ResultObjectVsException
{
    public class Program
    {
       public static void Main(string[] args)
        {
            ManualConfig ignoreFluentResultsConfig = ManualConfig.CreateMinimumViable();
            ignoreFluentResultsConfig.WithOption(ConfigOptions.DisableOptimizationsValidator,true);
            BenchmarkRunner.Run<SpeedComparisonBenchmark>(ignoreFluentResultsConfig);
        }

        public class SpeedComparisonBenchmark
        {
            private readonly long _numberOfIterations = 1_000_000;
            #region Without errors
            [Benchmark]
            public void UsingResultObject_WithoutArgumentErrors()
            {
                for (int i = 0; i < _numberOfIterations; i++)
                {
                    var result = NotificationService.PublishMessage_WithResultObject($"username{i}", "DOMAIN", "You have won lottery!");

                    if (result.IsSuccess)
                    {
                        //custom code
                        // in real use case we could do something with returned "result.Value" value if needed.
                    }
                    else
                    {
                        //custom code
                        // in real use case we could do something with information that action failed. Like to stop loop.
                    }

                }
            }
            [Benchmark]
            public void UsingExceptions_WithoutArgumentErrors()
            {
                for (int i = 0; i < _numberOfIterations; i++)
                {
                    try
                    {
                        string returnedValue = NotificationService.PublishMessage_WithException($"username{i}", "DOMAIN", "You have won lottery!");
                        // in real use case we could do something with returned string value if needed.
                    }
                    catch (Exception)
                    {
                        // custom code
                    }
                }
            }
            #endregion
            #region With errors
            [Benchmark]
            public void UsingResultObject_WithArgumentErrors()
            {
                for (int i = 0; i < _numberOfIterations; i++)
                {
                    var result = NotificationService.PublishMessage_WithResultObject($"username{i}","domain","You won't win lottery because your domain is not valid!");
                    if (result.IsSuccess)
                    {
                        //custom code
                        // in real use case we could do something with returned "result.Value" value if needed.
                    }
                    else
                    {
                        //custom code
                        // in real use case we could do something with information that action failed. Like to stop loop.
                    }
                }
            }
            [Benchmark]
            public void UsingExceptions_WithArgumentErrors()
            {
                for (int i = 0; i < _numberOfIterations; i++)
                {
                    try
                    {
                        string returnedValue = NotificationService.PublishMessage_WithException($"username{i}","domain","You won't win lottery because your domain is not valid!");
                    }
                    catch (Exception)
                    {
                        // custom code
                    }
                }
            }
            #endregion
        }
    }
}