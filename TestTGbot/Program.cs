using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;

namespace TelegramBotExperiments
{

    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5454621654:AAEyYBwhSRkrfTAQbw62rlQz90knA3M1_qM");
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update, Newtonsoft.Json.Formatting.Indented));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;

                switch (message!.Type)
                {
                    case Telegram.Bot.Types.Enums.MessageType.Unknown:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Text:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Photo:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Audio:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Video:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Voice:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Document:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Sticker:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Location:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Contact:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Venue:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Game:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.VideoNote:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Invoice:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.SuccessfulPayment:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.WebsiteConnected:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChatMembersAdded:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChatMemberLeft:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChatTitleChanged:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChatPhotoChanged:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.MessagePinned:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChatPhotoDeleted:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.GroupCreated:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.SupergroupCreated:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChannelCreated:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.MigratedToSupergroup:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.MigratedFromGroup:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Poll:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Dice:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.MessageAutoDeleteTimerChanged:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ProximityAlertTriggered:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.WebAppData:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.VideoChatScheduled:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.VideoChatStarted:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.VideoChatEnded:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.VideoChatParticipantsInvited:
                        break;
                    default:
                        break;
                }

                //if (message!.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                //{
                //    if (message.Text!.ToLower() == "/start")
                //    {
                //        await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!");
                //        return;
                //    }
                //}
                
                await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!");
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
            Console.ForegroundColor = ConsoleColor.Green;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                //AllowedUpdates = new Telegram.Bot.Types.Enums.UpdateType[] { Telegram.Bot.Types.Enums.UpdateType.Message },

                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken);

            Console.ReadLine();
        }
    }
}