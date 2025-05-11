using Serilog;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WireGram
{
    internal class Bot
    {
        public static CancellationTokenSource CancelSource { get; private set; }
        public static TelegramBotClient Client { get; private set; }

        public Bot()
        {
            CancelSource = new CancellationTokenSource();
            Client = new TelegramBotClient(Configuration.Token, 
                cancellationToken: CancelSource.Token);
            Client.DeleteWebhook().Wait();
            Client.OnMessage += OnMessage;
            Client.OnError += OnError;
        }

        private async Task OnMessage(Message msg, UpdateType type)
        {

        }

        private async Task OnError(Exception error, HandleErrorSource source)
        {
            if(source == HandleErrorSource.FatalError)
                Log.Logger.Fatal(error, $"Произошла критическая ошибка в работе Telegram-бота");
            else
                Log.Logger.Error(error, $"Произошла ошибка в работе Telegram-бота");
        }
    }
}
