using Telegram.Bot;
using Telegram.Bot.Polling;

namespace WireGram.Telegram
{
    internal class ReceiverService(ITelegramBotClient botClient, UpdateHandler updateHandler, ILogger<ReceiverService> logger)
    {
        public async Task ReceiveAsync(CancellationToken stoppingToken)
        {
            var receiverOptions = new ReceiverOptions() { DropPendingUpdates = true, AllowedUpdates = [] };

            var me = await botClient.GetMe(stoppingToken);
            logger.LogInformation("Удалось подключиться к боту {BotName}", me.Username ?? "???");

            await botClient.ReceiveAsync(updateHandler, receiverOptions, stoppingToken);
        }
    }
}