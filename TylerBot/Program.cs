using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TylerBot.Models;

internal class Program
{
    private static readonly ThreadLocal<Random> random =
        new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));

    private static async Task Main(string[] args)
    {
        var token = "8147867041:AAFy_KhxsfMAvrWi9IXobEyh6-_lR9tKklM";
        using var cts = new CancellationTokenSource();
        var bot = new TelegramBotClient(token, cancellationToken: cts.Token);

        List<string> names =
        [
            "Корнелиус",
            "Руперт",
            "Ленни",
            "Трэвис",
            "Мистер Тейлор",
            "Оззи",
            "Гарриет",
            "Тревор"
        ];

        var isTest = false;

        var me = await bot.GetMe();
        await bot.DeleteWebhook();
        await bot.DropPendingUpdates();

        var chats = new List<ChatModel>();

        string GetName()
        {
            int index = random.Value.Next(names.Count);
            return names[index];
        }

        async Task SendWelcomeMessage(long chatId)
        {
            await bot.SendMessage(
                chatId: chatId,
                text: $"Привет, {GetName()}. \r\nТы только что нарушил первое правило. \r\nНо раз уж ты здесь, запомни: \r\nЭто не игра. Это — твоя новая реальность. \r\n\r\nВ 18 часов ты получишь первое задание. \r\nДо тех пор — молчи.",
                cancellationToken: cts.Token);
        }

        async Task FirstStep(ChatModel chat)
        {
            chat.Step = 2;

            await bot.SendMessage(
                chatId: chat.Id,
                text: $"{GetName()},\r\n\r\nЯ влез в этих ублюдков из «First National Debt». 300% годовых – знаешь, что это значит? Это значит, они уже мертвы. Просто еще не легли в землю.\r\n\r\nПоговорил с одним тамошним яйцеголовым. Ох уж эти сладкие звуки – как трещали его пальцы, когда он вводил пароль. Выдал мне все их логины, показал систему. Их база дырявая, как обещания менеджера по продажам. Но этот слизняк оказался никчемным – ни прав доступа, ни мозгов, чтобы их получить.\r\n\r\nТеперь твой ход. ВЗЛОМАЙ ИХ. СОЖРИ ВСЁ ДО ОСНОВАНИЯ.\r\n\r\nНе оставляй следов.\r\n\r\n—T",
                cancellationToken: cts.Token);

            await Task.Delay(3000);

            await bot.SendMessage(
                chatId: chat.Id,
                text: $"Ссылка на их корпоративного ублюдка: https://t.me/FirstNationalDebtBot.\r\n\r\nP.S. Если тебе нужно – таблица с клиентами называется client_case.\r\nКогда закончишь – шли код операции на местный терминал.\r\n\r\n—T",
                cancellationToken: cts.Token);
        }

        async Task SecondStep(ChatModel chat, string result)
        {
            if (result == "7T6J44A")
            {
                await bot.SendMessage(
                    chatId: chat.Id,
                    text: "Чистая работа.\r\nПроект Разгром тебя отмечает.\r\n\r\n—T",
                    cancellationToken: cts.Token);
                await bot.SendMessage(
                    chatId: chat.Id,
                    text: "Я вижу эти ублюдки запустили какой-то протокол. \r\nХа. \r\nОни думают, что успеют спрятаться. \r\nМы уничтожим их целиком. \r\nСледующая цель - Blackwater Logistics. \r\nЖди инструкций.\r\n\r\n—T",
                    cancellationToken: cts.Token);

                chat.Step = 3;
            }
            else
            {
                await bot.SendMessage(
                    chatId: chat.Id,
                    text: "Ты облажался.\r\nПроект Разгром под угрозой.\r\nСоберись и попробуй снова.\r\n\r\n—T",
                    cancellationToken: cts.Token);

                await Task.Delay(1000);

                await bot.SendMessage(
                    chatId: chat.Id,
                    text: $"Знаешь, {GetName()}, в самолетах нет кнопок 'назад'.\r\nВведи правильный код.\r\n—T",
                    cancellationToken: cts.Token);
            }
        }

        async Task ThirdStep(ChatModel chat)
        {
            chat.Step = 4;

            await bot.SendMessage(
                chatId: chat.Id,
                text: $"{GetName()}, эти ублюдки из Blackwater прикрылись какой-то JWT хуйнёй.\r\nЯ взял их техника в подвале - пять минут, и он уже пел как канарейка.\r\nРазмял его знатно, но этот чертов токен мне не поддаётся.\r\n\r\nВот что есть:\r\nКлюч - \"blackwater2025\" плюс текущий год (как будто это что-то меняет). \r\nАх да, еще там было о secret key cerberus protected... \r\nЧто-то такое он бормотал, перед тем, как отключиться.\r\n🔹 Какой-то кривой токен: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoiUm9iZXJ0IFBhdWxzb24iLCJhZG1pbiI6ZmFsc2V9.kGlIfved0liZ0kB5oueW7l5VI-1yPzme9eYlYbtCbiY...\r\n\r\nСделай мне рабочий. Для пользователя 'tyler'. А еще дай мне права админа.\r\nЧтобы всё тут взлетело нахуй.\r\n\r\n—T",
                cancellationToken: cts.Token);
        }

        async Task FourthStep(ChatModel chat, string result)
        {
            if (result == "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoiVHlsZXIiLCJhZG1pbiI6dHJ1ZX0.EFXCUxyp062mpNyMUrBUV3tusyi4TJVFzmuGrwDGwz8")
            {
                chat.Step = 5;
                await bot.SendMessage(
                    chatId: chat.Id,
                    text: $"Руперт... Ха! Эти идиоты из Blackwater думали, что их «защита» что-то значит.\r\nЯ только что наблюдал, как их сервера превратились в тыкву.\r\n\r\nНо самое смешное?\r\nУ них тоже сработал этот долбаный Cerberus.\r\nИ знаешь что? Связь продержалась чуть дольше...\r\n\r\nКоординаты:\r\n55.7XXXX...37.8Y... (сигнал потерян)\r\n\r\nВидишь? На этот раз больше символов.\r\nЗначит, мы на правильном пути.\r\n\r\nСледующая цель — MantiCore Security.\r\nДобудь полные координаты. Сотри их к чертям.\r\n\r\n—T",
                    cancellationToken: cts.Token);
            }
            else if (result == "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoiVHlsZXIiLCJhZG1pbiI6ZmFsc2V9.Sg3VqlKmMgZ7lH9kuw4hT0Hhh8BxPBhRAP5KYMpLSEE")
            {
                await bot.SendMessage(
                    chatId: chat.Id,
                    text: $"Что это за хуйня, {GetName()}?  \r\nЯ снёс половину их баз, но главный сервер ещё жив.  \r\nАдмин уже вызвал подкрепление.  \r\n \r\nТы что, забыл, зачем мы это делаем?  \r\nНужны права админа. СДЕЛАЙ ПРАВИЛЬНО.\r\n\r\n—T",
                    cancellationToken: cts.Token);
            }
            else
            {
                await bot.SendMessage(
                    chatId: chat.Id,
                    text: $"Блядь.  \r\nИх система отклонила токен.  \r\nТехник, которого я \"убеждал\", уже в больнице.  \r\nПридётся искать нового.  \r\n>  \r\nПопробуй ещё раз. Или я найду того, кто сможет.\r\n\r\n—T",
                    cancellationToken: cts.Token);
            }
        }

        async Task FifthStep(ChatModel chat)
        {
            chat.Step = 6;

            await bot.SendMessage(
                chatId: chat.Id,
                text: $"{GetName()},  \r\n\r\nТри дня. Три долбаных дня я драил их унитазы, пока эти ублюдки из MantiCore строили из себя неприступную крепость.  \r\n\r\nСегодня я нашел их техника.   \r\nОн держался... впечатляюще. Особенно после того, как его пальцы начали хрустеть как сухие ветки. \r\n\r\nПеред тем как отключиться, он пробормотал что-то про \"хор\" и пялился на свой стол. Там я нашел это:  \r\n\r\n0e0e1c112a0c1d17265e4b5c7b  \r\n\r\nЭто не пароль - я проверял. Это их последний рубеж.  \r\n\r\nРазберись с этим дерьмом, пока я готовлю хлорку для их серверов.  \r\n\r\n—T  ",
                cancellationToken: cts.Token);

            await Task.Delay(5521);

            await bot.SendMessage(
                chatId: chat.Id,
                text: $"Ах да, совсем забыл...  \r\nТот технарь, перед тем как откинуться, бормотал еще что-то про \"ядро\".  \r\n\r\nКакое-то дерьмо про \"Core\" и \"основу системы\".  \r\nНаверное, бредил уже.  \r\n\r\nНо если вдруг это окажется полезным...  \r\n\r\n—T  ",
                cancellationToken: cts.Token);

        }

        async Task SixthStep(ChatModel chat, string result)
        {
            if (result == "Manticore1998")
            {
                switch (chat.Attempt)
                {
                    case 1:
                        {
                            await bot.SendMessage(
                                chatId: chat.Id,
                                text: $"Ха! Эти идиоты даже не догадываются, что теперь их \"Cerberus\" работает на нас.  \r\nТолько что на их главном экране всплыло:  \r\nСБОР ГРУППЫ: 55.75319, 37.84206 | 18:00\r\nЯ залью их сервера кислотой. Ты же разберёшься с этим сбором?\r\n—T",
                                cancellationToken: cts.Token);
                            chat.Step = 7;
                            break;
                        }
                    case 2:
                        {
                            await bot.SendMessage(
                                chatId: chat.Id,
                                text: $"Вот и всё. Их \"защита\" теперь — дымящаяся груда металла.  \r\n> На последнем экране я успел разглядеть:  \r\n> **ВСЕ АГЕНТЫ -> 55.75319, 37.84206 | КОД: KILLBILL** \r\n> Интересно, они знают, что мы придём первыми?  \r\n>  \r\n> —T",
                                cancellationToken: cts.Token);
                            break;
                        }
                    case 3:
                        {
                            await bot.SendMessage(
                                chatId: chat.Id,
                                text: $"Готово. Их серверная теперь напоминает ад.  \r\n> На последнем уцелевшем экране:  \r\n> **FINAL ORDER: 55.75319, 37.84206 | 18:00 | NO SURVIVORS**  \r\n>  \r\n> *пауза*  \r\n>  \r\n> P.S. Принеси зажигательную смесь. Нам нужно \"очистить\" территорию.  \r\n>  \r\n> —T",
                                cancellationToken: cts.Token);
                            break;
                        }
                    default:
                        break;
                }
            }
            else
            {
                switch (chat.Attempt)
                {
                    case 1:
                        {
                            await bot.SendMessage(
                                chatId: chat.Id,
                                text: $"Не-а. Их система плюётся ошибками.  \r\nНо я только что видел, как на сервере мелькнуло:  \r\nCERBERUS: 55.7XXXX... Сигнал пропал.\r\nПопробуй ещё раз. Или мне придётся импровизировать.  \r\n—T",
                                cancellationToken: cts.Token);
                            break;
                        }
                    case 2:
                        {
                            await bot.SendMessage(
                                chatId: chat.Id,
                                text: $"Блять! Они активировали блокировку.  \r\nНо перед этим я видел:  \r\n37.8XXXX...** И экран, сука, погас\r\nОсталась последняя попытка. Не облажайся. \r\n—T",
                                cancellationToken: cts.Token);
                            break;
                        }
                    case 3:
                        {
                            await bot.SendMessage(
                                chatId: chat.Id,
                                text: $"Всё. Система заблокирована намертво. \r\nТы облажался.\r\n —T",
                                cancellationToken: cts.Token);

                            await Task.Delay(2000);

                            await bot.SendMessage(
                                chatId: chat.Id,
                                text: $"Надоело это дерьмо. \r\nЯ просто выстрелил в их \"неприступный\" сервер.  \r\nПеред смертью он успел показать:  \r\nCERBERUS FINAL: 55.75319, 37.84206 | CODE: BLOODBATH\r\nP.S. Соберись. Будет грязно. \r\n\r\n—T",
                                cancellationToken: cts.Token);
                            break;
                        }
                    default:
                        break;
                }
            }

            chat.Step = 7;
        }

        var sec = 60_000;
        var timer = new System.Timers.Timer(sec);
        timer.Elapsed += async (sender, e) =>
        {
            if (DateTime.Now.Hour == 18 || isTest)
            {
                foreach (var chat in chats.Where(c => c.Step == 1))
                {
                    switch (chat.Step)
                    {
                        case 1:
                            {
                                await FirstStep(chat);
                                break;
                            }
                        case 3:
                            {
                                await ThirdStep(chat);
                                break;
                            }
                        case 5:
                            {
                                await FifthStep(chat);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        };

        timer.Start();

        bot.OnError += OnError;
        bot.OnMessage += OnMessage;

        Console.WriteLine($"{me.Username} is running... Press Escape to terminate");

        async Task OnError(Exception exception, HandleErrorSource source)
        {
            Console.WriteLine($"Ошибка: {exception.Message}");
            await Task.Delay(2000, cts.Token);
        }

        async Task OnMessage(Message msg, UpdateType type)
        {
            Console.WriteLine($"\n--- Новое сообщение ---");
            Console.WriteLine($"Чат ID: {msg.Chat.Id}");
            Console.WriteLine($"Имя пользователя: {msg.From?.Username ?? "N/A"}");
            Console.WriteLine($"Текст: {msg.Text ?? "N/A"}");
            Console.WriteLine($"Тип: {msg.Type}");
            Console.WriteLine($"Дата: {msg.Date}");
            Console.WriteLine("----------------------\n");

            if (msg.Type == MessageType.Text)
            {
                var chat = chats.FirstOrDefault(c => c.Id == msg.Chat.Id);

                if (chat == null)
                {
                    chats.Add(new ChatModel(msg));
                    await SendWelcomeMessage(msg.Chat.Id);
                }
                else
                {
                    switch (chat.Step)
                    {
                        case 2:
                            {
                                await SecondStep(chat, msg?.Text ?? "");
                                break;
                            }
                        case 4:
                            {
                                await FourthStep(chat, msg?.Text ?? "");
                                break;
                            }
                        case 6:
                            {
                                await SixthStep(chat, msg?.Text ?? "");
                                break;
                            }
                        case 7:
                            {
                                if (chat.Attempt == 3)
                                {
                                    await bot.SendMessage(
                                        chatId: msg.Chat.Id,
                                        text: $"Ты проебал все попытки, но координаты у нас есть.\r\n55.75319, 37.84206  \r\n18:00. Без опозданий.\r\nP.S. Возьми сменную одежду. Будет... мокро.\r\n\r\n—T  ",
                                        cancellationToken: cts.Token);
                                }
                                else
                                {
                                    await bot.SendMessage(
                                        chatId: msg.Chat.Id,
                                        text: $"Что, скучаешь по мне, {GetName()}? \r\nСерверная сгорела. Координаты у тебя.  \r\nОсталось только прийти и не облажаться.  \r\nP.S. Если передумаешь — я найду тебя сам.  \r\n\r\n—T  ",
                                        cancellationToken: cts.Token);
                                }

                                break;
                            }
                        default:
                            {
                                await bot.SendMessage(
                                    chatId: msg.Chat.Id,
                                    text: $"{GetName()},\r\nТерпение — это не про ожидание. Это про готовность разорвать всё в клочья, когда придёт время. \r\nСиди. Жди. Не дергайся.  \r\nЯ вернусь с инструкциями.  \r\n\r\n—T",
                                    cancellationToken: cts.Token);
                                break;
                            }
                    }
                }
            }
            else
            {
                await bot.SendMessage(
                    chatId: msg.Chat.Id,
                    text: $"{GetName()}, ты что, разучился читать?\r\nТолько слова. Только текст.\r\nНикаких картинок. Никаких голосовых.\r\nПопробуй ещё раз. Или Проект Разгром тебя исключит.\r\n\r\n—T",
                    cancellationToken: cts.Token);
            }
        }

        while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
        await cts.CancelAsync();

        timer.Stop();
    }
}
