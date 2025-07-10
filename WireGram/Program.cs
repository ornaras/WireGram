using Quartz;
using Serilog;
using Telegram.Bot;
using WireGram.Telegram;

namespace WireGram;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.ConfigureSerilog();
        builder.ConfigureQuartz();
        builder.ConnectTelegramBot();
        var host = builder.Build();
        host.Run();
    }

    public static void ConfigureSerilog(this HostApplicationBuilder builder) => 
        builder.Services.AddSerilog(conf => conf
            .WriteTo.File("/var/log/wiregram.log")
            .WriteTo.Console()
        );

    public static void ConnectTelegramBot(this HostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ITelegramBotClient>(sp =>
            new TelegramBotClient(builder.Configuration["Telegram:Token"]!)
        );
        builder.Services.AddScoped<UpdateHandler>();
        builder.Services.AddScoped<ReceiverService>();
        builder.Services.AddHostedService<PollingService>();
    }

    public static void ConfigureQuartz(this HostApplicationBuilder builder)
    {
        builder.Services.AddQuartz();
        builder.Services.AddQuartzHostedService(o =>
        {
            o.WaitForJobsToComplete = true;
        });
    }
}
