using Telegram.Bot.Types;

namespace WireGram.Abstractions
{
    internal interface IBotCommand
    {
        abstract static string Command { get; }

        Task Execute(ChatId chat, params string[] args);
        Task ExecuteAdmin(ChatId chat, params string[] args);
    }
}
