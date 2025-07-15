using Telegram.Bot.Types;

namespace TylerBot.Models
{
    public class ChatModel
    {
        public long Id { get; set; }
        public string? Username { get; set; }
        public int Step { get; set; }
        public int Attempt { get; set; }

        public ChatModel(Message msg)
        {
            Id = msg.Chat.Id;
            Username = msg.From?.Username;
            Step = 1;
            Attempt = 1;
        }
    }
}