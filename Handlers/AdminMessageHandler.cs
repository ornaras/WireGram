using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WireGram
{
    internal partial class Bot
    {
        private const string AdminStartMessage = """
            Доступные <b>административные</b> команды:
            /peeradd - Создать новый узел
            /peers - Показать все узлы
            /extend - Продление узла
            /system - Показать характеристики и метрики системы
            """;

        private static async Task<bool> OnAdminMessage(Message msg)
        {
            if (msg.Text == "/start")
                return await SendAdminStart(msg.Chat.Id);
            return false;
        }

        private static async Task<bool> SendAdminStart(ChatId chatId)
        {
            await Client.SendMessage(chatId, AdminStartMessage, parseMode: ParseMode.Html);
            return false;
        }
    }
}
