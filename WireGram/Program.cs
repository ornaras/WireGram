using Quartz;
using Serilog;

namespace WireGram;

public static class Program
{
    public static void Main(string[] args)
    {
var builder = Host.CreateApplicationBuilder(args);
        builder.ConfigureSerilog();
        builder.ConfigureQuartz();
        var host = builder.Build();
        host.Run();
    }

    public static void ConfigureSerilog(this HostApplicationBuilder builder) => 
builder.Services.AddSerilog(conf => conf
    .WriteTo.File("/var/log/wiregram.log")
    .WriteTo.Console()
);

    public static void ConfigureQuartz(this HostApplicationBuilder builder)
    {
        builder.Services.AddQuartz();
        builder.Services.AddQuartzHostedService(o =>
        {
            o.WaitForJobsToComplete = true;
        });
    }
}
