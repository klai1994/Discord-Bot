using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIMLbot;

namespace DiscordBot
{
    class Alice
    {
        private Bot aliceBot;
        private User user;

        public Alice()
        {
            aliceBot = new Bot();
            user = new User("consoleUser", aliceBot);
        }

        public void Initialize()
        {
            aliceBot.loadSettings();
            aliceBot.isAcceptingUserInput = false;
            aliceBot.loadAIMLFromFiles();
            aliceBot.isAcceptingUserInput = true;
        }

        public String getOutput(String input)
        {
            Request r = new Request(input, user, aliceBot);
            Result res = aliceBot.Chat(r);
            return (res.Output);
        }
    }
}
