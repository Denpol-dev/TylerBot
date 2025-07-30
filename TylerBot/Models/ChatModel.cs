using Telegram.Bot.Types;

namespace TylerBot.Models
{
    public class ChatModel
    {
        public long Id { get; set; }
        public string? Username { get; set; }
        public int Step { get; set; }
        public int Attempt { get; set; }

        public ChatModel() { }

        public ChatModel(Message msg)
        {
            Id = msg.Chat.Id;
            Username = msg.From?.Username;
            Step = 1;
            Attempt = 1;
        }

        public static async Task InitDB()
        {
            using var dbContext = new AppDbContext();
            await dbContext.Database.EnsureCreatedAsync();

            Console.WriteLine("Начинаем миграцию данных в PostgreSQL...");

            var chats = new List<ChatModel>
            {
                new()
                {
                    Id = 413089894,
                    Username = "false_visi0n",
                    Step = 3,
                    Attempt = 1
                },
                new()
                {
                    Id = 452928813,
                    Username = "include_19",
                    Step = 3,
                    Attempt = 1
                }
            };

            foreach (var oldChat in chats)
            {
                var existingChat = await dbContext.Chats.FindAsync(oldChat.Id);
                if (existingChat == null)
                {
                    dbContext.Chats.Add(new ChatModel
                    {
                        Id = oldChat.Id,
                        Username = oldChat.Username,
                        Step = oldChat.Step,
                        Attempt = oldChat.Attempt
                    });
                    Console.WriteLine($"Добавлен чат {oldChat.Id} ({oldChat.Username}). Уровень {oldChat.Step}.");
                }
                else
                {
                    Console.WriteLine($"Чат {oldChat.Id} уже существует в базе, пропускаем");
                }
            }

            var changes = await dbContext.SaveChangesAsync();
            Console.WriteLine($"Миграция завершена. Добавлено/обновлено {changes} записей.");
        }
    }
}