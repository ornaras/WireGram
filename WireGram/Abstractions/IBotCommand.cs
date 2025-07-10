using Telegram.Bot;
using Telegram.Bot.Types;

namespace WireGram.Abstractions
{
    internal interface IBotCommand
    {
        Task Execute(ITelegramBotClient bot, ChatId chat, params string[] args);
        Task ExecuteAdmin(ITelegramBotClient bot, ChatId chat, params string[] args);
    }
}
