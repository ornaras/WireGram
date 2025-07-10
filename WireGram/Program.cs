using Serilog;
using WireGram;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSerilog(conf => conf
    .WriteTo.File("/var/log/wiregram.log")
    .WriteTo.Console()
);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
