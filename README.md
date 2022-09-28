# ResultObjectVsException

This sample project is part of my blog post @[littleCode](https://www.littlecode.com/our-blog/) created in order to visualize performance gap when using result object to return success or fail information and usage of exceptions to signalize success or failure of an action.

- It is using [BenchmarkDotNet](https://benchmarkdotnet.org/articles/overview.html) to benchmark methods performance.
- For Result pattern implementation I opted for [FluentResults](https://github.com/altmann/FluentResults)

You can change number of iterations freely in `Program.cs` on line 18

```csharp
 public class SpeedComparisonBenchmark
        {
            private readonly long _numberOfIterations = 1_000_000;
```

### To run benchmark position yourself in root of solution and run

```powershell
dotnet run --project .\ResultObjectVsException.csproj -c Release
```
