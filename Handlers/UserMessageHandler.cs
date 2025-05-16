using Telegram.Bot.Types;

namespace WireGram
{
    internal partial class Bot
    {
        private static async Task OnMessage(Message msg)
        {
            if (msg.From!.Id == Configuration.AdminId &&
                await OnAdminMessage(msg)) return;
        }
    }
}
