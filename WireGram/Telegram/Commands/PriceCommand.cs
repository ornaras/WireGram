using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WireGram.Abstractions;

namespace WireGram.Telegram.Commands
{
    internal class PriceCommand : IBotCommand
    {
        public async Task Execute(ITelegramBotClient bot, ChatId chat, params string[] args)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Список цен:");
            var prices = Pricelist.Prices;
            foreach (var (m, p) in prices)
            {
                builder.Append($"  от <b>{m}</b>");
                builder.Append($" {(m.ToString()[^1] == '1' ? "месяца" : "месяцев")} - ");
                builder.AppendLine($"<b>{p}</b> руб.");
            }
            await bot.SendMessage(chat, builder.ToString(), ParseMode.Html);
        }

        public Task ExecuteAdmin(ITelegramBotClient bot, ChatId chat, params string[] args) 
            => Execute(bot, chat, args);
    }
}
