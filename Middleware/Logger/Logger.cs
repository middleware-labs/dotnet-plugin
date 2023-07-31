using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;

namespace Middleware.Logger;

public class Logger
{
    private static readonly ServiceProvider ServiceProvider = new ServiceCollection()
        .AddLogging(
            loggingBuilder => loggingBuilder
                .SetMinimumLevel(LogLevel.Debug)
                .AddOpenTelemetry(
                    options => options.AddConsoleExporter()
                    )
        )
        .BuildServiceProvider();
    
    private static readonly ILogger LoggerInstance = ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<Logger>();

    private Logger()
    {
        
    }

    public static void Info(string log)
    {
        Log(log, LogLevel.Information);
    }
    
    public static void Warning(string log)
    {
        Log(log, LogLevel.Warning);
    }
    
    public static void Debug(string log)
    {
        Log(log, LogLevel.Debug);
    }
    
    public static void Error(Exception exception)
    {
        Log(exception);
    }
    
    private static void Log(string log, LogLevel logLevel)
    {
        LoggerInstance.Log(logLevel, log);
    }
    
    private static void Log(Exception exception)
    {
        LoggerInstance.LogError(exception, exception.Message);
    }
}
