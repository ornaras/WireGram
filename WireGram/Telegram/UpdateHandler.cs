using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace WireGram.Telegram
{
    internal class UpdateHandler(ILogger<UpdateHandler> logger) : IUpdateHandler
    {
        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "");
            return Task.CompletedTask;
        }

        public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
