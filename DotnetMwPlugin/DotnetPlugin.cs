using OpenTelemetry.Resources;

namespace DotnetMwPlugin;

public class DotnetPlugin
{
    public void Initializing()
    {
        Console.WriteLine("Initializing DotnetPlugin");  
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
