using Quartz;
using Serilog;
using Serilog.Events;
using Telegram.Bot;
using WireGram.Telegram;

namespace WireGram;

internal static class Program
{
    public static IHost HOST { get; private set; }

    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.ConfigureSerilog();
        builder.ConfigureQuartz();
        builder.ConnectTelegramBot();
        HOST = builder.Build()!;
        HOST.Run();
    }

    public static void ConfigureSerilog(this HostApplicationBuilder builder) => 
        builder.Services.AddSerilog(conf => conf
            .MinimumLevel.Override("Quartz", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Warning)
            .WriteTo.File("/var/log/wiregram.log")
            .WriteTo.Console()
        );

    public static void ConnectTelegramBot(this HostApplicationBuilder builder)
    {
        var token = builder.Configuration["Telegram:Token"] ?? 
            throw new ArgumentNullException(null, "Отсутствует токен Telegram-бота");
        builder.Services.AddSingleton<ITelegramBotClient>(sp =>
            new TelegramBotClient(token)
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
