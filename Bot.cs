using Serilog;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WireGram
{
    internal partial class Bot
    {
        public static CancellationTokenSource CancelSource { get; private set; }
        public static TelegramBotClient Client { get; private set; }

        public Bot()
        {
            CancelSource = new CancellationTokenSource();
            Client = new TelegramBotClient(Configuration.Token, 
                cancellationToken: CancelSource.Token);
            Client.DeleteWebhook().Wait();
            Client.StartReceiving(UpdateHandler, ErrorHandler, null, CancelSource.Token);
            Task.Delay(-1).Wait();
        }

        private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update.Message is Message msg) 
                await OnMessage(msg);
        }

        private static async Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
        {
                Log.Logger.Error(error, $"Произошла ошибка в работе Telegram-бота");
        }
    }
}
