using OpenTelemetry.Resources;

namespace Middleware;

public class ObservabilityPlugin
{
    public void Initializing()
    {
        Console.WriteLine("Initializing ObservabilityPlugin");  
        Console.WriteLine("Version: v1.0.0");
    }
    
    public ResourceBuilder ConfigureResource(ResourceBuilder builder)
    {
        builder.AddAttributes(new[]
        {
            new KeyValuePair<string, object>("mw.app.lang", "dotnet"),
            new KeyValuePair<string, object>("runtime.metrics.dotnet", "true")
        });
        return builder;
    }
}
