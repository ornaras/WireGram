﻿namespace WireGram.Telegram
{
    internal class PollingService(IServiceProvider serviceProvider, ILogger<PollingService> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Запуск длинного опроса {Service}", "Telegram Bot API");
            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = serviceProvider.CreateScope();
                    var receiver = scope.ServiceProvider.GetRequiredService<ReceiverService>();

                    await receiver.ReceiveAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Во время опроса произошла ошибка: ");
                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                }
            }
        }
    }
}
    