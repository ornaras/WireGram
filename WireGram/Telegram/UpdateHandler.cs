using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace WireGram.Telegram
{
    internal partial class UpdateHandler(ILogger<UpdateHandler> logger, IConfiguration conf) : IUpdateHandler
    {
        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "");
            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update.Message is Message msg)
            {
                if(msg.Text?.StartsWith('/') ?? false)
                {
                    var args = msg.Text.Split(' ');
                    if (!_cmds.TryGetValue(args[0][1..], out var cmd)) return;
                    if (msg.Chat.Id.ToString() == conf["AdminId"])
                        await cmd.ExecuteAdmin(botClient, msg.Chat.Id, args[1..]);
                    else
                        await cmd.Execute(botClient, msg.Chat.Id, args[1..]);
                }
            }
        }
    }
}
