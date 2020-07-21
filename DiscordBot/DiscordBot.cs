using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIMLbot;
using System.Data;

namespace DiscordBot
{
    class DiscordBot
    {
        private DiscordClient bot;
        Alice alice = new Alice();

        public DiscordBot()
        {
            bot = new DiscordClient();

            bot.MessageReceived += Bot_MessageReceived;
            alice.Initialize();

            bot.ExecuteAndWait(async () => {
                while(true)
                    try
                    {
                        await bot.Connect("MjAyMTcyODA0MTQ0MTY4OTYw.CmWfmA.t_oaEGssv_LP85j4XinHHGE5L7o");
                        break;
                    }
                    catch
                    {
                        await Task.Delay(3000);
                    }
            });
        }

        private void Bot_MessageReceived(object sender, MessageEventArgs e)
        {
            if (e.Message.IsAuthor) return;
            
            string userMessage;
            userMessage = e.Message.Text.ToLower();
            userMessage = userMessage.Replace(" ", "+");
            if (userMessage.StartsWith("?help"))
            {
                e.Channel.SendMessage("Commands:");
                e.Channel.SendMessage("Opening Bracket([) - Calculator");
                e.Channel.SendMessage("Closing Bracket(]) - Look up in dictionary");
                e.Channel.SendMessage("Semicolon (;) - Interact with chatbot");
                e.Channel.SendMessage("Ampersand (&) - Look up in urban dictionary");
            }
            else if (userMessage.StartsWith(";"))
            { 
                e.Channel.SendMessage(alice.getOutput(userMessage.Substring(1)));
            }
            else if (userMessage.StartsWith("["))
            {
                var result = new DataTable().Compute(userMessage.Substring(1), null);
                e.Channel.SendMessage(result.ToString());
            }
            else if (userMessage.StartsWith("]"))
            {
                e.Channel.SendMessage(e.User.Mention + ": " + "http://www.dictionary.com/browse/" + userMessage.Substring(1));
            }
            else if (userMessage.StartsWith("&"))
            {
                e.Channel.SendMessage(e.User.Mention + ": " + "http://www.urbandictionary.com/define.php?term=" + userMessage.Substring(1));
            }
        }
    }
}
