using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
 
namespace DISCORD_Bot

{
    class Program
    {

        DiscordSocketClient client;

        public object Context { get; private set; }

        static void Main(string[] args)
        => new Program().MainAsunc().GetAwaiter().GetResult();

        private async Task MainAsunc()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;
            var token = "OTM2MjcyODkxMzIwODY4ODk0.YfKyFA.I4expSWcB6u7Z_f5nKQyygkPRw";
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();


            Console.ReadLine();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandsHandler(SocketMessage msg)
        {
           
            if(!msg.Author.IsBot)
                switch (msg.Content)
                {

                    case "!Привет":
                        {
                            msg.Channel.SendMessageAsync($"Привет,{msg.Author}");
                            break;
                        }
                    case "!Рандом":
                        {
                            Random rnd = new Random();
                            msg.Channel.SendMessageAsync($"Выпало число {rnd.Next(-1000, 1000)}");
                                break;

                        }
                    case "!Команды":
                        {
                            msg.Channel.SendMessageAsync("!Привет !Рандом !Id !Смс !Пенсил");
                            break;
                        }
                    case "!Id":
                        {
                            msg.Channel.SendMessageAsync($"Твое Id {msg.Author}");
                            break;
                        }
                    case "!Смс":
                        {
                            
                            for (int i = 0; i < 10; i++)
                            {
                                msg.Channel.SendMessageAsync($"Что-то тут есть  {i}");
                                
                            }
                            break;
                        }
                    case"!Пенсил":
                        {
                            Random rnd  = new Random();
                            msg.Channel.SendMessageAsync($"Товой пенсил равен {rnd.Next(0, 20)}");
                            break;
                        }

                       
                        
                       
                        
                }
            return Task.CompletedTask;
        }

       
    }
}



    